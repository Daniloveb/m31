using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Diagnostics;
using System.DirectoryServices;
using System.Security.Principal;
using Tulpep.ActiveDirectoryObjectPicker;
using Renci.SshNet;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Diagnostics.Metrics;


namespace M31
{
    public partial class mainForm : Form
    {
        private string cusername { get; set; }
        public string ou_path { get; set; }
        public string selected_matrix { get; set; }
        private string ansiblehost { get; set; }
        private string ansible_file_in_path { get; set; }
        private string ansible_local_user { get; set; }
        private string ansible_local_user_pass { get; set; }
        private string domainname { get; set; }
        private string hostname { get; set; }
        private string drivepath { get; set; }
        private dt matrix_dt { get; set; }
      

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            selected_matrix = "";
            ansiblehost = Properties.Settings.Default.ansiblehost;
            ansible_file_in_path = Properties.Settings.Default.ansible_file_in_path;
            domainname = Properties.Settings.Default.domainname;
            ansible_local_user = Properties.Settings.Default.ansible_local_user;
            ansible_local_user_pass = Properties.Settings.Default.ansible_local_user_pass;

            //hostname_for_ad_actions = "vmanagement";

            PrincipalContext pc = new PrincipalContext(ContextType.Domain, Environment.UserDomainName);
            UserPrincipal up_cur = UserPrincipal.FindByIdentity(pc, WindowsIdentity.GetCurrent().Name);
            cusername = WindowsIdentity.GetCurrent().Name;

            PrincipalContext pc_ou_resources = new PrincipalContext(ContextType.Domain, domainname, Properties.Settings.Default.ou_resources);
            PrincipalContext pc_ou_admin_groups = new PrincipalContext(ContextType.Domain, domainname, Properties.Settings.Default.ou_admin_groups);
            GroupPrincipal Admin_gp = GroupPrincipal.FindByIdentity(pc_ou_admin_groups, "gaa_fullAdmins");
            // удаляем админcкий tab
            if (!up_cur.IsMemberOf(Admin_gp))
            {
                this.tabs.TabPages.Remove(tabPage3);
            }
            //Выбираем группы в которые есть доступ и добавляем в cmd_resources
            GroupPrincipal gp = new GroupPrincipal(pc_ou_resources);
            PrincipalSearcher searcher = new PrincipalSearcher(gp);
            PrincipalSearchResult<Principal> groups = searcher.FindAll();
            foreach (GroupPrincipal item in groups)
            {
                if (up_cur.IsMemberOf(item) || up_cur.IsMemberOf(Admin_gp))
                {
                    cmd_Resources.Items.Add(item);
                    //cmd_Resources.SelectedIndex = 0;
                }
            }
            if (cmd_Resources.Items.Count == 1)
            {
                GroupPrincipal select_gp = (GroupPrincipal)cmd_Resources.SelectedItem;
                working_with_selected_group(select_gp);
            }

            cmd_Resources.DisplayMember = "Description";
            cmd_Resources.SelectedIndex = 0;
        }

