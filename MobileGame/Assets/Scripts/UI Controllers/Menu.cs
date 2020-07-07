using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //GameObject MainCamera;
    GameObject Obj;


    void Start()
    {
        Obj = GameObject.Find("NGText");
        Obj.SetActive(false);
        Obj = GameObject.Find("SecondCamera");
        Obj.SetActive(false);
        Obj = GameObject.Find("NGCanvas");
        Obj.SetActive(false);
        Obj = GameObject.Find("ThirdCamera");
        Obj.SetActive(false);
        Obj = GameObject.Find("SettingsCanvas");
        Obj.SetActive(false);
        Obj = GameObject.Find("FourthCamera");
        Obj.SetActive(false);
        Obj = GameObject.Find("AutorsCanvas");
        Obj.SetActive(false);
        Obj = GameObject.FindWithTag("ExitGame");
        Obj.SetActive(false);
    }
    
    public void doExitGame()
    {
        Application.Quit();
    }
    
    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SetActive(GameObject NewGame)
    {
        NewGame.SetActive(true);
    }

    public void SetNotActive(GameObject NewGame)
    {
        NewGame.SetActive(false);
    }
}
