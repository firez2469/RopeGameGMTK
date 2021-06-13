using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitGameButton : MonoBehaviour
{
	[SerializeField]
	private float delay = 0.1f;
	void Start()
	{
		var button = this.GetComponent<Button>();
		button.onClick.AddListener(this.ButtonClicked);
	}

	private void ButtonClicked()
	{
		// quit delayed in order for the sound to finish (somewhat)
		this.StartCoroutine(this.QuitDelayed());
	}
	private IEnumerator QuitDelayed()
	{
		yield return new WaitForSeconds(delay);
        Application.Quit();

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
