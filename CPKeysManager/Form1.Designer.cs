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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mbUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbOpenFilterContext = new System.Windows.Forms.ToolStripMenuItem();
            this.tssl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mbCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mbExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mbSearchContainers = new System.Windows.Forms.ToolStripMenuItem();
            this.ttbSearchString = new System.Windows.Forms.ToolStripTextBox();
            this.mbSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mbSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mbFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.ttbFilter = new System.Windows.Forms.ToolStripTextBox();
            this.mbSelectFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.mbUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mbDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tssl2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBUsersList = new System.Windows.Forms.ListBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CLBKeys = new CPKeysManager.UserCheckedListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.tssl1,
            this.toolStripDropDownButton2,
            this.tssl2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(739, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbUpdate,
            this.openLogToolStripMenuItem,
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
            // openLogToolStripMenuItem
            // 
            this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            this.openLogToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.openLogToolStripMenuItem.Text = "Открыть лог";
            this.openLogToolStripMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
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
            this.mbExport,
            this.mbSearchContainers,
            this.mbSelectAll,
            this.mbFilter,
            this.mbUnselectAll,
            this.mbDelete});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(88, 20);
            this.toolStripDropDownButton2.Text = "Контейнеры";
            // 
            // mbCopy
            // 
            this.mbCopy.Name = "mbCopy";
            this.mbCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mbCopy.Size = new System.Drawing.Size(277, 22);
            this.mbCopy.Text = "Копировать контейнеры";
            this.mbCopy.Click += new System.EventHandler(this.mbCopy_Click);
            // 
            // mbExport
            // 
            this.mbExport.Name = "mbExport";
            this.mbExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mbExport.Size = new System.Drawing.Size(277, 22);
            this.mbExport.Text = "Экспорт контейнеров в файл";
            this.mbExport.Click += new System.EventHandler(this.mbExport_Click);
            // 
            // mbSearchContainers
            // 
            this.mbSearchContainers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttbSearchString,
            this.mbSearch});
            this.mbSearchContainers.Name = "mbSearchContainers";
            this.mbSearchContainers.Size = new System.Drawing.Size(277, 22);
            this.mbSearchContainers.Text = "Поиск контейнеров у пользователей";
            // 
            // toolStripTextBox1
            // 
            this.ttbSearchString.Name = "ttbSearchString";
            this.ttbSearchString.Size = new System.Drawing.Size(100, 23);
            // 
            // mbSearch
            // 
            this.mbSearch.Name = "mbSearch";
            this.mbSearch.Size = new System.Drawing.Size(180, 22);
            this.mbSearch.Text = "Поиск";
            this.mbSearch.Click += new System.EventHandler(this.mbSearch_Click);
            // 
            // mbSelectAll
            // 
            this.mbSelectAll.Name = "mbSelectAll";
            this.mbSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mbSelectAll.Size = new System.Drawing.Size(277, 22);
            this.mbSelectAll.Text = "Выделить все контейнеры";
            this.mbSelectAll.Click += new System.EventHandler(this.mbSelectAll_Click);
            // 
            // mbFilter
            // 
            this.mbFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttbFilter,
            this.mbSelectFilter});
            this.mbFilter.Name = "mbFilter";
            this.mbFilter.Size = new System.Drawing.Size(277, 22);
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
            this.mbSelectFilter.Size = new System.Drawing.Size(180, 22);
            this.mbSelectFilter.Text = "Выделить";
            this.mbSelectFilter.Click += new System.EventHandler(this.mbSelectFilter_Click);
            // 
            // mbUnselectAll
            // 
            this.mbUnselectAll.Name = "mbUnselectAll";
            this.mbUnselectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.mbUnselectAll.Size = new System.Drawing.Size(277, 22);
            this.mbUnselectAll.Text = "Снять выделение";
            this.mbUnselectAll.Click += new System.EventHandler(this.mbUnselectAll_Click);
            // 
            // mbDelete
            // 
            this.mbDelete.Name = "mbDelete";
            this.mbDelete.Size = new System.Drawing.Size(277, 22);
            this.mbDelete.Text = "Удалить отмеченные контейнеры";
            this.mbDelete.Click += new System.EventHandler(this.mbDelete_Click);
            // 
            // tssl2
            // 
            this.tssl2.Name = "tssl2";
            this.tssl2.Size = new System.Drawing.Size(143, 17);
            this.tssl2.Text = "Выбрано контейнеров: 0";
            // 
            // LBUsersList
            // 
            this.LBUsersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBUsersList.FormattingEnabled = true;
            this.LBUsersList.IntegralHeight = false;
            this.LBUsersList.Location = new System.Drawing.Point(3, 3);
            this.LBUsersList.Name = "LBUsersList";
            this.LBUsersList.ScrollAlwaysVisible = true;
            this.LBUsersList.Size = new System.Drawing.Size(363, 303);
            this.LBUsersList.TabIndex = 3;
            this.LBUsersList.SelectedIndexChanged += new System.EventHandler(this.LBUsersList_SelectedIndexChanged);
            // 
            // tbLog
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbLog, 2);
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(3, 312);
            this.tbLog.MaxLength = 327670;
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(733, 74);
            this.tbLog.TabIndex = 5;
            this.tbLog.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LBUsersList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CLBKeys, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbLog, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(739, 389);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // CLBKeys
            // 
            this.CLBKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLBKeys.FormattingEnabled = true;
            this.CLBKeys.IntegralHeight = false;
            this.CLBKeys.Location = new System.Drawing.Point(372, 3);
            this.CLBKeys.Name = "CLBKeys";
            this.CLBKeys.ScrollAlwaysVisible = true;
            this.CLBKeys.Size = new System.Drawing.Size(364, 303);
            this.CLBKeys.TabIndex = 4;
            this.CLBKeys.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLBKeys_ItemCheck);
            this.CLBKeys.Click += new System.EventHandler(this.CLBKeys_Click);
            this.CLBKeys.SelectedIndexChanged += new System.EventHandler(this.CLBKeys_SelectedIndexChanged);
            this.CLBKeys.SelectedValueChanged += new System.EventHandler(this.CLBKeys_SelectedValueChanged);
            this.CLBKeys.DoubleClick += new System.EventHandler(this.CLBKeys_DoubleClick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "reg";
            this.saveFileDialog1.FileName = "export";
            this.saveFileDialog1.Filter = "(*.reg)|*.reg";
            this.saveFileDialog1.Title = "Выберите файл для сохранения.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 411);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(755, 450);
            this.Name = "Form1";
            this.Text = "CPKeysManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mbUpdate;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem mbCopy;
        private System.Windows.Forms.ToolStripMenuItem mbSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mbUnselectAll;
        private System.Windows.Forms.ToolStripMenuItem mbExport;
        private System.Windows.Forms.ToolStripMenuItem mbFilter;
        private System.Windows.Forms.ToolStripTextBox ttbFilter;
        private System.Windows.Forms.ToolStripMenuItem mbSelectFilter;
        private System.Windows.Forms.ToolStripMenuItem mbOpenFilterContext;
        private System.Windows.Forms.ToolStripMenuItem mbDelete;
        private System.Windows.Forms.ListBox LBUsersList;
        public UserCheckedListBox CLBKeys;
        private System.Windows.Forms.TextBox tbLog;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel tssl2;
        private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbSearchContainers;
        private System.Windows.Forms.ToolStripMenuItem mbSearch;
        private System.Windows.Forms.ToolStripTextBox ttbSearchString;
    }
}

