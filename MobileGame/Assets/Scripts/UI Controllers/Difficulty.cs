using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Difficulty : MonoBehaviour
{
    // Start is called before the first frame update
    public Text diff;

    public void InputLevel(GameObject button)
    {
        if (button.gameObject.name == "ButEasy")
            diff.text = "Описание(Легкий уровень)";
        if (button.gameObject.name == "ButMiddle")
            diff.text = "Описание(Средний уровень)";
        if (button.gameObject.name == "ButHard")
            diff.text = "Описание(Сложный уровень)";
    }
}
