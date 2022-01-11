using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName; 
    // Start is called before the first frame update
    void Start()
    {
        if(MainManager.Instance != null)
        {
             inputName.text = MainManager.nameText;
        }

    }

    // Update is called once per frame
    void Update()
    {
        MainManager.nameText = inputName.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1); 
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}
