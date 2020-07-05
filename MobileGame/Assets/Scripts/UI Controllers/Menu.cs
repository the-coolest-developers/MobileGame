using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject NewGame;
    public GameObject MainCamera;
    public GameObject SecondCamera;
    public GameObject SecondCanvas;
    public GameObject ThirdCamera;
    public GameObject SettingsCanvas;
    public GameObject FourthCamera;
    public GameObject AutorsCanvas;
    public GameObject ExitGame;

    void Start()
    {
        NewGame.gameObject.SetActive(false);
        SecondCamera.gameObject.SetActive(false);
        SecondCanvas.gameObject.SetActive(false);
        ThirdCamera.gameObject.SetActive(false);
        SettingsCanvas.gameObject.SetActive(false);
        FourthCamera.gameObject.SetActive(false);
        AutorsCanvas.gameObject.SetActive(false);
        ExitGame.gameObject.SetActive(false);
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
        NewGame.gameObject.SetActive(true);
    }

    public void SetNotActive(GameObject NewGame)
    {
        NewGame.gameObject.SetActive(false);
    }
}
