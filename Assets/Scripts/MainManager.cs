using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string playerName;
    public int currentScore;

    public string highScoreName;
    public int highScore;

    private void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    public class SaveData
    {
        public string highScoreName;
        public int highScore;
    }

    public void SaveHighScore(int currentScore, string playerName)
    {
        SaveData data = new SaveData();

        data.highScore = currentScore;
        data.highScoreName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highScoreName = data.highScoreName;
        } else { Debug.Log("Savefile does not exist!"); }
    }
}
