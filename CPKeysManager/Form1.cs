using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Drawing;

namespace CPKeysManager
{
    public partial class Form1 : Form
    {

        public Dictionary<string, string> usersList = new Dictionary<string, string>();
        public Dictionary<string, string> uPathList = new Dictionary<string, string>();
        public static CheckedListBox CLBKeysCopy = new CheckedListBox();
        public bool ic = false;
        
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

        private string getUserPath(string usersUid)
        {
            string result = null;

            if (!usersUid.Contains(CPKMConfig.keyFilter))
                return result;
            try
            {
                result = null;
                RegistryKey rkUsers = Registry.LocalMachine.OpenSubKey($"{CPKMConfig.baseUKey}\\{usersUid}");
                result = rkUsers.GetValue(CPKMConfig.piKey).ToString();
            }
            catch
            {
                result = null;
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
            string uPath = null;

            foreach (string item in usersUids)
            {
                udName = getUserName(item);
                uPath = getUserPath(item);
                if (uPath == null) continue;
                if (udName!=null && Directory.Exists($@"{uPath}\AppData\Roaming\dln\cpci2"))
                {
                    try
                    {
                        usersList.Add(udName, item);
                        uPathList.Add(udName, $@"{uPath}\AppData\Roaming\dln\cpci2");
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

        public static bool isclbElementChecked(int index)
        {
            try
            {
                return CLBKeysCopy.GetItemChecked(index);
            }
            catch
            {
                return false;
            }

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
            tssl2.Text = $"{CPKMStrings.txtSelectedContainers} {CLBKeys.CheckedItems.Count.ToString()}";
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
            tssl2.Text = $"{CPKMStrings.txtSelectedContainers} {CLBKeys.CheckedItems.Count.ToString()}";
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

            tssl2.Text = $"{CPKMStrings.txtSelectedContainers} {CLBKeys.CheckedItems.Count.ToString()}";
            CLBKeys.Refresh();

        }

        private void mbCopy_Click(object sender, EventArgs e)
        {
            tbLog.AppendText("Копирование контейнеров...\r\n");
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

            this.Enabled = false;

            cpKeyReg cpKey = new cpKeyReg(null, null);
            List<string> data = new List<string>();

            data.Add("Windows Registry Editor Version 5.00");
            data.Add("");
            data.Add($@"[HKEY_LOCAL_MACHINE\{CPKMConfig.baseCPKey}\{usersList[LBUsersList.SelectedItem.ToString()]}\{CPKMConfig.baseCPKKey}]");
            data.Add("");
            try
            {
                foreach (var ikey in CLBKeys.CheckedItems)
                {
                    cpKey.keyname = ikey.ToString();
                    cpKey.sid = usersList[LBUsersList.SelectedItem.ToString()];
                    data.AddRange(cpKey.getKey().ToList());
                }
            }
            catch(Exception ex)
            {
                tbLog.AppendText($"Ошибка экспорта контейнера! Детали:\r\n{ex.Source}\r\n{ex.TargetSite}\r\n{ex.Message}\r\n");
            }
            try
            {
                File.WriteAllLines("tmpinput.reg", data.ToArray(), Encoding.Unicode);
            }
            catch
            {
                tbLog.AppendText("Ошибка записи tmpinput.reg");
            }

            if (File.Exists("tmpinput.reg"))
            {
                foreach (var item in cpkmDataExchange.cpkmvSelectedUsers)
                {
                    if (File.Exists($@"{uPathList[item.ToString()]}\input.reg"))
                    {
                        data.RemoveRange(0, 4);
                        try
                        {
                            File.AppendAllLines($@"{uPathList[item.ToString()]}\input.reg", data, Encoding.Unicode);
                        }
                        catch (Exception ex)
                        {
                            tbLog.AppendText($"Ошибка добавления данных в input.reg! Детали:\r\n{ex.Source}\r\n{ex.TargetSite}\r\n{ex.Message}\r\n");
                        }
                    }
                    else
                    {
                        try
                        {
                            File.Copy("tmpinput.reg", $@"{uPathList[item.ToString()]}\input.reg");
                        }
                        catch (Exception ex)
                        {
                            tbLog.AppendText($"Ошибка копирования в input.reg! Детали:\r\n{ex.Source}\r\n{ex.TargetSite}\r\n{ex.Message}\r\n");
                        }
                    }

                    if (cpkmDataExchange.cpkmvForceReinstallCerts)
                    {
                        try
                        {
                            File.Delete($@"{uPathList[item.ToString()]}\cpKey.list");
                        }
                        catch (Exception ex)
                        {
                            tbLog.AppendText($"Ошибка удаления cpKey.list! Детали:\r\n{ex.Source}\r\n{ex.TargetSite}\r\n{ex.Message}\r\n");
                        }
                    }
                }
                try
                {
                    File.Delete("tmpinput.reg");
                }
                catch (Exception ex)
                {
                    tbLog.AppendText($"Ошибка удаления tmpinput.reg! Детали:\r\n{ex.Source}\r\n{ex.TargetSite}\r\n{ex.Message}\r\n");
                }
            }
            cpkmDataExchange.cpkmvSelectedUsers = null;
            cpkmDataExchange.cpkmvForceReinstallCerts = false;
            this.Enabled = true;

            tbLog.AppendText($"{CPKMStrings.txtDone}\r\n");
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ActiveForm.Visible = false;
        }

        private void resizeElements()
        {
            /*
            LBUsersList.Top = 12;
            LBUsersList.Left = 12;
            CLBKeys.Top = 12;
            CLBKeys.Left = LBUsersList.Right + 12;

            LBUsersList.Width = (ActiveForm.Width / 2) - 36;
            CLBKeys.Width = tbLog.Right - CLBKeys.Left;

            LBUsersList.Height = tbLog.Top - LBUsersList.Top - 8;
            CLBKeys.Height = LBUsersList.Height;
            */
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            resizeElements();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeElements();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            resizeElements();
        }

        private void CLBKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            tssl2.Text = $"{CPKMStrings.txtSelectedContainers} {CLBKeys.CheckedItems.Count.ToString()}";
            ttbSearchString.Text = CLBKeys.SelectedItem.ToString();
        }

        private void CLBKeys_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ic)
            {
                CLBKeysCopy = CLBKeys;
                CLBKeys.Refresh();
                ic = !ic;
            }
        }

        private void CLBKeys_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ic = true;
        }

        private void mbDelete_Click(object sender, EventArgs e)
        {
            if (CLBKeys.CheckedItems.Count <= 0)
            {
                MessageBox.Show($"Не выбраны контейнеры!", "Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Вы уверены. что хотите удалить отмеченные контейнеры?\r\n{CLBKeys.CheckedItems.Count} шт.\r\nЭту операцию нельзя отменить!", 
                "Внимание!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No)
            {
                tbLog.AppendText($"Операция отменена.\r\n");
                return;
            }
                

            foreach (var ikey in CLBKeys.CheckedItems)
            {
                try
                {
                    Registry.LocalMachine.DeleteSubKey($@"{CPKMConfig.baseCPKey}\{usersList[LBUsersList.Text]}\{CPKMConfig.baseCPKKey}\{ikey.ToString()}");
                }
                catch
                {
                    tbLog.AppendText($"Ошибка во время удаления контейнера {ikey.ToString()}\r\n");
                }
            }

            LBUsersList_SelectedIndexChanged(this, EventArgs.Empty);
            tbLog.AppendText($"{CPKMStrings.txtDone}\r\n");
        }

        private void mbExport_Click(object sender, EventArgs e)
        {
            if (CLBKeys.CheckedItems.Count <= 0)
            {
                tbLog.AppendText($"{CPKMStrings.txtErrNoKeysToAction}\r\n");
                return;
            }

            if (CLBKeys.CheckedItems.Count == 1)
            {
                saveFileDialog1.FileName = CLBKeys.CheckedItems[0].ToString();
            }
            else
            {
                saveFileDialog1.FileName = "export";
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string expath = saveFileDialog1.FileName;

            this.Enabled = false;

            cpKeyReg cpKey = new cpKeyReg(null, null);
            List<string> data = new List<string>();

            data.Add("Windows Registry Editor Version 5.00");
            data.Add("");
            data.Add($@"[HKEY_LOCAL_MACHINE\{CPKMConfig.baseCPKey}\{usersList[LBUsersList.SelectedItem.ToString()]}\{CPKMConfig.baseCPKKey}]");
            data.Add("");
            try
            {
                foreach (var ikey in CLBKeys.CheckedItems)
                {
                    cpKey.keyname = ikey.ToString();
                    cpKey.sid = usersList[LBUsersList.SelectedItem.ToString()];
                    data.AddRange(cpKey.getKey().ToList());
                }
            }
            catch (Exception ex)
            {
                tbLog.AppendText($"Ошибка экспорта контейнера! Детали:\r\n{ex.Source}\r\n{ex.TargetSite}\r\n{ex.Message}\r\n");
            }

            //////////

            try
            {
                File.WriteAllLines(expath, data.ToArray(), Encoding.Unicode);
            }
            catch
            {
                tbLog.AppendText($"Ошибка записи {expath}");
            }

            this.Enabled = true;

            tbLog.AppendText($"{CPKMStrings.txtDone}\r\n");
        }

        private void CLBKeys_Click(object sender, EventArgs e)
        {
            tssl2.Text = $"{CPKMStrings.txtSelectedContainers} {CLBKeys.CheckedItems.Count.ToString()}";
            ttbSearchString.Text = CLBKeys.SelectedItem.ToString();
        }

        private void CLBKeys_DoubleClick(object sender, EventArgs e)
        {
            tssl2.Text = $"{CPKMStrings.txtSelectedContainers} {CLBKeys.CheckedItems.Count.ToString()}";
            ttbSearchString.Text = CLBKeys.SelectedItem.ToString();
        }

        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            Process ps = new Process();
            ps.StartInfo.FileName = $@"{Environment.GetEnvironmentVariable("WINDIR")}\notepad.exe";
            ps.StartInfo.Arguments = $"{uPathList[LBUsersList.Text]}\\cpci2.log";
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            ps.Start();
            ps.WaitForExit();
            ps.Dispose();
        }

        private void mbSearch_Click(object sender, EventArgs e)
        {
            string[] aSearchResult = { };
            string[] containers = { };
            foreach (var item in usersList)
            {
                containers = getUsersKeys(item.Value);
                foreach (string container in containers)
                {
                    if (container.Contains(ttbSearchString.Text))
                    {
                        aSearchResult = aSearchResult.Concat(new string[] { item.Key }).ToArray();
                        tbLog.AppendText($"\"{ttbSearchString.Text}\" найден у пользователя {item.Key}\r\n");
                        break;
                    }
                }
            }
            cpkmDataExchange.searchResult = aSearchResult;
            tbLog.AppendText("Результаты поиска сохранены.\r\n");
        }
    }

    public class UserCheckedListBox : CheckedListBox
    {
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            
            if (Form1.isclbElementChecked(e.Index))
            {
                DrawItemEventArgs e2 = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, e.ForeColor, Color.LightGray/*e.BackColor*/);
                base.OnDrawItem(e2);
            }
        }
    }

