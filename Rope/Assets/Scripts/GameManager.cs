using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gamePaused = false;
    bool gameInUnPauseState = false;
    public static bool gameOver = false;
    RectTransform[] uiElements;
    public Button resume;
    public Button restart;
    public Button quit;
    public Text keysCollectedText;
    public Image phaseInImage;
    public static string SceneName;
    public static string NextLevel;
    public string scene;
    public string nextLevel;
    private bool startedExit = false;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.SceneName = scene;
        GameManager.NextLevel = nextLevel;
        phaseInImage.gameObject.SetActive(true);
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
        SceneManager.LoadScene("MainMenu");
    }

    public void toNextLevel()
    {
       
            LoadingScene.SlowLoadScene(NextLevel, false, 2);
        
        //LoadingScene.LoadScene(NextLevel);
    }
    public static void RestartLevel()
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
        keysCollectedText.text = KeyScript.KeysCollected.ToString();
        if (GameManager.gameOver&&nextLevel!="End"&&nextLevel!="MainMenu")
        {

            phaseInImage.GetComponent<Animator>().Play("PhaseOut");
            if (!startedExit)
            {

                StartCoroutine(waitForExit());
                startedExit = true;
            }

        }else if(GameManager.gameOver && (nextLevel == "End" || nextLevel == "MainMenu"))
        {
            if (!startedExit)
            {

                StartCoroutine(waitForExit(120f));
                startedExit = true;
            }
        }
        
    }

    IEnumerator waitForExit(float time = 3.5f)
    {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.GetComponent<Animator>().Play("EndCreditsAnim");
        this.nextLevel = "MainMenu";
        yield return new WaitForSeconds(time);
        GameManager.gameOver = false;
        KeyScript.KeysCollected-= KeyScript.KeysCollected;
        this.toNextLevel();
    }
}
