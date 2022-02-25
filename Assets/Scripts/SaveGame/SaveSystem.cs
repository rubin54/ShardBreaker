using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    static public SaveSystem instance;

    string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/save.data";

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "/save.data";
    }
    public void SaveGame(Data data)
    {
        FileStream dataStream = new FileStream(filePath, FileMode.Create);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, data);

        dataStream.Close();
    }

    public Data LoadGame()
    {
        if (File.Exists(filePath))
        {
            // File exists
            FileStream dataStream = new FileStream(filePath, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();
            Data data = converter.Deserialize(dataStream) as Data;

            dataStream.Close();
            return data;
        }
        else
        {
            // File does not exist
            Debug.LogError("Save file not found in " + filePath);
            return null;
        }
    }
}
