using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace M31
{
    internal class Tree
    {
        //класс позволяющий заполнять treeview и искать родителей и дочерние ветки
        // в text и name node пишем description
        // в tag пишем guid группы

        public Tree(List<Principal> list_principals, TreeView treefolders, string _ou_path)
        {

            Debug.WriteLine("run tree  for " + _ou_path);

            List<TreeNode> _trees = new List<TreeNode>();
            List<TreeNode> _root_trees = new List<TreeNode>();
            TreeNode _root_treenode = new TreeNode();
            foreach (GroupPrincipal group_principal in list_principals)
            {
                if (group_principal.Description.Count(f => f == '\\') == 1)
                {
                    //нашли корневую ноду. создаем
                    _root_treenode = new TreeNode(group_principal.Description);
                    _root_treenode.Name = group_principal.Description;
                    _root_treenode.Tag = group_principal.Name.Substring(6);
                    _root_trees.Add(_root_treenode);
                }
            }
            //Добавляем
            foreach (TreeNode t in _root_trees)
            {
                if (!treefolders.Nodes.ContainsKey(t.Name))
                {
                    treefolders.Nodes.Add(t);
                }
            }
            bool fl = true; //флаг прекращения перебора
            int n = 1; // количество слешей
            while (fl)
            {
                fl = false;
                foreach (GroupPrincipal g in list_principals)
                {
                    if (g.Description.Count(f => f == '\\') == n)
                    {
                        fl = true;
                        // ===========call ===============
                        _trees = get_child_treenode(list_principals, g.Description, _ou_path);
                        foreach (TreeNode child_treenode in _trees)
                        {
                            //надо найти родительскую ноду
                            string parent_text = child_treenode.Text.Substring(0, child_treenode.Text.LastIndexOf('\\'));
                            TreeNode[] parent_treenodes = treefolders.Nodes.Find(parent_text, true);
                            foreach (TreeNode parent_trenode in parent_treenodes)
                            {
                                if (!parent_trenode.Nodes.ContainsKey(child_treenode.Name))
                                {
                                    //создаем дочернюю ноду
                                    parent_trenode.Nodes.Add(child_treenode);
                                }
                            }
                        }
                    }
                }
                n++;
            }
            treefolders.Sort();

        }
        private List<TreeNode> get_child_treenode(List<Principal> list_principals, string _description, string _ou_path)
        {
            //Возвращаем только дочерние ноды одного уровня
            List<TreeNode> _child_nodes = new List<TreeNode>();
            int n = _description.Count(f => f == '\\');
            foreach (GroupPrincipal group_principal_child in list_principals)
            {
                if (group_principal_child.Description.Contains(_description) & group_principal_child.Description.Count(f => f == '\\') == n + 1)
                {
                    //Debug.WriteLine("ищем дочерние: {0} - {1}\n", group_principal_child.Description,n);

                    TreeNode child_treenode = new TreeNode(group_principal_child.Description);
                    child_treenode.Tag = group_principal_child.Name.Substring(6);
                    child_treenode.Name = (group_principal_child.Description);
                    _child_nodes.Add(child_treenode);
                }
            }
            return _child_nodes;
        }

    }
}
