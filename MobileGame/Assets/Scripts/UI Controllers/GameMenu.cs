using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    GameObject Obj;

    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("GameMenu");
        Obj.SetActive(false);
        Obj = GameObject.Find("SettingsCanvas");
        Obj.SetActive(false);
        Obj = GameObject.FindWithTag("ExitToMenu");
        Obj.SetActive(false);
        Obj = GameObject.Find("SettingsCamera");
        Obj.SetActive(false);
    }

    // Update is called once per frame
    public void SetActive(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void SetNotActive(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
