using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    GameObject NewGame;
    GameObject MainCamera;
    GameObject SecondCamera;
    GameObject SecondCanvas;
    // Start is called before the first frame update
    void Start()
    {
        NewGame = GameObject.FindWithTag("TextN");
        NewGame.gameObject.SetActive(false);
        MainCamera = GameObject.Find("Main Camera");
        SecondCamera = GameObject.Find("SecondCamera");
        SecondCamera.gameObject.SetActive(false);
        SecondCanvas = GameObject.Find("SecCanvas");
        SecondCanvas.gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    
    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SetActive(GameObject NewGame)
    {
        NewGame.gameObject.SetActive(true);
    }

    public void SetNotActive(GameObject NewGame)
    {
        NewGame.gameObject.SetActive(false);
    }
}
