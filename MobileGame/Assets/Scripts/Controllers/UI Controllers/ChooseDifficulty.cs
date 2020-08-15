using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers.UI_Controllers
{
    public class ChooseDifficulty : MonoBehaviour
    {
        private Text _difficultyDescriptionText;

        public void Start()
        {
            _difficultyDescriptionText = GameObject.Find("DifficultyDescriptionText").GetComponent<Text>();
            _difficultyDescriptionText.text = "Описание(Лёгкий уровень)";
        }

        public void EasyButton_Click()
        {
            _difficultyDescriptionText.text = "Описание(Лёгкий уровень)";
        }
        public void MediumButton_Click()
        {
            _difficultyDescriptionText.text = "Описание(Средний уровень)";
        }
        public void HardButton_Click()
        {
            _difficultyDescriptionText.text = "Описание(Сложный уровень)";
        }

        public void DoneButton_Click()
        {
            SceneManager.LoadScene("Village");
        }
    }
}
