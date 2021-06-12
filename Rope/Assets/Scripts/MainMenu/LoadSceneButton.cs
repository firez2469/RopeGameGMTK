using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadSceneButton : MonoBehaviour
{
	[SerializeField]
	private string sceneName;
	[SerializeField]
	private bool skipLoadingScene;
    [SerializeField]
    private float customMinLoadTime = -1;

	void Start()
	{
		var button = this.GetComponent<Button>();
		button.onClick.AddListener(this.ButtonClicked);
	}

	private void ButtonClicked()
	{
        if (customMinLoadTime < 0)
        {
            LoadingScene.LoadScene(this.sceneName, this.skipLoadingScene);
        }
        else
        {
            LoadingScene.SlowLoadScene(this.sceneName, this.skipLoadingScene, customMinLoadTime);
        }
		
	}
}
