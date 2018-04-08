using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public class iOSPostProcessBuild : MonoBehaviour {

	[PostProcessBuild]
	public static void ChangeXCodePlist(BuildTarget buildTarget, string pathToBuiltProject)
	{
		const string iPadOrientations = "UISupportedInterfaceOrientations~ipad";
		Debug.Log("build target: " + buildTarget);
		Debug.Log("path: " + pathToBuiltProject);
		if (buildTarget==BuildTarget.iOS)
		{
			string plistPath = pathToBuiltProject + "/Info.plist";
			PlistDocument plist = new PlistDocument();
			plist.ReadFromFile(plistPath);
			PlistElementDict root = plist.root;

			if (iosExtraProperties.iPadLandscapeEnable)
			{
				Debug.Log("Adding landscape for iPad");
				PlistElementArray arr = new PlistElementArray();
				arr.AddString("UIInterfaceOrientationPortrait");
				arr.AddString("UIInterfaceOrientationPortraitUpsideDown");
				arr.AddString("UIInterfaceOrientationLandscapeLeft");
				arr.AddString("UIInterfaceOrientationLandscapeRight");
				root[iPadOrientations] = arr;
			}
			else
			{
				Debug.Log("removing iPad entries...");
				root[iPadOrientations] = null;
			}
			plist.WriteToFile(plistPath);
		}
	}


}
