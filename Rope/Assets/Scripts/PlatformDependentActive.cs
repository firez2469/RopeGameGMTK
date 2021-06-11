using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDependentActive : MonoBehaviour
{
	[SerializeField]
	private bool disableInWebGL;
	[SerializeField]
	private bool disableOnStandalone;
	[SerializeField]
	private bool overrideEditorBehavior;
	[SerializeField]
	private bool disableInEditor;


	// Start is called before the first frame update
	void Awake()
	{
#if UNITY_EDITOR
		if (this.overrideEditorBehavior)
		{
			if (this.disableInEditor)
			{
				this.gameObject.SetActive(false);
			}
		}
		else
		{
			this.ApplyForTargetPlatform();
		}
#else
		this.ApplyForTargetPlatform();
#endif
	}

	private void ApplyForTargetPlatform()
	{
#if UNITY_WEBGL
		if (this.disableInWebGL)
		{
			this.gameObject.SetActive(false);
		}
#endif
#if UNITY_STANDALONE
		if (this.disableOnStandalone)
		{
			this.gameObject.SetActive(false);
		}
#endif
	}

	// Update is called once per frame
	void Update()
	{

	}
}
