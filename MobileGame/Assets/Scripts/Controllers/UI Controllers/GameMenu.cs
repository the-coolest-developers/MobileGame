using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers.UI_Controllers
{
    public class GameMenu : MonoBehaviour
    {
        private GameObject SettingsWindowObject { get; set; }
        private GameObject GameMenuObject { get; set; }
        private GameObject InteractiveMenuObject { get; set; }
        private GameObject ExitDialogObject { get; set; }

        private GameObject MenuButtonObject { get; set; }
        private GameObject InteractiveMenuButtonObject { get; set; }
        private GameObject DimmedBackgroundObject { get; set; }

        private void Start()
        {
            SettingsWindowObject = GameObject.Find("SettingsWindow");

            GameMenuObject = GameObject.Find("GameMenu");
            InteractiveMenuObject = GameObject.Find("InteractiveMenu");
            ExitDialogObject = GameObject.Find("ConfirmExitDialog");

            InteractiveMenuButtonObject = GameObject.Find("InteractiveMenuButton");
            MenuButtonObject = GameObject.Find("MenuButton");
            DimmedBackgroundObject = GameObject.Find("DimmedBackground");

            ResetUiLayout();
        }

        private void ResetUiLayout()
        {
            DimmedBackgroundObject.SetActive(false);

            GameMenuObject.SetActive(false);
            SettingsWindowObject.SetActive(false);
            ExitDialogObject.SetActive(false);
            InteractiveMenuObject.SetActive(false);

            MenuButtonObject.SetActive(true);
            InteractiveMenuButtonObject.SetActive(true);
        }

        private void CloseWindowsAndResume()
        {
            ResetUiLayout();

            GameController.ResumeGame();
        }

        private void PauseAndOpenWindow(GameObject window)
        {
            GameController.PauseGame();
            MenuButtonObject.SetActive(false);
            InteractiveMenuButtonObject.SetActive(false);
            DimmedBackgroundObject.SetActive(true);

            window.SetActive(true);
        }

        public void MenuButton_Click()
        {
            PauseAndOpenWindow(GameMenuObject);
        }

        public void InteractiveMenuButton_Click()
        {
            PauseAndOpenWindow(InteractiveMenuObject);
        }

        public void DimmedBackground_Click()
        {
            CloseWindowsAndResume();
        }

        public void ResumeButton_Click()
        {
            CloseWindowsAndResume();
        }

        public void SettingsButton_Click()
        {
            SettingsWindowObject.SetActive(true);
            GameMenuObject.SetActive(false);
        }

        public void ExitButton_Click()
        {
            ExitDialogObject.SetActive(true);
            GameMenuObject.SetActive(false);
        }

        public void ExitSettingsButton_Click()
        {
            SettingsWindowObject.SetActive(false);
            GameMenuObject.SetActive(true);
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
}