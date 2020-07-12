using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers.UI_Controllers
{
    public class Menu : MonoBehaviour
    {
        GameObject MainCanvasObject { get; set; }
        GameObject SettingsCanvasObject { get; set; }
        GameObject AutorsCanvasObject { get; set; }
        GameObject ConfirmNewGameObject { get; set; }
        GameObject NewGameWindow { get; set; }
        GameObject ExitMenuObject { get; set; }
        GameObject MainMenuObject { get; set; }


        void Start()
        {
            MainCanvasObject = GameObject.Find("Canvas");
            ExitMenuObject = GameObject.Find("ConfirmExitDialog");
            AutorsCanvasObject = GameObject.Find("AutorsCanvas");
            SettingsCanvasObject = GameObject.Find("SettingsCanvas");
            NewGameWindow = GameObject.Find("NewGameWindow");
            ConfirmNewGameObject = GameObject.Find("ConfirmNewGameDialog");
            MainMenuObject = GameObject.Find("MainMenu");

            NewGameWindow.SetActive(false);
            ConfirmNewGameObject.SetActive(false);
            AutorsCanvasObject.SetActive(false);
            SettingsCanvasObject.SetActive(false);
            ExitMenuObject.SetActive(false);

            MainMenuObject.SetActive(true);
        }
        public void NewGameButton_Click()
        {
            ConfirmNewGameObject.SetActive(true);
            MainMenuObject.SetActive(false);
        }
        public void ConfirmNewGameButton_Click()
        {
            NewGameWindow.SetActive(true);
            ConfirmNewGameObject.SetActive(false);
        }
        public void CancelNewGameButton_Click()
        {
            ConfirmNewGameObject.SetActive(false);
            MainMenuObject.SetActive(true);
        }
        public void NewGameBackButton()
        {
            NewGameWindow.SetActive(false);

            MainMenuObject.SetActive(true);
        }
        public void ExitSettingsButton_Click()
        {
            SettingsCanvasObject.SetActive(false);
            MainCanvasObject.SetActive(true);
        }
        public void SettingsButton_Click()
        {
            SettingsCanvasObject.SetActive(true);
            MainCanvasObject.SetActive(false);
        }

        public void AutorsButton_Click()
        {
            AutorsCanvasObject.SetActive(true);
            MainCanvasObject.SetActive(false);
        }
        public void AutorsButtonBack_Click()
        {
            AutorsCanvasObject.SetActive(false);
            MainCanvasObject.SetActive(true);
        }
        public void ExitGameButton_Click()
        {
            ExitMenuObject.SetActive(true);
            MainMenuObject.SetActive(false);
        }
        public void ConfirmExitGameButton_Click()
        {
            Application.Quit();
        }
        public void CancelExitGameButton_Click()
        {
            ExitMenuObject.SetActive(false);
            MainMenuObject.SetActive(true);
        }
        public void ContinueButton_Click()
        {
            SceneManager.LoadScene("Village");
        }
    }
}