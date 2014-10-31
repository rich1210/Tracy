using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.IO;
using System.Reflection;

/// <summary>
/// Uni2Eclipse Version 1.2 
/// </summary>
public class Uni2Eclipse : EditorWindow
{

	string projectCurrentDir = Directory.GetCurrentDirectory ();
	bool showErrorMsg = false;
	string androidProjDir = Directory.GetCurrentDirectory () + Path.DirectorySeparatorChar + "AndroidAPP";
	string buttonTxt = "Create Android Application";
	string graphicLevel;
	string cleanProductName;



	[MenuItem("Window/Uni2LWP/Create Android Application", false)]
	static void Init ()
	{
		//Clear Console Logs
		ClearLog ();
		
		
		string pathToStgArea = Directory.GetCurrentDirectory () + Path.DirectorySeparatorChar + "Temp" + Path.DirectorySeparatorChar + "StagingArea";
		if (!Directory.Exists (pathToStgArea + Path.DirectorySeparatorChar + "assets")) {
			Debug.LogError ("Staging Area not found. Build Staging Area first in File -> Build Settings -> Build");
		} else {
			
			Uni2Eclipse myMenuWindow = (Uni2Eclipse)EditorWindow.GetWindow (typeof(Uni2Eclipse), true, "Uni2Eclipse - Create Android Applications with Unity", true);
			myMenuWindow.minSize = new Vector2 (500, 250);
			myMenuWindow.Show ();
		}
	}


	public static void ClearLog ()
	{
		Assembly assembly = Assembly.GetAssembly (typeof(SceneView));
		Type type = assembly.GetType ("UnityEditorInternal.LogEntries");
		MethodInfo method = type.GetMethod ("Clear");
		method.Invoke (new object (), null);
	}


