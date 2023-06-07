using System;
using System.Collections.Generic;
using System.IO;

namespace FileSorter {
public class FileData
{
    public string name;

    public string type;
    public string location;
    public int size;
    public List<string> tags;

    public FileData() 
    {
        name = null;
        type = null;
        size = null;
        tags = null;
        location = null;
    }

    public FileData(string _name, string _type, string _location, int _size)
    {
        name = _name;
        type = _type;
        location = _location;
        size = _size;
        tags = null;
    }

    public void AddTag(string tag)
    {
        tags.Add(tag);
    }

    public string GetName()
    {
        return name;
    }
    public string GetType()
    {
        return type;
    }
    public int GetSize()
    {
        return size;
    }

    public List<string> GetTags() 
    {
        return tags;
    }

}
}