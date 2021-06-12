using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
	// It's assumed that this scene is configured in the player settings.
	private const string LoadingSceneName = "LoadingScene";


	public static void LoadScene(string sceneName, bool skipLoadingScene = false)
	{
		if (!skipLoadingScene)
		{
			new GameObject("SceneLoadRequest-" + sceneName).AddComponent<LoadingScene>().ExecuteLoadRequest(sceneName);
		}
		else
		{
			Debug.LogFormat("SceneLodaer: loading requested scene {0} directly...", sceneName);
			SceneManager.LoadScene(sceneName);

			Debug.LogFormat("SceneLodaer: loading of scene {0} finished.", sceneName);
		}
	}

    public static void SlowLoadScene(string sceneName, bool skipLoadingScene = false,float loadMinTime = 5)
    {
        if (!skipLoadingScene)
        {
            new GameObject("SceneLoadRequest-" + sceneName).AddComponent<LoadingScene>().ExecuteDelayedLoadRequest(sceneName,loadMinTime);
        }
        else
        {
            Debug.LogFormat("SceneLodaer: loading requested scene {0} directly...", sceneName);
            SceneManager.LoadScene(sceneName);

            Debug.LogFormat("SceneLodaer: loading of scene {0} finished.", sceneName);
        }
    }

	private void ExecuteLoadRequest(string sceneName)
	{
		Object.DontDestroyOnLoad(this.gameObject);
		this.StartCoroutine(this.ExecuteLoadRequestCoroutine(sceneName));
	}
    private void ExecuteDelayedLoadRequest(string sceneName, float time)
    {
        Object.DontDestroyOnLoad(this.gameObject);
        this.StartCoroutine(this.ExecuteDelayedLoadRequestCoroutine(sceneName, time));
    }

	private IEnumerator ExecuteLoadRequestCoroutine(string sceneName)
	{
		Debug.LogFormat("SceneLodaer: scene load requested for {0}, opening loading scene...", sceneName);
		SceneManager.LoadScene(LoadingSceneName);

		yield return new WaitForSeconds(0.1f);
		Debug.LogFormat("SceneLodaer: loading requested scene {0}...", sceneName);
		yield return SceneManager.LoadSceneAsync(sceneName);

		Debug.LogFormat("SceneLodaer: loading of scene {0} finished.", sceneName);
		Object.Destroy(this.gameObject);
	}

    private IEnumerator ExecuteDelayedLoadRequestCoroutine(string sceneName,float time)
    {
        Debug.LogFormat("SceneLodaer: scene load requested for {0}, opening loading scene...", sceneName);
        SceneManager.LoadScene(LoadingSceneName);

        yield return new WaitForSeconds(time);
        Debug.LogFormat("SceneLodaer: loading requested scene {0}...", sceneName);
        yield return SceneManager.LoadSceneAsync(sceneName);

        Debug.LogFormat("SceneLodaer: loading of scene {0} finished.", sceneName);
        Object.Destroy(this.gameObject);
    }
}
