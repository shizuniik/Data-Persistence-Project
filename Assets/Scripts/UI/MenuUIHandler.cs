using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName;
    public TextMeshProUGUI scoreText; 
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance != null)
        {
            inputName.text = MainManager.InputName;

            if (MainManager.BestScoreName != "")
            {
                scoreText.text = "Best Score: " + MainManager.BestScoreName;
            }
        }
        else
        {
            LoadScoreName(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Best Score: " + MainManager.BestScoreName;
    }

    public void StartNew()
    {
        MainManager.InputName = inputName.text;
        SceneManager.LoadScene(1); 
    }

    public void Exit()
    {
        MainManager.Instance.SaveScoreName(); 

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public string BestScoreName;
        public int BestScore;
        public string Name;
    }

    public void LoadScoreName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MainManager.BestScoreName = data.BestScoreName;
            inputName.text = data.Name;
        }
    }

}
