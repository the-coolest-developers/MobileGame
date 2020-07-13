using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers.UI_Controllers
{
    public class GameMenu : MonoBehaviour
    {
        GameController GameController { get; set; }

        GameObject SettingsWindowObject { get; set; }
        GameObject GameMenuObject { get; set; }
        GameObject ExitDialogObject { get; set; }

        GameObject MenuButtonObject { get; set; }
        GameObject DimmedBackgroundObject { get; set; }

        void Start()
        {
            GameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();

            SettingsWindowObject = GameObject.Find("SettingsWindow");

            GameMenuObject = GameObject.Find("GameMenu");
            ExitDialogObject = GameObject.Find("ConfirmExitDialog");

            MenuButtonObject = GameObject.Find("MenuButton");
            DimmedBackgroundObject = GameObject.Find("DimmedBackground");

            DimmedBackgroundObject.SetActive(false);
            GameMenuObject.SetActive(false);
            SettingsWindowObject.SetActive(false);
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