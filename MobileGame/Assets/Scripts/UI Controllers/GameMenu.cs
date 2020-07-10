using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    GameController GameController { get; set; }

    GameObject MainCanvasObject { get; set; }
    GameObject SettingsCanvasObject { get; set; }
    GameObject GameMenuObject { get; set; }
    GameObject ExitMenuObject { get; set; }

    void Start()
    {
        GameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();

        SettingsCanvasObject = GameObject.Find("SettingsCanvas");
        MainCanvasObject = GameObject.Find("Canvas");

        GameMenuObject = GameObject.Find("GameMenu");
        ExitMenuObject = GameObject.Find("ConfirmExitMenu");

        GameMenuObject.SetActive(false);
        SettingsCanvasObject.SetActive(false);
        ExitMenuObject.SetActive(false);
    }

    public void MenuButton_Click()
    {
        GameMenuObject.SetActive(true);
        GameController.PauseGame();
    }
    public void ResumeButton_Click()
    {
        GameMenuObject.SetActive(false);
        GameController.ResumeGame();
    }
    public void SettingsButton_Click()
    {
        SettingsCanvasObject.SetActive(true);
        MainCanvasObject.SetActive(false);
    }
    public void ExitButton_Click()
    {
        ExitMenuObject.SetActive(true);
    }
    public void ExitSettingsButton_Click()
    {
        SettingsCanvasObject.SetActive(false);
        MainCanvasObject.SetActive(true);
    }
    public void ConfirmExitButton_Click()
    {
        SceneManager.LoadScene("Menu");
    }
    public void CancelExitButton_Click()
    {
        ExitMenuObject.SetActive(false);
    }
}
