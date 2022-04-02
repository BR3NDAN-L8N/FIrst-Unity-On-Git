using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance; // Instance is the Singleton
    public Color TeamColor;

    private void Awake()
    {
        // this if-statement stops duplicate gameObjects being saved
        // when go from any scene back to the scene that intitialized this
        if (Instance != null)  // if Instance was already set,
        {
            Destroy(gameObject); // destroy this new classes instance
            return; // exit method
        }

        // set this.gameObject
        Instance = this;

        // after starting app, a new folder in Heirarcy
        // will be created and hold the gameObject (this)
        // that was passed in as a param. 
        DontDestroyOnLoad(gameObject);

        // data needs to be loaded from here and not the load-button on the menu?
        LoadColor();
    }

    // Why create another class to save data, as oppose to just saving this MainManager class?
    // Saving just a small class is more efficient.
    // this may also make saving lists, arrays, and dictionaries possible?
    [Serializable]  // this lets the JSON util know to save this shit
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData(); // create instance of SaveData
        data.TeamColor = TeamColor;       // set the TeamColor variable

        string json = JsonUtility.ToJson(data);  // converti SaveData instance to JSON

        // Application.persistentDataPath == where all persistent data is stored by Unity
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);  // Create a JSON file and add the new JSON object
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json"; // grab the data from Unity's persitent stuff
        if (File.Exists(path))  // if a file exists (as in was saved previously)
        {
            string json = File.ReadAllText(path);  // copy the text to a local var
            SaveData data = JsonUtility.FromJson<SaveData>(json); // convert stringified json to Class

            TeamColor = data.TeamColor;  // set the TeamColor to the value we had previously saved.
        }
    }

}
