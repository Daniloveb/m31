namespace M31
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.cmd_Resources = new System.Windows.Forms.ComboBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_foldername = new System.Windows.Forms.TextBox();
            this.but_delfolder = new System.Windows.Forms.Button();
            this.but_addfolder = new System.Windows.Forms.Button();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.lbl_change = new System.Windows.Forms.Label();
            this.but_c_rm = new System.Windows.Forms.Button();
            this.but_c_add = new System.Windows.Forms.Button();
            this.but_r_rm = new System.Windows.Forms.Button();
            this.lbl_read = new System.Windows.Forms.Label();
            this.but_r_add = new System.Windows.Forms.Button();
            this.lbl_path = new System.Windows.Forms.Label();
            this.listView_change = new System.Windows.Forms.ListView();
            this.listView_read = new System.Windows.Forms.ListView();
            this.tree_folders = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.butCSV = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_resource_name = new System.Windows.Forms.TextBox();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmd_Resources
            // 
            this.cmd_Resources.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmd_Resources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmd_Resources.FormattingEnabled = true;
            this.cmd_Resources.Location = new System.Drawing.Point(0, 0);
            this.cmd_Resources.Name = "cmd_Resources";
            this.cmd_Resources.Size = new System.Drawing.Size(949, 23);
            this.cmd_Resources.Sorted = true;
            this.cmd_Resources.TabIndex = 0;
            this.cmd_Resources.SelectedIndexChanged += new System.EventHandler(this.cmd_Resources_SelectedIndexChanged);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 23);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(949, 719);
            this.tabs.TabIndex = 1;
            this.tabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabs_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.richTextBox_log);
            this.tabPage1.Controls.Add(this.lbl_change);
            this.tabPage1.Controls.Add(this.but_c_rm);
            this.tabPage1.Controls.Add(this.but_c_add);
            this.tabPage1.Controls.Add(this.but_r_rm);
            this.tabPage1.Controls.Add(this.lbl_read);
            this.tabPage1.Controls.Add(this.but_r_add);
            this.tabPage1.Controls.Add(this.lbl_path);
            this.tabPage1.Controls.Add(this.listView_change);
            this.tabPage1.Controls.Add(this.listView_read);
            this.tabPage1.Controls.Add(this.tree_folders);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(941, 691);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Доступ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_foldername);
            this.panel1.Controls.Add(this.but_delfolder);
            this.panel1.Controls.Add(this.but_addfolder);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 69);
            this.panel1.TabIndex = 12;
            // 
            // txt_foldername
            // 
            this.txt_foldername.Location = new System.Drawing.Point(9, 4);
            this.txt_foldername.Name = "txt_foldername";
            this.txt_foldername.Size = new System.Drawing.Size(242, 23);
            this.txt_foldername.TabIndex = 2;
            this.txt_foldername.Text = "Введите имя папки";
            this.txt_foldername.Click += new System.EventHandler(this.txt_foldername_Click);
            // 
            // but_delfolder
            // 
            this.but_delfolder.Enabled = false;
            this.but_delfolder.Location = new System.Drawing.Point(131, 34);
            this.but_delfolder.Name = "but_delfolder";
            this.but_delfolder.Size = new System.Drawing.Size(120, 32);
            this.but_delfolder.TabIndex = 1;
            this.but_delfolder.Text = "Удаление папки";
            this.but_delfolder.UseVisualStyleBackColor = true;
            this.but_delfolder.Click += new System.EventHandler(this.but_delfolder_Click);
            // 
            // but_addfolder
            // 
            this.but_addfolder.Location = new System.Drawing.Point(5, 34);
            this.but_addfolder.Name = "but_addfolder";
            this.but_addfolder.Size = new System.Drawing.Size(120, 32);
            this.but_addfolder.TabIndex = 0;
            this.but_addfolder.Text = "Создание папки";
            this.but_addfolder.UseVisualStyleBackColor = true;
            this.but_addfolder.Click += new System.EventHandler(this.but_addfolder_Click);
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox_log.Location = new System.Drawing.Point(3, 621);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.Size = new System.Drawing.Size(935, 67);
            this.richTextBox_log.TabIndex = 11;
            this.richTextBox_log.Text = "";
            // 
            // lbl_change
            // 
            this.lbl_change.AutoSize = true;
            this.lbl_change.Location = new System.Drawing.Point(604, 75);
            this.lbl_change.Name = "lbl_change";
            this.lbl_change.Size = new System.Drawing.Size(46, 15);
            this.lbl_change.TabIndex = 9;
            this.lbl_change.Text = "Запись";
            // 
            // but_c_rm
            // 
            this.but_c_rm.Location = new System.Drawing.Point(667, 42);
            this.but_c_rm.Name = "but_c_rm";
            this.but_c_rm.Size = new System.Drawing.Size(60, 24);
            this.but_c_rm.TabIndex = 8;
            this.but_c_rm.Text = "-";
            this.but_c_rm.UseVisualStyleBackColor = true;
            this.but_c_rm.Click += new System.EventHandler(this.but_c_rm_Click);
            // 
            // but_c_add
            // 
            this.but_c_add.Location = new System.Drawing.Point(604, 42);
            this.but_c_add.Name = "but_c_add";
            this.but_c_add.Size = new System.Drawing.Size(60, 24);
            this.but_c_add.TabIndex = 7;
            this.but_c_add.Text = "+";
            this.but_c_add.UseVisualStyleBackColor = true;
            this.but_c_add.Click += new System.EventHandler(this.but_c_add_Click);
            // 
            // but_r_rm
            // 
            this.but_r_rm.Location = new System.Drawing.Point(329, 42);
            this.but_r_rm.Name = "but_r_rm";
            this.but_r_rm.Size = new System.Drawing.Size(57, 24);
            this.but_r_rm.TabIndex = 6;
            this.but_r_rm.Text = "-";
            this.but_r_rm.UseVisualStyleBackColor = true;
            this.but_r_rm.Click += new System.EventHandler(this.but_r_rm_Click);
            // 
            // lbl_read
            // 
            this.lbl_read.AutoSize = true;
            this.lbl_read.Location = new System.Drawing.Point(265, 75);
            this.lbl_read.Name = "lbl_read";
            this.lbl_read.Size = new System.Drawing.Size(46, 15);
            this.lbl_read.TabIndex = 5;
            this.lbl_read.Text = "Чтение";
            // 
            // but_r_add
            // 
            this.but_r_add.Location = new System.Drawing.Point(266, 42);
            this.but_r_add.Name = "but_r_add";
            this.but_r_add.Size = new System.Drawing.Size(57, 24);
            this.but_r_add.TabIndex = 4;
            this.but_r_add.Text = "+";
            this.but_r_add.UseVisualStyleBackColor = true;
            this.but_r_add.Click += new System.EventHandler(this.but_r_add_Click);
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.Location = new System.Drawing.Point(264, 3);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(0, 15);
            this.lbl_path.TabIndex = 3;
            // 
            // listView_change
            // 
            this.listView_change.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView_change.CheckBoxes = true;
            this.listView_change.FullRowSelect = true;
            this.listView_change.GridLines = true;
            this.listView_change.Location = new System.Drawing.Point(604, 96);
            this.listView_change.Name = "listView_change";
            this.listView_change.Size = new System.Drawing.Size(323, 519);
            this.listView_change.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_change.TabIndex = 2;
            this.listView_change.UseCompatibleStateImageBehavior = false;
            this.listView_change.View = System.Windows.Forms.View.List;
            // 
            // listView_read
            // 
            this.listView_read.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView_read.CheckBoxes = true;
            this.listView_read.FullRowSelect = true;
            this.listView_read.GridLines = true;
            this.listView_read.Location = new System.Drawing.Point(264, 96);
            this.listView_read.Name = "listView_read";
            this.listView_read.Size = new System.Drawing.Size(323, 519);
            this.listView_read.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_read.TabIndex = 1;
            this.listView_read.UseCompatibleStateImageBehavior = false;
            this.listView_read.View = System.Windows.Forms.View.List;
            // 
            // tree_folders
            // 
            this.tree_folders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tree_folders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree_folders.Location = new System.Drawing.Point(0, 75);
            this.tree_folders.Name = "tree_folders";
            this.tree_folders.Size = new System.Drawing.Size(258, 540);
            this.tree_folders.TabIndex = 0;
            this.tree_folders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_folders_AfterSelect);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.butCSV);
            this.tabPage2.Controls.Add(this._dataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(941, 691);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Отчет";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // butCSV
            // 
            this.butCSV.Location = new System.Drawing.Point(6, 6);
            this.butCSV.Name = "butCSV";
            this.butCSV.Size = new System.Drawing.Size(99, 23);
            this.butCSV.TabIndex = 1;
            this.butCSV.Text = "Save to CSV";
            this.butCSV.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butCSV.UseVisualStyleBackColor = true;
            this.butCSV.Click += new System.EventHandler(this.butCSV_Click);
            // 
            // _dataGridView
            // 
            this._dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Location = new System.Drawing.Point(3, 35);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.RowTemplate.Height = 25;
            this._dataGridView.Size = new System.Drawing.Size(802, 608);
            this._dataGridView.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.txt_resource_name);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(941, 691);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CreateResource";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Имя хоста";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(124, 104);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(242, 23);
            this.textBox3.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Путь к директории";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(242, 23);
            this.textBox2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Путь к OU";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 23);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Описание ресурса";
            // 
            // txt_resource_name
            // 
            this.txt_resource_name.Location = new System.Drawing.Point(125, 17);
            this.txt_resource_name.Name = "txt_resource_name";
            this.txt_resource_name.Size = new System.Drawing.Size(242, 23);
            this.txt_resource_name.TabIndex = 3;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 742);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.cmd_Resources);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "M31";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cmd_Resources;
        private TabControl tabs;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListView listView_change;
        private ListView listView_read;
        private Label lbl_path;
        private DataGridView _dataGridView;
        private Button but_r_add;
        private Label lbl_change;
        private Button but_c_rm;
        private Button but_c_add;
        private Button but_r_rm;
        private Label lbl_read;
        private RichTextBox richTextBox_log;
        private Button butCSV;
        private Panel panel1;
        private Button but_delfolder;
        private Button but_addfolder;
        private TextBox txt_foldername;
        private TabPage tabPage3;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private TextBox txt_resource_name;
        public TreeView tree_folders;
    }
}