    public class cpKeyReg
    {
        public string keyname { get; set; }
        public string sid { get; set; }

        public cpKeyReg(string keyname, string sid)
        {
            this.keyname = keyname;
            this.sid = sid;
        }

        public string[] getKey()
        {
            string[] res = { };

            //RegistryKey key = Registry.LocalMachine.OpenSubKey($@"{CPKMConfig.baseCPKey}\{sid}\{CPKMConfig.baseCPKKey}");
            Process ps = new Process();
            ps.StartInfo.FileName = $@"{Environment.GetEnvironmentVariable("WINDIR")}\system32\reg.exe";
            ps.StartInfo.Arguments = $"export \"HKLM\\{CPKMConfig.baseCPKey}\\{sid}\\{CPKMConfig.baseCPKKey}\\{keyname}\" \"{Application.StartupPath}\\tmp.dat\" /y";
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ps.Start();
            ps.WaitForExit();
            ps.Dispose();

            if (File.Exists($@"{Application.StartupPath}\tmp.dat"))
            {
                List<string> tlistorig = File.ReadAllLines($@"{Application.StartupPath}\tmp.dat", Encoding.Unicode).ToList();
                List<string> tlistmod = File.ReadAllLines($@"{Application.StartupPath}\tmp.dat", Encoding.Unicode).ToList();
                foreach (string item in tlistorig)
                {
                    if (item.Contains(keyname) && item.Contains(sid)) break;
                    tlistmod.Remove(item);
                }
                if (tlistmod.Count > 0)
                {
                    res = tlistmod.ToArray();
                }
                File.Delete($@"{Application.StartupPath}\tmp.dat");
            }

            return res;
        }
    }
}
