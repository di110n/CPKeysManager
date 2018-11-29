using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text.RegularExpressions;


namespace CPKeysManager
{
    public partial class Form1 : Form
    {

        public Dictionary<string, string> usersList = new Dictionary<string, string>();
        //public Dictionary<string, string> keyList = new Dictionary<string, string>();

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
            tssl1.Text = usersList[LBUsersList.Text];
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

        private void Form1_Load(object sender, EventArgs e)
        {
            formReload();
        }

        private void LBUsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            uidToStatus();
            fillKeysList(usersList[LBUsersList.Text]);
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
                //string debuggerstr = CLBKeys.GetItemText(CLBKeys.Items[i]);
                MatchCollection matches = Regex.Matches(CLBKeys.GetItemText(CLBKeys.Items[i]), ttbFilter.Text, RegexOptions.IgnoreCase);
                //int debugint = matches.Count;
                //if (CLBKeys.GetItemText(CLBKeys.Items[i]).ToUpper().Contains(ttbFilter.Text.ToUpper()))
                if (matches.Count>0)
                {
                    CLBKeys.SetItemChecked(i, true);
                }
            }

        }
    }
}
