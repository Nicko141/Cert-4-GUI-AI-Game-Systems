using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save : MonoBehaviour
{
    public string LoadedPlayerName;
    public int LoadedScore;
    public float LoadedPlayTime;
    private void Start()
    {
        //SaveFile();
    }
    public void SaveFile()
    {
        string filePath = Application.persistentDataPath + "/SaveFile.SAV";
        Debug.Log(filePath);
        Debug.Log("Saved");
        FileStream file;
        if(File.Exists(filePath))
        {
            file = File.OpenWrite(filePath);
        }
        else
        {
            file = File.Create(filePath);

        }
        GameData data = new GameData(LoadedScore, LoadedPlayerName, LoadedPlayTime);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
        
    }
    public void LoadFile()
    {
        string filePath = Application.persistentDataPath + "/SaveFile.SAV";
        Debug.Log(filePath);
        Debug.Log("Loaded");
        FileStream file;

        if(File.Exists(filePath))
        {
            file = File.OpenRead(filePath);

        }
        else
        {
            Debug.LogError("Save File is Dead");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();

     LoadedPlayerName = data.PlayerName;
     LoadedScore = data.Score;
     LoadedPlayTime = data.TimePlayed;
    }
}
