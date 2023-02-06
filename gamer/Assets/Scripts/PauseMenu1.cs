using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.name);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }

    }


    public void pause()
    {
        if (Time.timeScale > 0)
            {
                //freeze time, menu appear;
                Time.timeScale = 0;
                GetComponent<Canvas>().enabled = true;
            }
        else
        {
            Resume();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void Customize()
    {
        GetComponent<Canvas>().enabled = false;
        
    }
}
