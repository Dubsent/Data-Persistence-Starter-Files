using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    
    //Debug.Log(Application.persistentDataPath);
    //C:\Users\***\AppData\LocalLow\DefaultCompany\SimpleBreakout
   
    public void StartGame()
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
        //Somecode for data persistence between sessions
    }

    public void StorePlayerName(string inputName)
    {
        MainManager.Instance.playerName = inputName;
    }
}
