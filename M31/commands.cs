using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace M31
{
    
     public enum _instructions
    {
        create_folder,
        remove_folder,
        add_right,
        remove_right
    }

    public enum _Rights { read, write };
    public class com_create_folder
    {
        public string _instruction { get; set; }
        public string _hostname { get; set; }
        public string _drivepath { get; set; }
        public string _folderpath { get; set; }
        public string _foldername { get; set; }
        public string _ou_path { get; set; }
        public string _UUID { get; set; }
        public string _cusername { get; set; }
        public string _datetime { get; set; }
    }

    public class com_remove_folder
    {
        public string _instruction { get; set; }
        public string _hostname { get; set; }
        public string _drivepath { get; set; }
        public string _folderpath { get; set; }
        public string _foldername { get; set; }
        public string _ou_path { get; set; }
        public string _UUID { get; set; }
        public string _cusername { get; set; }
        public string _datetime { get; set; }
    }

    public class com_add_right
    {
        public string _instruction { get; set; }
        public string _hostname { get; set; }
        public string _groupname { get; set; }
        public string _username { get; set; }
        public string _cusername { get; set; }
        public string _datetime { get; set; }
    }
    public class com_remove_right
    {
        public string _instruction { get; set; }
        public string _hostname { get; set; }
        public string _groupname { get; set; }
        public IList<string>? _username { get; set;}  
        public string _cusername { get; set; }
        public string _datetime { get; set; }
    }
// public string _username { get; set; }
}