        //Проверки и сборка дерева
        public void working_with_selected_group(GroupPrincipal select_gp)
        {
            tree_folders.Nodes.Clear();
            this.listView_change.Items.Clear();
            this.listView_read.Items.Clear();

            DirectoryEntry select_de = select_gp.GetUnderlyingObject() as DirectoryEntry;
            ou_path = select_de.Properties["Info"].Value.ToString();
            if (ou_path == null)
            {
                MessageBox.Show("Описание группы не заполнено! " + select_de.Name, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DirectoryEntry OU_entry = null;
            //check exist OU
            if (DirectoryEntry.Exists("LDAP://" + ou_path))
            {
                OU_entry = new DirectoryEntry("LDAP://" + ou_path);
            }
            else
            {
                MessageBox.Show("OU ресурса не найдено! " + ou_path, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
             
            //Читаем аттрибуты ресурсного OU
            if (OU_entry.Properties["l"].Value is null || OU_entry.Properties["street"].Value is null)
            {
                MessageBox.Show("Не заполнены свойства OU ресурса! " + select_de.Name, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //string str_descr = OU_entry.Properties["Description"].Value.ToString();
            hostname = OU_entry.Properties["l"].Value.ToString();
            drivepath = OU_entry.Properties["street"].Value.ToString();
            

            PrincipalContext pc_ou_otdel = new PrincipalContext(ContextType.Domain, domainname, ou_path);
            GroupPrincipal gp_ou_otdel = new GroupPrincipal(pc_ou_otdel);
            PrincipalSearcher searcher_ou_otdel = new PrincipalSearcher(gp_ou_otdel);
            //Выбираем все группы в OU
            PrincipalSearchResult<Principal> groups_ou_otdel = searcher_ou_otdel.FindAll();
            List<Principal> groups_list = new List<Principal>();
            foreach (GroupPrincipal item in groups_ou_otdel)
            {
                if (item.Description is null)
                {
                    MessageBox.Show("Описание группы не заполнено! " + item.Name, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //Debug.WriteLine(item.Name);
                groups_list.Add(item);
            }
            Tree treeset = new Tree(groups_list, tree_folders, ou_path);
        }

        //Выбираем группу в OU Webadmin/Admin и заполняем дерево директорий
        public void cmd_Resources_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupPrincipal select_gp = (GroupPrincipal)cmd_Resources.SelectedItem;
            working_with_selected_group(select_gp);

            if (tabs.SelectedIndex == 1)
            {
                if (selected_matrix != ou_path)
                {
                    //собираем матрицу
                    //ds matrix_ds = new ds(ou_path);
                    dt matrix_dt = new dt(ou_path);
                    _dataGridView.DataSource = matrix_dt;
                    _dataGridView.Columns["Folder Name"].Frozen = true;
                    _dataGridView.Refresh();
                    selected_matrix = ou_path;
                }
            }

            this.lbl_path.Text = "";

        }

        //При выборе директории в дереве - заполняем списки доступа
        private void tree_folders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView_read.Items.Clear();
            var pc_ou_resources = new PrincipalContext(ContextType.Domain, domainname, ou_path);
            GroupPrincipal gp_r = GroupPrincipal.FindByIdentity(pc_ou_resources, "gss_r_" + this.tree_folders.SelectedNode.Tag);
            // надо исключить выключенных пользователей
            if (gp_r != null)
            {
                try
                {
                    foreach (Principal item in gp_r.GetMembers())
                    {
                        ListViewItem newItem = new ListViewItem(item.Name);
                        newItem.Name = item.SamAccountName.ToString();
                        listView_read.Items.Add(newItem);
                    }
                }
                catch(Exception ex)
                {
                    //В случае отключенных пользователей - добавляем из через DirectoryEntry
                    if (ex.InnerException.Message == "Такой объект на сервере отсутствует.")
                    {
                        listView_read.Items.Clear();
                        DirectoryEntry gp_r_de = gp_r.GetUnderlyingObject() as DirectoryEntry;
                        var members = gp_r_de.Properties["member"];
                        foreach (string member in members)
                        {
                            if (!member.Contains("Отключенные"))
                            {
                                DirectoryEntry member_de = new DirectoryEntry($"LDAP://{member}");
                                //Debug.WriteLine(member_de.Properties["Name"].Value.ToString());
                                ListViewItem newItem = new ListViewItem(member_de.Properties["Name"].Value.ToString());
                                newItem.Name = member_de.Properties["sAMAccountName"].Value.ToString();
                                listView_read.Items.Add(newItem);
                            }
                        }
                     }
                }
            }

            listView_change.Items.Clear();
            GroupPrincipal gp_c = GroupPrincipal.FindByIdentity(pc_ou_resources, "gss_c_" + this.tree_folders.SelectedNode.Tag);

            if (gp_c != null) //&& gp_c.Members.Count > 0)
            {
                try
                {
                    foreach (Principal item in gp_c.GetMembers())
                    {
                        ListViewItem newItem = new ListViewItem(item.Name);
                        newItem.Name = item.SamAccountName.ToString();
                        listView_change.Items.Add(newItem);
                    }
                }
                catch(Exception ex)
                {
                    //В случае отключенных пользователей - добавляем из через DirectoryEntry
                    if (ex.InnerException.Message == "Такой объект на сервере отсутствует.")
                    {
                        listView_change.Items.Clear();
                        DirectoryEntry gp_c_de = gp_c.GetUnderlyingObject() as DirectoryEntry;
                        var members = gp_c_de.Properties["member"];
                        if (gp_c != null)
                        {
                            foreach (string member in members)
                            {
                                if (!member.Contains("Отключенные"))
                                {
                                    DirectoryEntry member_de = new DirectoryEntry($"LDAP://{member}");
                                    ListViewItem newItem = new ListViewItem(member_de.Properties["Name"].Value.ToString());
                                    newItem.Name = member_de.Properties["sAMAccountName"].Value.ToString();
                                    listView_change.Items.Add(newItem);
                                }
                            }
                        }
                        Debug.WriteLine("Отключенный пользователь {0},item.Name");
                    }
                }
            }
            lbl_path.Text = this.tree_folders.SelectedNode.Text;
            
        }

        private void tabs_Selected(object sender, TabControlEventArgs e)
        {
            if (selected_matrix != ou_path)
            {
                //собираем матрицу
                //ds matrix_ds = new ds(ou_path);
                matrix_dt = new dt(ou_path);
                _dataGridView.DataSource = matrix_dt;
                _dataGridView.Columns["Folder Name"].Frozen = true;
                _dataGridView.Refresh();
                selected_matrix = ou_path;
            }
        }

        private void but_r_add_Click(object sender, EventArgs e)
        {
            if (this.tree_folders.SelectedNode is null)
            {
                MessageBox.Show("Выберите директорию!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string groupname = "gss_r_" + this.tree_folders.SelectedNode.Tag;
            add_right_query(groupname);
        }

        private void but_addfolder_Click(object sender, EventArgs e)
        {
            if (this.txt_foldername.Text == "Введите имя папки" || this.txt_foldername.Text == "")
            {
                MessageBox.Show("Введите имя создаваемой папки!", "Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
       
            //Если корневых папок нет. Или она не выбрана...
            string folderpath = "";
            if (this.tree_folders.SelectedNode is not null)
            {

                if (this.tree_folders.SelectedNode.Text == "\\." || this.tree_folders.SelectedNode.Text == "\\")
                {
                    folderpath = "";
                }
                else
                {
                    folderpath = this.tree_folders.SelectedNode.Text;
                }
            }
            
            if ( MessageBox.Show("Создаем папку " + folderpath + "\\" +  this.txt_foldername.Text + " ?", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var com_create_folder = new com_create_folder
                {
                    _instruction = "create_folder",
                    _hostname = hostname,     // description OU
                    _drivepath = drivepath,   // description OU
                    _folderpath = folderpath,   // дерево - description группы
                    _foldername = this.txt_foldername.Text,   
                    _ou_path = ou_path,           // info WebAdmin group
                    _UUID = Guid.NewGuid().ToString(),
                    _cusername = cusername,
                    _datetime = DateTime.Now.ToString()
                };
                var _options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string jsonString = JsonSerializer.Serialize(com_create_folder, _options);

                //send data
                ssh_connection(jsonString);

                this.txt_foldername.Text = "";
            }
        }

        private void ssh_connection(string jsonString)
        {
            var connectionInfo = new ConnectionInfo(ansiblehost, ansible_local_user, new PasswordAuthenticationMethod(ansible_local_user, ansible_local_user_pass));
            using (var ssh_client = new SftpClient(connectionInfo))
            {
                ssh_client.Connect();

                ssh_client.WriteAllText(ansible_file_in_path + Guid.NewGuid().ToString(), jsonString);
                ssh_client.Disconnect();
            }
        }

        private void but_delfolder_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Удаляем папку " + folderpath + "\\" + this.txt_foldername.Text + " ?", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
            //    var com_create_folder = new com_create_folder
            //    {
            //        _instruction = "create_folder",
            //        _hostname = hostname,     // description OU
            //        _drivepath = drivepath,   // description OU
            //        _folderpath = folderpath,   // дерево - description группы
            //        _foldername = this.txt_foldername.Text,
            //        _ou_path = ou_path,           // info WebAdmin group
            //        _UUID = Guid.NewGuid().ToString(),
            //        _cusername = cusername,
            //        _datetime = DateTime.Now.ToString()
            //    };
            //    var _options = new JsonSerializerOptions
            //    {
            //        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            //        WriteIndented = true
            //    };
            //    string jsonString = JsonSerializer.Serialize(com_create_folder, _options);

            //    //send data
            //    ssh_connection(jsonString);
            //}
        }

        private void add_right_query(string groupname)
        {
            if (hostname is null)
            {
                MessageBox.Show("Error! hostname is null!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string username;
            var picker = new DirectoryObjectPickerDialog
            {
                AllowedObjectTypes = ObjectTypes.Users | ObjectTypes.Groups,
                DefaultObjectTypes = ObjectTypes.Users | ObjectTypes.Groups,
                AllowedLocations = Locations.All,
                DefaultLocations = Locations.JoinedDomain,
                MultiSelect = true,
            };
            using (picker)
            {
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    foreach (DirectoryObject sel in picker.SelectedObjects)
                    {
                        if (sel.SchemaClassName == "group")
                        {
                            username = sel.Name;
                        }
                        else
                        {
                            username = sel.Upn.Substring(0, sel.Upn.IndexOf('@'));
                        }

                        //Добавляем строку в listview
                        ListViewItem newItem = new ListViewItem(sel.Name);
                        newItem.Name = sel.Name;
                        if (groupname.Substring(4, 1) == "r")
                        {
                            listView_read.Items.Add(newItem);
                        }
                        else if (groupname.Substring(4, 1) == "c")
                        {
                            listView_change.Items.Add(newItem);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка. Неправильное имя группы!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var com_add_right = new com_add_right
                        {
                            _instruction = _instructions.add_right.ToString(),
                            _hostname = hostname,     // description OU
                            _groupname = groupname,
                            _username = username,
                            _cusername = cusername,
                            _datetime = DateTime.Now.ToString()
                        };
                        var _options = new JsonSerializerOptions
                        {
                            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                            WriteIndented = true
                        };
                        string jsonString = JsonSerializer.Serialize(com_add_right, _options);
                        //send data
                        ssh_connection(jsonString);

                    }
                }
            }
        }

        private void but_c_add_Click(object sender, EventArgs e)
        {
            if (this.tree_folders.SelectedNode is null)
            {
                MessageBox.Show("Выберите директорию!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string groupname = "gss_c_" + this.tree_folders.SelectedNode.Tag;
            add_right_query(groupname);
        }

        private void txt_foldername_Click(object sender, EventArgs e)
        {
            this.txt_foldername.Text = "";
        }

        private void but_r_rm_Click(object sender, EventArgs e)
        {

            if (this.tree_folders.SelectedNode is null)
            {
                MessageBox.Show("Выберите директорию!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.listView_read.CheckedItems.Count == 0)
            {
                MessageBox.Show("Нет выбранных пользователей!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string groupname = "gss_r_" + this.tree_folders.SelectedNode.Tag;
            remove_right_query(groupname, true);
        }

        private void but_c_rm_Click(object sender, EventArgs e)
        {
            if (this.tree_folders.SelectedNode is null)
            {
                MessageBox.Show("Выберите директорию!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.listView_change.CheckedItems.Count == 0)
            {
                MessageBox.Show("Нет выбранных пользователей!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string groupname = "gss_c_" + this.tree_folders.SelectedNode.Tag;
            remove_right_query(groupname, false);

        }

        private void remove_right_query(string groupname, bool bool_read)
        {
            List<string> list_users = new List<string>();
            if (bool_read)
            {
                foreach (ListViewItem item in this.listView_read.CheckedItems) { list_users.Add(item.Name); }
            }
            else
            {
                foreach (ListViewItem item in this.listView_change.CheckedItems) { 
                    list_users.Add(item.Name);
                }
            }

            if (MessageBox.Show("Удаляем доступ у " + string.Join(",", list_users) + " ?", "Внимание!", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            var com_remove_right = new com_remove_right
            {
                _instruction = _instructions.remove_right.ToString(),
                _hostname = hostname,     // description OU
                _groupname = groupname,
                _username = list_users,
                _cusername = cusername,
                _datetime = DateTime.Now.ToString()
            };
            var _options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(com_remove_right, _options);

            //MessageBox.Show(jsonString);
            //send data
            ssh_connection(jsonString);
        }

        
        private void butCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogbox = new SaveFileDialog();
            dialogbox.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            dialogbox.Title = "Save csv file";
            if (dialogbox.ShowDialog() == DialogResult.OK)
            {
                string csv = matrix_dt.ToCSV();
                Debug.WriteLine(dialogbox.FileName);
                File.WriteAllText(dialogbox.FileName, csv);
            }

        }
    }
}