	void OnGUI ()
	{
		
		//remove special chars from product name
		cleanProductName = RemoveReservedCharacters(PlayerSettings.productName);
		
		
		#if UNITY_3_4 || UNITY_3_5
		graphicLevel = PlayerSettings.Android.targetGraphics.ToString ();
		#endif
		
		#if UNITY_4_0 || UNITY_4_1
		graphicLevel = PlayerSettings.targetGlesGraphics.ToString ();
		#endif
		
		
		string minSDK = PlayerSettings.Android.minSdkVersion.ToString ();
		
		
		
		if (!showErrorMsg) {
			
			if (Directory.Exists (androidProjDir))
				buttonTxt = "Update Android Application";
			else
				buttonTxt = "Create Android Application";
			
		} else {
			
			GUI.enabled = false;
			//disables create/update button and every GUI label
		}
		
		
		
		/************************* LAYOUT *************************/
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Uni2Eclipse - Create Android Applications with Unity");
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		
		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ("Unity Version: ", Application.unityVersion);
		EditorGUILayout.LabelField ("API Level: ", minSDK);
		EditorGUILayout.LabelField ("Graphics: ", graphicLevel);
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ("Task: ", buttonTxt);
		EditorGUILayout.LabelField ("Project Path: ", androidProjDir);
		
		
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		
		/*********************************************************/


		//Center button on screen		
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		
		//Create/update button pressed
		if (GUILayout.Button (buttonTxt, GUILayout.Width (180))) {
			
			//Path to staging area
			string pathToStgArea = projectCurrentDir + Path.DirectorySeparatorChar + "Temp" + Path.DirectorySeparatorChar + "StagingArea";
			
			if (!Directory.Exists (pathToStgArea + Path.DirectorySeparatorChar + "assets")) {
				Debug.LogError ("Build a new Staging Area to update your Android Application. Go to File -> Build Settings -> Build");
				return;
			}
			
			
			if (Directory.Exists (androidProjDir)) {
				//"Update Android App";
				
				string androidAppProjDir = Directory.GetCurrentDirectory () + Path.DirectorySeparatorChar + "AndroidAPP" + Path.DirectorySeparatorChar + cleanProductName;
				
				//Delete old Assets/bin directory
				Directory.Delete (androidAppProjDir + Path.DirectorySeparatorChar + "assets" + Path.DirectorySeparatorChar + "bin", true);
				
				//Move Assets/bin from library project to livewallpaper proj
				Directory.Move (pathToStgArea + Path.DirectorySeparatorChar + "assets" + Path.DirectorySeparatorChar + "bin", androidAppProjDir + Path.DirectorySeparatorChar + "assets" + Path.DirectorySeparatorChar + "bin");
				
				
				//Delete staging area
				Directory.Delete (pathToStgArea, true);
				
				
				
				Debug.Log ("Update complete. Refresh your project in Eclipse.");
				UnityEditor.EditorUtility.DisplayDialog("Uni2Eclipse Message", "Update complete. Refresh your project in Eclipse.", "OK");
				
			} else {
				//"Create Android App";
				
				
				//Create new folder with the name of the productName
				string androidAppProjDir = Directory.GetCurrentDirectory () + Path.DirectorySeparatorChar + "AndroidAPP" + Path.DirectorySeparatorChar + cleanProductName;
				Directory.CreateDirectory (androidAppProjDir);
				
				//Copy all staging area to App proj
				DirectoryCopy (pathToStgArea, androidAppProjDir, true);
				
				
				//Move files in proj folder
				File.Copy ("Assets/Uni2LWP/LWPTemplate/project.tg", androidAppProjDir + Path.DirectorySeparatorChar + ".project");
				File.Copy ("Assets/Uni2LWP/LWPTemplate/classpath.tg", androidAppProjDir + Path.DirectorySeparatorChar + ".classpath");

				//Update name of project in app folder
				string fileLWPContents = File.ReadAllText (androidAppProjDir + Path.DirectorySeparatorChar + ".project");
				fileLWPContents = fileLWPContents.Replace ("<name>Uni2LWPLibrary</name>", "<name>" + cleanProductName + "</name>");
				File.WriteAllText (androidAppProjDir + Path.DirectorySeparatorChar + ".project", fileLWPContents);
				
				//Delete extra content
				File.Delete(androidAppProjDir + Path.DirectorySeparatorChar + "Package_unaligned.apk");
				File.Delete(androidAppProjDir + Path.DirectorySeparatorChar + "assets.ap_");
				
				
				
				//Create SRC directory in project
				string srcDir = androidAppProjDir + Path.DirectorySeparatorChar + "src" + Path.DirectorySeparatorChar + PlayerSettings.bundleIdentifier.Replace (".", string.Format ("{0}", Path.DirectorySeparatorChar));
				Directory.CreateDirectory (srcDir);

				
				
				File.Copy ("Assets/Uni2LWP/APPTemplate/YourActivity.java", srcDir + Path.DirectorySeparatorChar + cleanProductName + "Activity.java");
				string fileClassProj = File.ReadAllText (srcDir + Path.DirectorySeparatorChar + cleanProductName + "Activity.java");
				fileClassProj = fileClassProj.Replace ("package com.mirage.app", "package " + PlayerSettings.bundleIdentifier);
				fileClassProj = fileClassProj.Replace ("YourActivity", cleanProductName + "Activity");
				File.WriteAllText (srcDir + Path.DirectorySeparatorChar + cleanProductName + "Activity.java", fileClassProj);
				
				
				
				// Target SDK android.
				int targetSdk = 16;
				//Jellybean
				//Create project.properties file in App folder
				string androidProjectFile = androidAppProjDir + Path.DirectorySeparatorChar + "project.properties";
				File.WriteAllText (androidProjectFile, string.Format ("target=android-{0}", targetSdk));
				
				
				
				//Delete staging area
				Directory.Delete (pathToStgArea, true);
				
				
				Debug.Log ("Project created successfully. Import your project in Eclipse.");
				UnityEditor.EditorUtility.DisplayDialog("Uni2Eclipse Message", "Project created successfully. Import your project in Eclipse.", "OK");
				
				
				//Copy classes.jar
				String dstPath = androidAppProjDir + Path.DirectorySeparatorChar + "libs" + Path.DirectorySeparatorChar + "classes.jar";
				if (!CopyClassesJar (dstPath)) {
					//Error when copying classes.jar file. User can copy file manually.
					Debug.LogError ("File classes.jar not found. Please copy this file manually. Go to your Unity installation folder and search for this file. Then copy the file to " + androidAppProjDir + Path.DirectorySeparatorChar + "libs folder.");
				}
				
				
			}
			
		}
		
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		
		
		GUIStyle redBlueStyle = new GUIStyle ();
		redBlueStyle.padding = new RectOffset (5, 100, 30, 80);
		redBlueStyle.wordWrap = true;
		redBlueStyle.fontStyle = FontStyle.Bold;
		
		if (!GUI.enabled) {
			GUI.enabled = true;
			
			redBlueStyle.normal.textColor = new Color (0.588f, 0.0f, 0.0f);
			GUILayout.Label ("Check the Console for possible erros (Ctrl+Shift+C)", redBlueStyle);
			
		} else {
			
			redBlueStyle.normal.textColor = new Color (0.0f, 0.0f, 1.0f);
			GUILayout.Label ("Ready to build Android App...", redBlueStyle);
		}
		
	}
		
		
	
	
	
