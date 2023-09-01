using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace M31
{
    public class dt : DataTable
    {
        public dt(string OU_path)
        {
            //DataTable _dt = new DataTable();
            this.TableName = OU_path;
            //Создаем первый столбец
            DataColumn col_1 = new DataColumn();
            col_1.DataType = typeof(string);
            col_1.ColumnName = "Folder Name";
            this.Columns.Add(col_1);
            this.PrimaryKey = new DataColumn[] { this.Columns["Folder Name"] };
            this.DefaultView.Sort = "Folder Name";

            PrincipalContext pc_ou_resources = new PrincipalContext(ContextType.Domain, Properties.Settings.Default.domainname, OU_path);
            GroupPrincipal gp = new GroupPrincipal(pc_ou_resources);
            PrincipalSearcher searcher = new PrincipalSearcher(gp);
            PrincipalSearchResult<Principal> groups = searcher.FindAll();

            //строки - группы - ресурсы
            //столбцы - пользователи - доступ
            //создаем массив столбцов
            List<string> columns = new List<string>();
            List<string> rows = new List<string>();
            foreach (GroupPrincipal group in groups)
            {
                DirectoryEntry gp_de = group.GetUnderlyingObject() as DirectoryEntry;
                var members = gp_de.Properties["member"];
                foreach (string member in members)
                {
                    string strmember = member.Substring(3,member.IndexOf(",")-3);
                    //Debug.WriteLine("member_de {0}", member);
                    if (!columns.Contains(strmember) && !strmember.StartsWith("gss")) 
                    { columns.Add(strmember); }
                }
            }
            columns.Sort();

            //добавляем столбцы
            foreach (string item in columns) { this.Columns.Add(item); }

            //Заполняем массив строки и заполняем их
            foreach (GroupPrincipal group in groups)
            {

                if (!this.Rows.Contains(group.Description))
                {
                    DataRow row = this.NewRow();
                    row[0] = group.Description;
                    this.Rows.Add(row);
                }
                
                    //редактируем строку
                    DirectoryEntry gp_de = group.GetUnderlyingObject() as DirectoryEntry;
                    var members = gp_de.Properties["member"];
                    foreach (string member in members)
                    {
                            string strmember = member.Substring(3, member.IndexOf(",") - 3);
                            //Debug.WriteLine("strmember in group {0} {1} {2}",strmember, group.Name, group.Description);
                            if (!strmember.StartsWith("gss"))
                            {
                                this.Rows.Find(group.Description)[strmember] = group.Name.Substring(4, 1).ToUpper();
                        //this.Rows.Find(group.Description)[strmember] + group.Name.Substring(4, 1);
                            }
                    }

            }

        }
        public string ToCSV()
        {
            //
            StringBuilder strb = new StringBuilder();
            //columns
            strb.AppendLine(string.Join(",", this.Columns.Cast<DataColumn>().Select(s => "\"" + s.ColumnName + "\"")));
            //rows
            this.AsEnumerable().Select(s => strb.AppendLine(string.Join(",", s.ItemArray.Select(i => "\"" + i.ToString() + "\"")))).ToList();
            return strb.ToString();
        }
    }
}
