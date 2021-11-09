using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    public static void Save()
    {
        BinaryFormatter formater = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveFile.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data d = new Data();
        formater.Serialize(stream, d);
        stream.Close();
    }
    public static Data Load()
    {
        string path = Application.persistentDataPath + "/saveFile.fun";
        Data d;
        if (File.Exists(path))
        {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            d = formater.Deserialize(stream) as Data;
            stream.Close();
        }
        else
        {
            d = new Data();
            d.Levels = 1;
            d.Score = 0;
        }
        return d;
    }
    public static void Delete()
    {
        string path = Application.persistentDataPath + "/saveFile.fun";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
