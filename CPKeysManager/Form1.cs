using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Threading;


namespace CPKeysManager
{
    public partial class Form1 : Form
    {

        public Dictionary<string, string> usersList = new Dictionary<string, string>();
        //public ListBox.ObjectCollection SelectedUsers;

        public Form1()
        {
            InitializeComponent();
        }

        private string[] getUsersUidList()
        {
            //
            string[] result = { };

            try
            {
                RegistryKey rkUsers = Registry.LocalMachine.OpenSubKey(CPKMConfig.baseUKey);
                result = rkUsers.GetSubKeyNames();
            }
            catch
            {
                MessageBox.Show(
                                    $"{CPKMStrings.txtErrCantReadReg}{Registry.LocalMachine.Name}{CPKMConfig.baseUKey}", 
                                    $"{System.Reflection.MethodBase.GetCurrentMethod().Name}", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error
                               );
            }
            //string baseUEKey = "HKEY_USERS\S-1-5-21-908165884-950078525-2760464006-1001\Volatile Environment";

            return result;
        }

        private string getUserName(string usersUid)
        {
            string result = null;

            if (!usersUid.Contains(CPKMConfig.keyFilter))
                return result;

            try
            {
                RegistryKey rkUsers = Registry.Users.OpenSubKey($"{usersUid}\\{CPKMConfig.baseUDNKey}");
                result = rkUsers.GetValue(CPKMConfig.unKey).ToString();
                result += @"@" + rkUsers.GetValue(CPKMConfig.dnKey).ToString();
                
            }
            catch
            {
                try
                {
                    result = null;
                    RegistryKey rkUsers = Registry.LocalMachine.OpenSubKey($"{CPKMConfig.baseUKey}\\{usersUid}");
                    result = rkUsers.GetValue(CPKMConfig.piKey).ToString();
                    result = result.Substring(result.LastIndexOf(@"\")+1);
                }
                catch
                {
                    result = null;
                }
            }

            return result;
        }

        private void formReload()
        {
            LBUsersList.Items.Clear();
            CLBKeys.Items.Clear();
            usersList.Clear();
            tssl1.Text = "";

            string[] usersUids = getUsersUidList();

            string udName = null;

            foreach (string item in usersUids)
            {
                udName = getUserName(item);
                if (udName!=null)
                {
                    try
                    {
                        usersList.Add(udName, item);
                    }
                    catch
                    {
                        //
                    }
                    
                    LBUsersList.Items.Add(udName);
                }
            }
            LBUsersList.Sorted = true;
        }

        private void uidToStatus()
        {
            try
            {
                tssl1.Text = usersList[LBUsersList.Text];
            }
            catch
            {
                //
            }
        }

        private string[] getUsersKeys(string usersUid)
        {
            string[] result = { };

            try
            {
                RegistryKey rkUsers = Registry.LocalMachine.OpenSubKey($"{CPKMConfig.baseCPKey}\\{usersUid}\\{CPKMConfig.baseCPKKey}");
                result = rkUsers.GetSubKeyNames();
            }
            catch
            {
                //result = null;
            }

            return result;
        }

        private void fillKeysList(string usersUid)
        {
            CLBKeys.Items.Clear();
            CLBKeys.Items.AddRange(getUsersKeys(usersUid));
        }

        private bool checkIfKeyIsExistsHKLM(string keyPath)
        {
            bool result = false;

            if(Registry.LocalMachine.OpenSubKey(keyPath) != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        /*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/

        private void Form1_Load(object sender, EventArgs e)
        {
            formReload();
        }

        private void LBUsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            uidToStatus();
            try
            {
                fillKeysList(usersList[LBUsersList.Text]);
                tbLog.AppendText($"{CPKMStrings.txtMsgSourceUser} {LBUsersList.Text}...\r\n");
            }
            catch
            {
                //
            }
        }

        private void mbUpdate_Click(object sender, EventArgs e)
        {
            formReload();
        }

        private void mbSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CLBKeys.Items.Count; i++)
            {
                CLBKeys.SetItemChecked(i, true);
            }
        }

        private void mbUnselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CLBKeys.Items.Count; i++)
            {
                CLBKeys.SetItemChecked(i, false);
            }
        }

        private void ttbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mbSelectFilter.Select();
            }
        }

        private void mbOpenFilterContext_Click(object sender, EventArgs e)
        {
            toolStripDropDownButton2.ShowDropDown();
            mbFilter.ShowDropDown();
            ttbFilter.Focus();
            ttbFilter.Select(0, ttbFilter.TextLength);
        }

        private void mbSelectFilter_Click(object sender, EventArgs e)
        {
            if (ttbFilter.TextLength == 0)
            {
                for (int i = 0; i < CLBKeys.Items.Count; i++)
                {
                    CLBKeys.SetItemChecked(i, true);
                }
                return;
            }

            for (int i = 0; i < CLBKeys.Items.Count; i++)
            {
                MatchCollection matches = Regex.Matches(CLBKeys.GetItemText(CLBKeys.Items[i]), ttbFilter.Text, RegexOptions.IgnoreCase);
                //if (CLBKeys.GetItemText(CLBKeys.Items[i]).ToUpper().Contains(ttbFilter.Text.ToUpper()))
                if (matches.Count>0)
                {
                    CLBKeys.SetItemChecked(i, true);
                }
            }

        }

        private void mbCopy_Click(object sender, EventArgs e)
        {
            if (CLBKeys.CheckedItems.Count <= 0)
            {
                tbLog.AppendText($"{CPKMStrings.txtErrNoKeysToAction}\r\n");
                return;
            }

            Form frmSelectUsers = new SelectUsers(LBUsersList.Items,LBUsersList.SelectedIndex, CPKMStrings.txtMsgSelectUserToCopyKeys);
            frmSelectUsers.StartPosition = FormStartPosition.CenterParent;
            cpkmDataExchange.cpkmvSelectedUsers = null;
            frmSelectUsers.ShowDialog(this);

            if (cpkmDataExchange.cpkmvSelectedUsers == null)
            {
                tbLog.AppendText($"{CPKMStrings.txtErrNoUsersToCopyKeys}\r\n");
                return;
            }

            /*while (cpkmDataExchange.cpkmvSelectedUsers.Count == 0)
            {
                //whatever
                Thread.Sleep(100);
            }*/
            int i = 0;
            string vUser = null;
            string pUser = null;
            string[] tUser = { };
            string rArgs = null;
            string uKeyPath = null;
            string oKeyPath = null;
            bool chkIfKeyEx = false;

            try
            {
                foreach (var item in cpkmDataExchange.cpkmvSelectedUsers)
                {
                    if (item.ToString().IndexOf('@')<0)
                    {
                        tbLog.AppendText($"{CPKMStrings.txtUser} {item} {CPKMStrings.txtMsgNotSignedIn}\r\n");

                        //here is copying code for NOT signed in users

                        continue;
                    }

                    foreach (var ikey in CLBKeys.CheckedItems)
                    {
                        tUser = item.ToString().Split('@');
                        vUser = $"{tUser[1]}\\{tUser[0]}";
                        pUser = tUser[0];
                        tbLog.AppendText($"{CPKMStrings.txtMsgCopyKeysForUser} {vUser} <-- {ikey}\r\n");
                        uKeyPath = $"{CPKMConfig.baseCPKey}\\{usersList[item.ToString()]}\\{CPKMConfig.baseCPKKey}\\{ikey}";
                        oKeyPath = $"{CPKMConfig.baseCPKey}\\{usersList[LBUsersList.Text]}\\{CPKMConfig.baseCPKKey}\\{ikey}";

                        //here is copying code for signeb in users

                        //Creating registry key for a container
                        rArgs = $"/create /RU {vUser} /IT /TN keyCreateFor_{pUser} /TR \"reg.exe ADD \'HKLM\\{uKeyPath}\'\" /SC DAILY /F";
                        System.Diagnostics.Process psSch = new System.Diagnostics.Process();
                        psSch.StartInfo.FileName = CPKMConfig.pathSchtasks;
                        psSch.StartInfo.Arguments = rArgs;
                        psSch.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        psSch.Start();
                        psSch.WaitForExit();
                        /*rArgs = $"/run /TN keyCreateFor_{pUser}";
                        psSch.StartInfo.Arguments = rArgs;
                        psSch.Start();
                        psSch.WaitForExit();
                        rArgs = $"/Delete /TN keyCreateFor_{pUser} /F";
                        psSch.StartInfo.Arguments = rArgs;
                        psSch.Start();
                        psSch.WaitForExit();*/
                        psSch.Dispose();
                        ///////////////////////////

                        //Checking if the key created at the previous step is exists
                        chkIfKeyEx = false;
                        chkIfKeyEx = checkIfKeyIsExistsHKLM(uKeyPath);
                        if (!chkIfKeyEx)
                        {
                            //tbLog.AppendText($"{CPKMStrings.txtErrNoRegistryPath} {Registry.LocalMachine.Name}\\{uKeyPath}\r\n");
                            //continue;
                        }
                        else if (checkIfKeyIsExistsHKLM(uKeyPath))
                        {
                            //tbLog.AppendText($"OK\r\n");
                        }
                        ///////////////////////////

                        //Copying the container
                        /*System.Diagnostics.Process psReg = new System.Diagnostics.Process();
                        psReg.StartInfo.FileName = CPKMConfig.pathReg;
                        rArgs = $"copy \"HKLM\\{oKeyPath}\" \"HKLM\\{uKeyPath}\" /s /f";
                        psReg.StartInfo.Arguments = rArgs;
                        psReg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        psReg.Start();
                        psReg.WaitForExit();
                        psReg.Dispose();*/
                        ///////////////////////////
                        
                        
                        //reg copy "HKLM\SOFTWARE\WOW6432Node\Crypto Pro\Settings\Users\S-1-5-21-908165884-950078525-27604
                        //64006 - 1001\Keys\2018 - 01 - 15 12 - 09 - 38 ООО ВОСТСИБДОБЫЧА" "HKLM\SOFTWARE\WOW6432Node\Crypto Pro\Settings\Users\S - 1 - 5 - 21 - 908
                        //165884 - 950078525 - 2760464006 - 1002\Keys\2018 - 01 - 15 12 - 09 - 38 ООО ВОСТСИБДОБЫЧА" /s /f
                    }

                    i++;
                }
                /*tbLog.AppendText("Запускаем блокнот\r\n");
                System.Diagnostics.Process notepad = new System.Diagnostics.Process();
                notepad.StartInfo.FileName = "notepad.exe";
                notepad.StartInfo.Arguments = "";
                notepad.Start();
                notepad.WaitForExit();
                notepad.Dispose();*/
            }
            finally
            {
                //
            }
            tbLog.AppendText($"{CPKMStrings.txtDone}\r\n");
        }
    }
}
