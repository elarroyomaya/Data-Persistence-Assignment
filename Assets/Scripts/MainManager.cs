using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
    private string playerName;
    private int playerHighScore = 0;
    private PlayerData currentBestScore = new PlayerData();
    private PlayerData newBestScore = new PlayerData();
    public string bestScorePlayer;
    public int bestScore;

    // Define MainManager as a singleton, persist when changing scene
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class PlayerData
    {
        public string savedPlayerName;
        public int savedPlayerHighScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string enteredPlayerName)
    {
        playerName = enteredPlayerName;
    }

    public string GetName()
    {
        return playerName;
    }

    public int UpdateHighScore(int score)
    {
        if (score > playerHighScore)
            playerHighScore = score;
        return playerHighScore;
    }

    private void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            currentBestScore = JsonUtility.FromJson<PlayerData>(jsonData);
        }
        else 
            currentBestScore.savedPlayerHighScore = 0;
    }

    public void UpdateBestScore(int score)
    {
        LoadBestScore();
        if (score > currentBestScore.savedPlayerHighScore)
        {
            newBestScore.savedPlayerName = playerName;
            newBestScore.savedPlayerHighScore = score;
            string jsonData = JsonUtility.ToJson(newBestScore);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
            bestScorePlayer = newBestScore.savedPlayerName;
            bestScore = newBestScore.savedPlayerHighScore;
        }
        else
        {
            bestScorePlayer = currentBestScore.savedPlayerName;
            bestScore = currentBestScore.savedPlayerHighScore;
        }
    }
}
