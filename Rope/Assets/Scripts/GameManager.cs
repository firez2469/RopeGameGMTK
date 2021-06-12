using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gamePaused = false;
    bool gameInUnPauseState = false;
    public bool gameOver = false;
    RectTransform[] uiElements;
    public Button resume;
    public Button restart;
    public Button quit;
    public string SceneName;
    public string NextLevel;

    // Start is called before the first frame update
    void Start()
    {
        uiElements = (RectTransform[])GameObject.FindObjectsOfType(typeof(RectTransform));
        DisablePause();
        resume.onClick.AddListener(DisablePause);
        restart.onClick.AddListener(RestartLevel);
        quit.onClick.AddListener(QuitToMenu);
    }

    public void EnablePause()
    {
        Time.timeScale = 0;
        foreach (RectTransform element in uiElements)
        {
            if (element.CompareTag("Menu"))
            {
                element.gameObject.SetActive(true);
            }
        }
        gameInUnPauseState = true;
        gamePaused = true;
    }

    public void DisablePause()
    {
        Time.timeScale = 1;
        
        foreach (RectTransform element in uiElements)
        {
            if (element.CompareTag("Menu"))
            {
                element.gameObject.SetActive(false);
            }
        }
        gameInUnPauseState = false;
        gamePaused = false;
    }

    void QuitToMenu()
    {
        LoadingScene.LoadScene("Menu");
    }

    public void toNextLevel()
    {
        LoadingScene.LoadScene(NextLevel);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneName);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            gamePaused = !gamePaused;
            if (gamePaused)
            {
                EnablePause();
            }
            else
            {
                DisablePause();
            }
        }
        
    }
}
