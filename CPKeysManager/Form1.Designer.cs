namespace CPKeysManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LBUsersList = new System.Windows.Forms.ListBox();
            this.CLBKeys = new System.Windows.Forms.CheckedListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mbUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mbOpenFilterContext = new System.Windows.Forms.ToolStripMenuItem();
            this.tssl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mbCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mbInstallCerts = new System.Windows.Forms.ToolStripMenuItem();
            this.mbSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mbFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.ttbFilter = new System.Windows.Forms.ToolStripTextBox();
            this.mbSelectFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.mbUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mbDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBUsersList
            // 
            this.LBUsersList.FormattingEnabled = true;
            this.LBUsersList.Location = new System.Drawing.Point(12, 12);
            this.LBUsersList.Name = "LBUsersList";
            this.LBUsersList.ScrollAlwaysVisible = true;
            this.LBUsersList.Size = new System.Drawing.Size(363, 303);
            this.LBUsersList.TabIndex = 0;
            this.LBUsersList.SelectedIndexChanged += new System.EventHandler(this.LBUsersList_SelectedIndexChanged);
            // 
            // CLBKeys
            // 
            this.CLBKeys.FormattingEnabled = true;
            this.CLBKeys.Location = new System.Drawing.Point(381, 11);
            this.CLBKeys.Name = "CLBKeys";
            this.CLBKeys.ScrollAlwaysVisible = true;
            this.CLBKeys.Size = new System.Drawing.Size(363, 304);
            this.CLBKeys.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.tssl1,
            this.toolStripDropDownButton2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(754, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbUpdate,
            this.mbOpenFilterContext});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(98, 20);
            this.toolStripDropDownButton1.Text = "Пользователи";
            // 
            // mbUpdate
            // 
            this.mbUpdate.Name = "mbUpdate";
            this.mbUpdate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mbUpdate.Size = new System.Drawing.Size(205, 22);
            this.mbUpdate.Text = "Обновить";
            this.mbUpdate.Click += new System.EventHandler(this.mbUpdate_Click);
            // 
            // mbOpenFilterContext
            // 
            this.mbOpenFilterContext.Name = "mbOpenFilterContext";
            this.mbOpenFilterContext.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mbOpenFilterContext.Size = new System.Drawing.Size(205, 22);
            this.mbOpenFilterContext.Text = "Открыть фильтр";
            this.mbOpenFilterContext.Visible = false;
            this.mbOpenFilterContext.Click += new System.EventHandler(this.mbOpenFilterContext_Click);
            // 
            // tssl1
            // 
            this.tssl1.AutoSize = false;
            this.tssl1.Name = "tssl1";
            this.tssl1.Size = new System.Drawing.Size(278, 17);
            this.tssl1.Text = "XXXXXXXXXXxXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbCopy,
            this.mbInstallCerts,
            this.mbSelectAll,
            this.mbFilter,
            this.mbUnselectAll,
            this.mbDelete});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(58, 20);
            this.toolStripDropDownButton2.Text = "Ключи";
            // 
            // mbCopy
            // 
            this.mbCopy.Name = "mbCopy";
            this.mbCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mbCopy.Size = new System.Drawing.Size(274, 22);
            this.mbCopy.Text = "Копировать контейнеры";
            this.mbCopy.Click += new System.EventHandler(this.mbCopy_Click);
            // 
            // mbInstallCerts
            // 
            this.mbInstallCerts.Name = "mbInstallCerts";
            this.mbInstallCerts.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mbInstallCerts.Size = new System.Drawing.Size(274, 22);
            this.mbInstallCerts.Text = "Установить сертификаты";
            // 
            // mbSelectAll
            // 
            this.mbSelectAll.Name = "mbSelectAll";
            this.mbSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mbSelectAll.Size = new System.Drawing.Size(274, 22);
            this.mbSelectAll.Text = "Выделить все контейнеры";
            this.mbSelectAll.Click += new System.EventHandler(this.mbSelectAll_Click);
            // 
            // mbFilter
            // 
            this.mbFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttbFilter,
            this.mbSelectFilter});
            this.mbFilter.Name = "mbFilter";
            this.mbFilter.Size = new System.Drawing.Size(274, 22);
            this.mbFilter.Text = "Выделить по фильтру";
            // 
            // ttbFilter
            // 
            this.ttbFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ttbFilter.Name = "ttbFilter";
            this.ttbFilter.Size = new System.Drawing.Size(100, 23);
            this.ttbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ttbFilter_KeyPress);
            // 
            // mbSelectFilter
            // 
            this.mbSelectFilter.Name = "mbSelectFilter";
            this.mbSelectFilter.Size = new System.Drawing.Size(160, 22);
            this.mbSelectFilter.Text = "Выделить";
            this.mbSelectFilter.Click += new System.EventHandler(this.mbSelectFilter_Click);
            // 
            // mbUnselectAll
            // 
            this.mbUnselectAll.Name = "mbUnselectAll";
            this.mbUnselectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.mbUnselectAll.Size = new System.Drawing.Size(274, 22);
            this.mbUnselectAll.Text = "Снять выделение";
            this.mbUnselectAll.Click += new System.EventHandler(this.mbUnselectAll_Click);
            // 
            // mbDelete
            // 
            this.mbDelete.Name = "mbDelete";
            this.mbDelete.Size = new System.Drawing.Size(274, 22);
            this.mbDelete.Text = "Удалить контейнеры и сертификаты";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(12, 321);
            this.tbLog.MaxLength = 327670;
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(732, 65);
            this.tbLog.TabIndex = 0;
            this.tbLog.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 411);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.CLBKeys);
            this.Controls.Add(this.LBUsersList);
            this.MinimumSize = new System.Drawing.Size(770, 450);
            this.Name = "Form1";
            this.Text = "CPKeysManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBUsersList;
        private System.Windows.Forms.CheckedListBox CLBKeys;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mbUpdate;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem mbCopy;
        private System.Windows.Forms.ToolStripMenuItem mbSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mbUnselectAll;
        private System.Windows.Forms.ToolStripMenuItem mbInstallCerts;
        private System.Windows.Forms.ToolStripMenuItem mbFilter;
        private System.Windows.Forms.ToolStripTextBox ttbFilter;
        private System.Windows.Forms.ToolStripMenuItem mbSelectFilter;
        private System.Windows.Forms.ToolStripMenuItem mbOpenFilterContext;
        private System.Windows.Forms.ToolStripMenuItem mbDelete;
        private System.Windows.Forms.TextBox tbLog;
    }
}

