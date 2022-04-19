using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace CPKeysManager
{
    public partial class SelectUsers : Form
    {

        public SelectUsers()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        public SelectUsers(ListBox.ObjectCollection UsersList, int SelectedUser, string Caption, int Action = 0)
        {
            InitializeComponent();
            this.KeyPreview = true;
            clbUsers.Items.Clear();
            int i = 0;
            this.Text = Caption;

            foreach(var item in UsersList)
            {
                if (/*i != SelectedUser && */Action == 0)
                {
                    clbUsers.Items.Add(item);
                }
                else if(i == SelectedUser && Action == 1)
                {
                    clbUsers.Items.Add(item);
                    clbUsers.SetItemChecked(i, true);
                }
                else if(Action == 1)
                {
                    clbUsers.Items.Add(item);
                }
                i++;
            }

            //clbUsers.Items.AddRange(UsersList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (clbUsers.CheckedItems.Count > 0)
                {
                    cpkmDataExchange.cpkmvSelectedUsers = clbUsers.CheckedItems;
                    if (checkBox1.Checked)
                    {
                        cpkmDataExchange.cpkmvForceReinstallCerts = true;
                    }
                    else
                    {
                        cpkmDataExchange.cpkmvForceReinstallCerts = false;
                    }
                }
            }
            catch
            {
                //
            }
            this.Close();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void SelectUsers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.button3_Click(this.button3, null);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(this.button1, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (clbUsers.CheckedItems.Count == clbUsers.Items.Count)
            {
                for (int i = 0; i < clbUsers.Items.Count; i++)
                {
                    clbUsers.SetItemChecked(i, false);
                }
            }
            else
            {
                for (int i = 0; i < clbUsers.Items.Count; i++)
                {
                    clbUsers.SetItemChecked(i, true);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbUsers.Items.Count; i++)
            {
                clbUsers.SetItemChecked(i, false);
            }
            for (int i = 0; i < clbUsers.Items.Count; i++)
            {
                if (cpkmDataExchange.searchResult.AsQueryable().Contains(clbUsers.Items[i]))
                {
                    clbUsers.SetItemChecked(i, true);
                }
            }
        }
    }
}
