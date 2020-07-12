using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers.UI_Controllers
{
    public class Menu : MonoBehaviour
    {
        GameObject SettingsWindowObject { get; set; }
        GameObject AuthorsWindowObject { get; set; }
        GameObject ConfirmNewGameObject { get; set; }
        GameObject NewGameWindow { get; set; }
        GameObject ExitMenuObject { get; set; }
        GameObject MainMenuObject { get; set; }


        void Start()
        {
            ExitMenuObject = GameObject.Find("ConfirmExitDialog");
            AuthorsWindowObject = GameObject.Find("AuthorsWindow");
            SettingsWindowObject = GameObject.Find("SettingsWindow");
            NewGameWindow = GameObject.Find("NewGameWindow");
            ConfirmNewGameObject = GameObject.Find("ConfirmNewGameDialog");
            MainMenuObject = GameObject.Find("MainMenu");

            NewGameWindow.SetActive(false);
            ConfirmNewGameObject.SetActive(false);
            AuthorsWindowObject.SetActive(false);
            SettingsWindowObject.SetActive(false);
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
            SettingsWindowObject.SetActive(false);
            MainMenuObject.SetActive(true);
        }
        public void SettingsButton_Click()
        {
            SettingsWindowObject.SetActive(true);
            MainMenuObject.SetActive(false);
        }

        public void AutorsButton_Click()
        {
            AuthorsWindowObject.SetActive(true);
            MainMenuObject.SetActive(false);
        }
        public void AutorsButtonBack_Click()
        {
            AuthorsWindowObject.SetActive(false);
            MainMenuObject.SetActive(false);
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