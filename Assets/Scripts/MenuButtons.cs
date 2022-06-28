using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
