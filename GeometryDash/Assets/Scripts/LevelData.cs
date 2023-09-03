using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using UnityEngine.JSONSerializeModule;
namespace Custom {
public class LevelData {
    public string levelName;
    public int tries;
    public float completion;
    public bool completed;

    public LevelData(string lvlName){   
        levelName = lvlName;
        tries = 0;
        completed = false;
        completion = 0;
    }

    public static void writeData(LevelData data){
        Debug.Log("Writing " + data.levelName);
        Debug.Log("Writing " + JsonUtility.ToJson(data));
        PlayerPrefs.SetString(data.levelName, JsonUtility.ToJson(data));
        PlayerPrefs.Save();
    }

    public static LevelData getData(string lvlName){
        try {
            LevelData data = JsonUtility.FromJson<LevelData>(PlayerPrefs.GetString("" + lvlName));
            Debug.Log("" + data.levelName);
            if (data == null || data.levelName == "") throw new Exception("Can't have that");
            return data;
        } catch (Exception e) {
            return new LevelData(lvlName);
        }
    }

}

}