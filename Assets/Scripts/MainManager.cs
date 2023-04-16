using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
    private string playerName;

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
        public string playerName;
        public string playerHigherScore;
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

}
