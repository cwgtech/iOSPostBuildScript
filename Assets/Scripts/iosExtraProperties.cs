using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class iosExtraProperties : MonoBehaviour
{

	public bool m_iPad_EnableLandscape;
	public static bool iPadLandscapeEnable;

	private void OnValidate()
	{
		iPadLandscapeEnable = m_iPad_EnableLandscape;
	}
#if !UNITY_EDITOR
	private void Awake()
	{
		iPadLandscapeEnable = m_iPad_EnableLandscape;
		Debug.Log("isiPad:" + isiPad);
		if (isiPad && iPadLandscapeEnable)
		{
			Screen.autorotateToLandscapeLeft = true;
			Screen.autorotateToLandscapeRight = true;
		}
		Debug.Log("Landscape: " + Screen.autorotateToLandscapeLeft);
	}
#endif

	static bool _isiPad = false;
	static bool _iPadTest = false;
	public static bool isiPad
	{
		get
		{
#if UNITY_IOS
			if (!_iPadTest)
			{				string iosDevice = UnityEngine.iOS.Device.generation.ToString();
				Debug.Log("device: " + iosDevice);
				_isiPad = iosDevice.ToLower().Contains("ipad");
			}
			_iPadTest = true;
#endif
			return _isiPad;
		}
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
