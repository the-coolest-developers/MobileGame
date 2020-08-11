using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers.UI_Controllers
{
    public class ChooseDifficulty : MonoBehaviour
    {
        private Text DifficultyDescriptionText;

        public void Start()
        {
            DifficultyDescriptionText = GameObject.Find("DifficultyDescriptionText").GetComponent<Text>();
            DifficultyDescriptionText.text = "Описание(Лёгкий уровень)";
        }

        public void EasyButton_Click()
        {
            DifficultyDescriptionText.text = "Описание(Лёгкий уровень)";
        }
        public void MediumButton_Click()
        {
            DifficultyDescriptionText.text = "Описание(Средний уровень)";
        }
        public void HardButton_Click()
        {
            DifficultyDescriptionText.text = "Описание(Сложный уровень)";
        }

        public void DoneButton_Click()
        {
            SceneManager.LoadScene("Village");
        }
    }
}