	/// <summary>
	/// Copy classes.jar file
	/// </summary>
	/// <param name="dstPath">
	/// A <see cref="System.String"/>
	/// </param>
	/// <returns>
	/// A <see cref="System.Boolean"/>
	/// </returns>
		private bool CopyClassesJar (string dstPath)
	{
		//Get unity Directory
		string unityDir = EditorApplication.applicationPath.Replace ("Unity.exe", "").Replace ("Unity.app", "");
		
		//Get win dir
		string jarWin = string.Join (string.Format ("{0}", Path.DirectorySeparatorChar), new string[] { unityDir, "Data", "PlaybackEngines", "AndroidPlayer", "bin", "classes.jar" });
		//Get mac dir
		string jarMac = string.Join (string.Format ("{0}", Path.DirectorySeparatorChar), new string[] { unityDir, "Unity.app", "Contents", "PlaybackEngines", "AndroidPlayer", "bin", "classes.jar" });
		
		
		//If windows
		if (File.Exists (jarWin)) {
			File.Copy (jarWin, dstPath);
		} else if (File.Exists (jarMac)) {
			File.Copy (jarMac, dstPath);
		} else {
			return false;
		}
		
		
		return true;
	}



	/// <summary>
	///  MSDN DirectoryCopy
	/// </summary>
	/// <param name="sourceDirName">
	/// A <see cref="System.String"/>
	/// </param>
	/// <param name="destDirName">
	/// A <see cref="System.String"/>
	/// </param>
	/// <param name="copySubDirs">
	/// A <see cref="System.Boolean"/>
	/// </param>
	private static void DirectoryCopy (string sourceDirName, string destDirName, bool copySubDirs)
	{
		DirectoryInfo dir = new DirectoryInfo (sourceDirName);
		DirectoryInfo[] dirs = dir.GetDirectories ();
		
		if (!dir.Exists) {
			Debug.LogError ("Source directory does not exist or could not be found: " + sourceDirName);
		}
		
		if (!Directory.Exists (destDirName)) {
			Directory.CreateDirectory (destDirName);
		}
		
		FileInfo[] files = dir.GetFiles ();
		foreach (FileInfo file in files) {
			string temppath = Path.Combine (destDirName, file.Name);
			file.CopyTo (temppath, false);
		}
		
		if (copySubDirs) {
			foreach (DirectoryInfo subdir in dirs) {
				string temppath = Path.Combine (destDirName, subdir.Name);
				DirectoryCopy (subdir.FullName, temppath, copySubDirs);
			}
		}
	}
	

	/// <summary>
	/// Remove special chars
	/// </summary>
	/// <param name="strValue">
	/// A <see cref="System.String"/>
	/// </param>
	/// <returns>
	/// A <see cref="System.String"/>
	/// </returns>
	private string RemoveReservedCharacters(string strValue)
	{
	    char[] ReservedChars = {'/', ':','*','?','"', '<', '>', '|', ' ', '%', '\''};
	
	    foreach (char strChar in ReservedChars)
	    {
	        strValue = strValue.Replace(strChar.ToString(), "");
	    }
	    return strValue;
	}
}
