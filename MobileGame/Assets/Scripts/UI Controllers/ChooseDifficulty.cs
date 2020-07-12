using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseDifficulty : MonoBehaviour
{
    Text DifficultyDescriptionText;

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
}
