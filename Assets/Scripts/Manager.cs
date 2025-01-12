using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public string UserName;
    public int HighScore = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    class HighScoreClass
    {
        public int HighScore;
    }
    public void SaveScore()
    {
        HighScoreClass scoreClass = new HighScoreClass();
        scoreClass.HighScore = HighScore;

        string json=JsonUtility.ToJson(scoreClass);
        File.WriteAllText(Application.persistentDataPath+"/savefile.json", json);
    }
    public void LoadScore() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreClass scoreClass=JsonUtility.FromJson<HighScoreClass>(json);   
            HighScore=scoreClass.HighScore;
        }
    }
}
