using System;
using System.IO;
using UnityEngine;

public class SaveAndLoadExample : MonoBehaviour
{
    void Start()
    {
        SaveData();
        LoadData();
    }

    void SaveData()
    {
        SaveDataModel model = new SaveDataModel();
        model.playerName = "Levi Buck";
        model.currentHighScore = 12300;
        model.currentPosition = transform.position;

        string json = JsonUtility.ToJson( model );
        File.WriteAllText( Application.persistentDataPath + "/save.json", json );
        Debug.Log( "Writing file to: " + Application.persistentDataPath );
    }

    void LoadData()
    {
        SaveDataModel model = JsonUtility.FromJson<SaveDataModel>( File.ReadAllText( Application.persistentDataPath + "/save.json" ) );
        Debug.Log( model.playerName );
        Debug.Log( model.currentHighScore );
        Debug.Log( model.currentPosition );
    }
}

[Serializable]
public class SaveDataModel
{
    public string playerName;
    public int currentHighScore;
    public Vector3 currentPosition;
}