using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public string currentPlayer;
    public int highscore = 5;
    public string bestPlayer = "nobody";


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadStats();
    }
    
    public void EndGame()
    {
        SaveStats();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif


    }
    [System.Serializable]
    class SaveData
    {
        public string saveBest;
        public int saveScore;

    }

    public void SaveStats()
    {
        SaveData data = new SaveData();
        data.saveBest = bestPlayer;
        data.saveScore = highscore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadStats()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayer = data.saveBest;
            highscore = data.saveScore;
        }
    }

}
