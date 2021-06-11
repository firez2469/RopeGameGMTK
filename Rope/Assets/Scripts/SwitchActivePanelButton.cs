using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SwitchActivePanelButton : MonoBehaviour
{
	[SerializeField]
	private GameObject currentPanel;
	[SerializeField]
	private GameObject nextPanel;


	// Start is called before the first frame update
	void Start()
	{
		var button = this.GetComponent<Button>();
		button.onClick.AddListener(this.ButtonClicked);
	}

	// Update is called once per frame
	void ButtonClicked()
	{
		this.currentPanel.SetActive(false);
		this.nextPanel.SetActive(true);
	}
}
