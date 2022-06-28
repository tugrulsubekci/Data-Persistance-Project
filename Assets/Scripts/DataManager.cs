using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string newPlayerName;
    public int highScore;
    public TextMeshProUGUI bestScoreText;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Load();
        bestScoreText.text = $"Best Score : {playerName} : {highScore}";

    }

    // Update is called once per frame
    void Update()
    {

    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bestscorefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/bestscorefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highScore = data.highScore;
        }
    }
}
