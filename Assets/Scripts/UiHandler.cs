using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHandler : MonoBehaviour
{
    [SerializeField]
    TMP_InputField playerName;
    [SerializeField]
    TextMeshProUGUI HighScreText;

    private void Awake()
    {
        if (Manager.Instance != null)
        {
            Manager.Instance.LoadScore();
        }
    }
    void Start()
    {
        // Set the placeholder text initially

        // Add listener for the onEndEdit event
        playerName.onEndEdit.AddListener(SaveName);
        HighScreText.text = "Best Score: "+Manager.Instance.HighScore;
    }

    void SaveName(string name)
    {

        // Assuming you're saving to a Singleton Manager
        if (Manager.Instance != null)
        {
            Manager.Instance.UserName = name;
        }
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
  Application.Quit();
#endif
    }
}
