using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.check";
        FileStream stream = new FileStream(path, FileMode.Create);

        Player_data data = new Player_data(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static Player_data LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.check";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player_data data = formatter.Deserialize(stream) as Player_data;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
