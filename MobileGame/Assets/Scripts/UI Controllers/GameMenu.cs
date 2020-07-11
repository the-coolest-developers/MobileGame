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
    GameObject ExitDialogObject { get; set; }

    GameObject MenuButtonObject { get; set; }
    GameObject DimmedBackgroundObject { get; set; }

    void Start()
    {
        GameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();

        SettingsCanvasObject = GameObject.Find("SettingsCanvas");
        MainCanvasObject = GameObject.Find("Canvas");

        GameMenuObject = GameObject.Find("GameMenu");
        ExitDialogObject = GameObject.Find("ConfirmExitDialog");

        MenuButtonObject = GameObject.Find("MenuButton");
        DimmedBackgroundObject = GameObject.Find("DimmedBackground");

        DimmedBackgroundObject.SetActive(false);
        GameMenuObject.SetActive(false);
        SettingsCanvasObject.SetActive(false);
        ExitDialogObject.SetActive(false);
    }

    public void MenuButton_Click()
    {
        GameController.PauseGame();

        GameMenuObject.SetActive(true);
        MenuButtonObject.SetActive(false);
        DimmedBackgroundObject.SetActive(true);
    }
    public void ResumeButton_Click()
    {
        GameController.ResumeGame();

        GameMenuObject.SetActive(false);
        MenuButtonObject.SetActive(true);
        DimmedBackgroundObject.SetActive(false);
    }
    public void SettingsButton_Click()
    {
        SettingsCanvasObject.SetActive(true);
        MainCanvasObject.SetActive(false);
    }
    public void ExitButton_Click()
    {
        ExitDialogObject.SetActive(true);
        GameMenuObject.SetActive(false);
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
        ExitDialogObject.SetActive(false);
        GameMenuObject.SetActive(true);
    }
}
