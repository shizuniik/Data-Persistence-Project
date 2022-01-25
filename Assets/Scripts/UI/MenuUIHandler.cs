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
    }

    // Update is called once per frame
    void Update()
    {
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

}
