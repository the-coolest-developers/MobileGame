using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject gameSettings;
    public GameObject ExitMenu;
    public GameObject SettingsCamera;
    // Start is called before the first frame update
    void Start()
    {
        gameMenu.gameObject.SetActive(false);
        gameSettings.gameObject.SetActive(false);
        ExitMenu.gameObject.SetActive(false);
        SettingsCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SetActive(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    public void SetNotActive(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
