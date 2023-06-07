using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileSorter
{
    public class FileData
    {
        public string name;
        public string type;
        public string location;
        //public int size;
        public List<string> tags;

        public FileData()
        {
            name = null;
            type = null;
            //size = 0;
            tags = null;
            location = null;
        }

        public FileData(string fileData)
        {
            name = getFileName(fileData);
            type = getFileType(fileData);
            location = fileData;
            tags = new List<string>();
        }

        public string getFileName(string fileData)
        {
            return Path.GetFileNameWithoutExtension(fileData);
        }

        public string getFileType(string fileData)
        {
            return Path.GetExtension(fileData);
        }
        public void AddTag(string tag)
        {
            tags.Add(tag);
        }

        public string Name
        {
            get 
            {
                return name;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
        }
        //public int GetSize()
        //{
        //    return size;
        //}

        public List<string> GetTags()
        {
            return tags;
        }

    }
}
