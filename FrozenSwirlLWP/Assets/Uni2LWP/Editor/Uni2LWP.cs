using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.IO;
using System.Reflection;

/// <summary>
/// Uni2LwP Version 1.5
/// </summary>
public class Uni2LWP : EditorWindow
{

	string projectCurrentDir = Directory.GetCurrentDirectory ();
	bool showErrorMsg = false;
	string androidProjDir = Directory.GetCurrentDirectory () + Path.DirectorySeparatorChar + "AndroidLWP";
	string buttonTxt = "Create Live Wallpaper";
	string graphicLevel;
	bool admob =false;
	string admobID = "Place AdMob ID here";
	string cleanProductName, pathToAdmobJar ="";
	string appName = "App Name";
	string appDescription = "Description";
	bool updateIcon = true;
	bool app2SD = false;
	bool opaqueToast = false;
	string unityMediaVersion = "";
	

	[MenuItem("Window/Uni2LWP/Create Live Wallpaper", false)]
	static void Init ()
	{
		//Clear Console Logs
		ClearLog ();
		
		
		string pathToStgArea = Directory.GetCurrentDirectory () + Path.DirectorySeparatorChar + "Temp" + Path.DirectorySeparatorChar + "StagingArea";
		if (!Directory.Exists (pathToStgArea + Path.DirectorySeparatorChar + "assets")) {
			Debug.LogError ("Staging Area not found. Build Staging Area first in File -> Build Settings -> Build");
		} else {
			
			Uni2LWP myMenuWindow = (Uni2LWP)EditorWindow.GetWindow (typeof(Uni2LWP), true, "Uni2LWP - Create Live Wallpapers with Unity", true);
			myMenuWindow.minSize = new Vector2 (640, 440);
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
		
		
		if (Application.unityVersion.StartsWith ("3.4") || Application.unityVersion.StartsWith ("3.5") || Application.unityVersion.StartsWith ("4.0")) {
			showErrorMsg = false;
		} else {
			Debug.LogError ("Unity " + Application.unityVersion + " is not supported by Uni2LWP");
			showErrorMsg = true;
		}
		
		
		
		string minSDK = PlayerSettings.Android.minSdkVersion.ToString ();
		if (minSDK.Equals ("AndroidApiLevel6", StringComparison.OrdinalIgnoreCase) || minSDK.Equals ("AndroidApiLevel7", StringComparison.OrdinalIgnoreCase)) {
			Debug.LogError ("Minimum API Level is Android 2.2 'Froyo' (API Level 8). Go to Player Settings and change the Minimum API Level.");
			showErrorMsg = true;
		}
		
		
		
		
		//Create mode: Impossible to create lwp project in dev mode.
		if (!Directory.Exists (androidProjDir)) {
			if(Debug.isDebugBuild){
				Debug.LogError ("Development Build detected. Please uncheck the Development Build option from the Build Settings Menu and then build a new Staging Area.\nDevelopment Build is only allowed during update. This means that after the live wallpaper folder is created you can change back to Development Buid to continue testing you live wallpaper.");
				showErrorMsg = true;
			}
		}
		
		
		
		if (!showErrorMsg) {
			
			if (Directory.Exists (androidProjDir))
				buttonTxt = "Update Live Wallpaper";
			else
				buttonTxt = "Create Live Wallpaper";
			
		} else {
			
			GUI.enabled = false;
			//disables create/update button and every GUI label
		}
		
		
		
		/************************* LAYOUT *************************/
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Uni2LWP - Create Live Wallpapers with Unity");
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		
		
		if (Directory.Exists (androidProjDir)) { //if update mode
			GUIStyle greenStyle = new GUIStyle ();
			greenStyle.normal.textColor = new Color (0.0f, 0.5f, 0.0f);
			greenStyle.wordWrap = true;
			greenStyle.margin.left = 5;
			GUILayout.Label ("Updating project with your latest Unity Scripts and Assets.Any modifications made in Eclipse will be preserved!",greenStyle);
		}
		
			
		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ("Unity Version: ", Application.unityVersion);
		EditorGUILayout.LabelField ("API Level: ", minSDK);
		EditorGUILayout.LabelField ("Graphics: ", graphicLevel);
		EditorGUILayout.Space ();
		
		
		
		if (!Directory.Exists (androidProjDir)) {
			
			EditorGUILayout.BeginHorizontal();
			admob = EditorGUILayout.Toggle("Create Admob", admob);
			if (GUILayout.Button ("Download AdMob SDK", GUILayout.Width (150))) {
				Application.OpenURL("https://developers.google.com/mobile-ads-sdk/download");
			}
			EditorGUILayout.EndHorizontal();
			
			admobID = EditorGUILayout.TextField("AdMob ID: ", admobID);

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField ("AdMob Library: ", pathToAdmobJar);
			if (GUILayout.Button ("Find...", GUILayout.Width (80))) {
				pathToAdmobJar = EditorUtility.OpenFilePanel("Locate Admob Jar file","","jar");
			}
			EditorGUILayout.EndHorizontal();
			
			
		}else{
			GUILayout.Label ("Admob is not available during update.");
		}
		
		
		
		EditorGUILayout.Space ();
		
		if (!Directory.Exists (androidProjDir)) {
			EditorGUILayout.Space ();
			appName = EditorGUILayout.TextField("App Name: ", appName);
			appDescription = EditorGUILayout.TextField("App Description: ", appDescription);
		}else{
			GUILayout.Label ("Changing App Name and Description is not possible during update.");
			EditorGUILayout.Space ();
		}
		
		
		updateIcon = EditorGUILayout.Toggle("Update Icon", updateIcon);
		
		
		
		
		EditorGUILayout.Space ();
		if (!Directory.Exists (androidProjDir)) {
			EditorGUILayout.Space ();
			
			EditorGUILayout.BeginHorizontal();
			app2SD = EditorGUILayout.Toggle("Enable App2SD: ", app2SD);
			if (GUILayout.Button ("Read more...", GUILayout.Width (100))) {
				string infoText ="Enabling this option allows the users to move the live wallpaper to the sdcard.\n";
				infoText = infoText +"\nHowever, this introduces 2 problems. Android will remove the Live Wallpaper from the Home Screen if:";
				infoText = infoText +"\n\n- the user connects the USB cable and access the sdcard;";
				infoText = infoText +"\n- the user restarts the device;";
				infoText = infoText +"\n\nBoth issues are entirely related to Android OS.";
				
				UnityEditor.EditorUtility.DisplayDialog("Uni2LwP (App2SD)", infoText, "OK");
			}
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			opaqueToast = EditorGUILayout.Toggle("Opaque Toast: ", opaqueToast);
			if (GUILayout.Button ("Read more...", GUILayout.Width (100))) {
				string infoText ="This option creates Opaque Toast Message that hides the 'Settings' and 'Set Live Wallpaper' buttons while the splash/logo is visible.\nKeep in mind that although hidden the user can still press the buttons.";
				UnityEditor.EditorUtility.DisplayDialog("Uni2LwP (Opaque Toast)", infoText, "OK");
			}
			EditorGUILayout.EndHorizontal();
		}else{
			GUILayout.Label ("Modifying App2SD and Opaque Toast features are not possible during update.");
			EditorGUILayout.Space ();
		}
		
		
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
		if (GUILayout.Button (buttonTxt, GUILayout.Width (150))) {
			
			//Path to staging area
			string pathToStgArea = projectCurrentDir + Path.DirectorySeparatorChar + "Temp" + Path.DirectorySeparatorChar + "StagingArea";
			
			if (!Directory.Exists (pathToStgArea + Path.DirectorySeparatorChar + "assets")) {
				Debug.LogError ("Build a new Staging Area to update your Live Wallpaper. Go to File -> Build Settings -> Build");
				return;
			}
			
			
			if (Directory.Exists (androidProjDir)) {
				//"Update Live Wallpaper";
				
				string livewallpaperProjDir = Directory.GetCurrentDirectory () + Path.DirectorySeparatorChar + "AndroidLWP" + Path.DirectorySeparatorChar + cleanProductName;
				
				//Delete old Assets/bin directory
				Directory.Delete (livewallpaperProjDir + Path.DirectorySeparatorChar + "assets" + Path.DirectorySeparatorChar + "bin", true);
				
				//Move Assets/bin from library project to livewallpaper proj
				Directory.Move (pathToStgArea + Path.DirectorySeparatorChar + "assets" + Path.DirectorySeparatorChar + "bin", livewallpaperProjDir + Path.DirectorySeparatorChar + "assets" + Path.DirectorySeparatorChar + "bin");
				
				//Copy/update lwp icons (every folder/file containing the name drawable)
				if (updateIcon)
					CopyIconDirectory(pathToStgArea + Path.DirectorySeparatorChar + "res", livewallpaperProjDir+ Path.DirectorySeparatorChar+ "res");
				
				
				//Delete staging area
				Directory.Delete (pathToStgArea, true);
				
				
				
				Debug.Log ("Update complete. Refresh your project in Eclipse.");
				UnityEditor.EditorUtility.DisplayDialog("Uni2LwP Message", "Update complete. Refresh your project in Eclipse.", "OK");
				
			} else {
				//"Create Live Wallpaper";
				
				
				//Create new folder with the name of the productName
				string livewallpaperProjDir = Directory.GetCurrentDirectory () + Path.DirectorySeparatorChar + "AndroidLWP" + Path.DirectorySeparatorChar + cleanProductName;
				Directory.CreateDirectory (livewallpaperProjDir);
				
				
				
				//Copy all files from LWP template to new project folder
				DirectoryCopy ("Assets/Uni2LWP/LWPTemplate/Uni2LWP", livewallpaperProjDir, true);
				
				//Copy lwp icons (every folder/file containing the name drawable)
				if (updateIcon)
					CopyIconDirectory(pathToStgArea + Path.DirectorySeparatorChar + "res", livewallpaperProjDir+ Path.DirectorySeparatorChar+ "res");

				
				//Rename files in proj folder
				File.Move (livewallpaperProjDir + Path.DirectorySeparatorChar + "project.tg", livewallpaperProjDir + Path.DirectorySeparatorChar + ".project");
				File.Move (livewallpaperProjDir + Path.DirectorySeparatorChar + "classpath.tg", livewallpaperProjDir + Path.DirectorySeparatorChar + ".classpath");
				
				
				//Update name of project in livewallpaper folder
				string fileLWPContents = File.ReadAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + ".project");
				fileLWPContents = fileLWPContents.Replace ("<name>Uni2LWP</name>", "<name>" + cleanProductName + "</name>");
				File.WriteAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + ".project", fileLWPContents);
				
				
				
				//Move Assets from staging area project to livewallpaper proj
				Directory.Move (pathToStgArea + Path.DirectorySeparatorChar + "assets", livewallpaperProjDir + Path.DirectorySeparatorChar + "assets");
				
				
				
				
				
				
				#if UNITY_3_4
				//Move Libs (.so files) to root of proj live wallpaper
				string pathToMoveARMv6 = Path.DirectorySeparatorChar + "libs" + Path.DirectorySeparatorChar + "armeabi";
				string pathToMoveARMv7 = Path.DirectorySeparatorChar + "libs" + Path.DirectorySeparatorChar + "armeabi-v7a";
				
				//Check  if is ARMv6a or AMRv7
				if (Directory.Exists (pathToStgArea + pathToMoveARMv7)) {
					
					Directory.Move (pathToStgArea + pathToMoveARMv7, livewallpaperProjDir + pathToMoveARMv7);
					
				} else if (Directory.Exists (pathToStgArea + pathToMoveARMv6)) {
					Directory.Move (pathToStgArea + pathToMoveARMv6, livewallpaperProjDir + pathToMoveARMv6);
					
				} else {
					Debug.LogError ("ARMv6 and ARMv7 Libs not found. Go to Player Settings and change Device Filter to ARMv6 or ARMv7 and then build the Staging Area\nagain in 'File -> Build Settings -> Build' before creating Live Wallpaper.");
					return;
				}
				
				#endif
				
				
				
				#if UNITY_3_5 || UNITY_4_0
				//Move Libs (.so files) to root of proj live wallpaper
				string pathToMoveARMv6 = Path.DirectorySeparatorChar + "libs" + Path.DirectorySeparatorChar + "armeabi-vfp";
				string pathToMoveARMv7 = Path.DirectorySeparatorChar + "libs" + Path.DirectorySeparatorChar + "armeabi-v7a";
				
				//Check  if is ARMv6a or AMRv7
				if (Directory.Exists (livewallpaperProjDir + Path.DirectorySeparatorChar + "assets" + pathToMoveARMv7)) {
					
					Directory.Move (livewallpaperProjDir + Path.DirectorySeparatorChar + "assets" + pathToMoveARMv7, livewallpaperProjDir + pathToMoveARMv7);
					
				} else if (Directory.Exists (livewallpaperProjDir + Path.DirectorySeparatorChar + "assets" + pathToMoveARMv6)) {
					string pathToMoveARMv6Dest = Path.DirectorySeparatorChar + "libs" + Path.DirectorySeparatorChar + "armeabi";
					Directory.Move (livewallpaperProjDir + Path.DirectorySeparatorChar + "assets" + pathToMoveARMv6, livewallpaperProjDir + pathToMoveARMv6Dest);
					
				} else {
					Debug.LogError ("ARMv6 and ARMv7 Libs not found. Go to Player Settings and change Device Filter to ARMv6 or ARMv7 and then build the Staging Area\nagain in 'File -> Build Settings -> Build' before creating Live Wallpaper.");
					return;
				}
				
				//Delete the NOW empty Libs folder
				Directory.Delete (livewallpaperProjDir + Path.DirectorySeparatorChar + "assets" + Path.DirectorySeparatorChar + "libs");
				
				#endif
				
				
				//Create SRC directory in project
				string srcDir = livewallpaperProjDir + Path.DirectorySeparatorChar + "src" + Path.DirectorySeparatorChar + PlayerSettings.bundleIdentifier.Replace (".", string.Format ("{0}", Path.DirectorySeparatorChar));
				Directory.CreateDirectory (srcDir);
				
				//Copy java file (JAVA classes)
				File.Copy ("Assets/Uni2LWP/LWPTemplate/JavaTemplate/Yourtemplate.java", srcDir + Path.DirectorySeparatorChar + cleanProductName + ".java");
				File.Copy ("Assets/Uni2LWP/LWPTemplate/JavaTemplate/YourtemplateSettings.java", srcDir + Path.DirectorySeparatorChar + cleanProductName + "Settings.java");
				File.Copy ("Assets/Uni2LWP/LWPTemplate/JavaTemplate/GestureLstr.java", srcDir + Path.DirectorySeparatorChar + "GestureLstr.java");
				
				
				//Update product name in manifest file
				string fileManifestproj = File.ReadAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "AndroidManifest.xml");
				fileManifestproj = fileManifestproj.Replace ("com.yourcompany.yourprojectname", PlayerSettings.bundleIdentifier);
				fileManifestproj = fileManifestproj.Replace (".YourProjectName", PlayerSettings.bundleIdentifier + "." + cleanProductName);
				fileManifestproj = fileManifestproj.Replace ("YourProjectNameSettings", cleanProductName + "Settings");
				
				if (app2SD)//if App2SD the change from internal to auto
					fileManifestproj = fileManifestproj.Replace ("internalOnly", "auto");
				
				File.WriteAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "AndroidManifest.xml", fileManifestproj);
				
				
				//Update main class
				string fileClassProj = File.ReadAllText (srcDir + Path.DirectorySeparatorChar + cleanProductName + ".java");
				fileClassProj = fileClassProj.Replace ("package com.mirage.livewallpaper", "package " + PlayerSettings.bundleIdentifier);
				fileClassProj = fileClassProj.Replace ("Yourtemplate", cleanProductName);
				fileClassProj = fileClassProj.Replace ("MyLWSettings", cleanProductName + "LWSettings");
				
				if (opaqueToast){
					fileClassProj = fileClassProj.Replace ("/*OPAQUETOASTDESTROY*/", "if (renderer != null) renderer.HideOpaqueToast();");
					fileClassProj = fileClassProj.Replace ("/*OPAQUETOAST*/", "if (isPreview()) renderer.CreateOpaqueToast(getApplicationContext(), 80);");
				}
				else{
					fileClassProj = fileClassProj.Replace ("/*OPAQUETOASTDESTROY*/", "");
					fileClassProj = fileClassProj.Replace ("/*OPAQUETOAST*/", "");
				}
				
				
				//Media volume fix
				if (Application.unityVersion.StartsWith ("3.4"))
					unityMediaVersion = "342";
				
				if (Application.unityVersion.StartsWith ("3.5"))
					unityMediaVersion = "357";
				
				if (Application.unityVersion.StartsWith ("4.0"))
					unityMediaVersion = "401";
				
				if (unityMediaVersion!="")
					fileClassProj = fileClassProj.Replace ("/*MEDIAVOLUMESTOP*/", "renderer.PauseMediaVolume(\""+ unityMediaVersion +"\");");
				else
					fileClassProj = fileClassProj.Replace ("/*MEDIAVOLUMESTOP*/", "");
					
				
				File.WriteAllText (srcDir + Path.DirectorySeparatorChar + cleanProductName + ".java", fileClassProj);
				
				
				//Update settings class
				string fileSettingsClass = File.ReadAllText (srcDir + Path.DirectorySeparatorChar + cleanProductName + "Settings.java");
				fileSettingsClass = fileSettingsClass.Replace ("package com.mirage.livewallpaper", "package " + PlayerSettings.bundleIdentifier);
				fileSettingsClass = fileSettingsClass.Replace ("YourtemplateSettings", cleanProductName + "Settings");
				fileSettingsClass = fileSettingsClass.Replace ("YourMainClassName", cleanProductName);
				File.WriteAllText (srcDir + Path.DirectorySeparatorChar + cleanProductName + "Settings.java", fileSettingsClass);
				
				
				
				//Update GestureLstr class
				string fileClassGestureLstr = File.ReadAllText (srcDir + Path.DirectorySeparatorChar + "GestureLstr.java");
				fileClassGestureLstr = fileClassGestureLstr.Replace ("package com.mirage.livewallpaper", "package " + PlayerSettings.bundleIdentifier);
				File.WriteAllText (srcDir + Path.DirectorySeparatorChar + "GestureLstr.java", fileClassGestureLstr);
				
				
				//Change name in xml file
				string fileXMLProj = File.ReadAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "res" + Path.DirectorySeparatorChar + "values" + Path.DirectorySeparatorChar + "strings.xml");
				fileXMLProj = fileXMLProj.Replace ("YourProjectName", RemoveCharacters(appName));
				fileXMLProj = fileXMLProj.Replace ("YourProjectDescription", RemoveCharacters(appDescription));
				
				File.WriteAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "res" + Path.DirectorySeparatorChar + "values" + Path.DirectorySeparatorChar + "strings.xml", fileXMLProj);
				
				//Change name of settings in xml
				string fileXMLSettings = File.ReadAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "res" + Path.DirectorySeparatorChar + "xml" + Path.DirectorySeparatorChar + "wallpaper.xml");
				fileXMLSettings = fileXMLSettings.Replace ("YourProjectNameSettings", PlayerSettings.bundleIdentifier + "." + cleanProductName + "Settings");
				File.WriteAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "res" + Path.DirectorySeparatorChar + "xml" + Path.DirectorySeparatorChar + "wallpaper.xml", fileXMLSettings);
				
				
				// Target SDK android.
				int targetSdk = 14;
				//Jellybean
				//Create project.properties file in livewallpaper folder
				string androidProjectFile = livewallpaperProjDir + Path.DirectorySeparatorChar + "project.properties";
				File.WriteAllText (androidProjectFile, string.Format ("target=android-{0}", targetSdk));
				
				
				
				string admobMessage ="";
				//If Admob selected
				if (admob){
					File.Copy ("Assets/Uni2LWP/LWPTemplate/JavaTemplate/AdmobPreference.java", srcDir + Path.DirectorySeparatorChar + "AdmobPreference.java");
					//Update AdmobPreference class
					string fileClassAdmob = File.ReadAllText (srcDir + Path.DirectorySeparatorChar + "AdmobPreference.java");
					fileClassAdmob = fileClassAdmob.Replace ("package com.mirage.livewallpaper", "package " + PlayerSettings.bundleIdentifier);
					File.WriteAllText (srcDir + Path.DirectorySeparatorChar + "AdmobPreference.java", fileClassAdmob);
					//Update Xml
					string fileWallSettingsXML = File.ReadAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "res" + Path.DirectorySeparatorChar + "xml" + Path.DirectorySeparatorChar + "wallpaper_settings.xml");
					string packageAdmob = "<" + PlayerSettings.bundleIdentifier+".AdmobPreference android:key=\"adView\" ></" + PlayerSettings.bundleIdentifier + ".AdmobPreference>";
					fileWallSettingsXML = fileWallSettingsXML.Replace ("<!-- Ad Placeholder -->", packageAdmob);
					File.WriteAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "res" + Path.DirectorySeparatorChar + "xml" + Path.DirectorySeparatorChar + "wallpaper_settings.xml", fileWallSettingsXML);
					
					
					//Copy and Update your ADMOB ID
					File.Copy ("Assets/Uni2LWP/LWPTemplate/AdmobTemplate/admob_preference.xml", livewallpaperProjDir + Path.DirectorySeparatorChar + "res" + Path.DirectorySeparatorChar + "layout" + Path.DirectorySeparatorChar + "admob_preference.xml");
					string fileAdmobIDXML = File.ReadAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "res" + Path.DirectorySeparatorChar + "layout" + Path.DirectorySeparatorChar + "admob_preference.xml");
					fileAdmobIDXML = fileAdmobIDXML.Replace ("ADMOB_ID", admobID.Trim());
					File.WriteAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "res" + Path.DirectorySeparatorChar + "layout" + Path.DirectorySeparatorChar + "admob_preference.xml", fileAdmobIDXML);
					
					
					//Update Manifest file again. This time is to add admob permissions and activity
					fileManifestproj = File.ReadAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "AndroidManifest.xml");
					fileManifestproj = fileManifestproj.Replace ("<!-- Ad permissions -->", "<uses-permission android:name=\"android.permission.ACCESS_NETWORK_STATE\" ></uses-permission><uses-permission android:name=\"android.permission.INTERNET\" ></uses-permission>");
					fileManifestproj = fileManifestproj.Replace ("<!-- Ad activity -->", "<activity android:name=\"com.google.ads.AdActivity\" android:configChanges=\"keyboard|keyboardHidden|orientation|screenLayout|uiMode|screenSize|smallestScreenSize\" />");
					File.WriteAllText (livewallpaperProjDir + Path.DirectorySeparatorChar + "AndroidManifest.xml", fileManifestproj);
					
					
					//If Admob jar is located
					if (pathToAdmobJar.Length != 0) {
						if (File.Exists(pathToAdmobJar)){ //If file exists
							//Copy Jar to Libs folder
							File.Copy(pathToAdmobJar,livewallpaperProjDir + Path.DirectorySeparatorChar + "libs" + Path.DirectorySeparatorChar + "GoogleAdMobAdsSdk.jar");
						}else{
							admobMessage ="\nPlease follow the next steps to finish AdMob integration:\n\n-Download the latest AdMob SDK from https://developers.google.com/mobile-ads-sdk/download\n\n-Extract GoogleAdMobAdsSdk-x.x.x.jar into your Live Wallpaper libs folder;";
						}
					 }else{
						admobMessage ="\nPlease follow the next steps to finish AdMob integration:\n\n-Download the latest AdMob SDK from https://developers.google.com/mobile-ads-sdk/download\n\n-Extract GoogleAdMobAdsSdk-x.x.x.jar into your Live Wallpaper libs folder;";
					}
					
				}
				
				
				Debug.Log ("Project created successfully. Import your project in Eclipse.\n" + admobMessage);
				UnityEditor.EditorUtility.DisplayDialog("Uni2LwP Message", "Project created successfully. Import your project in Eclipse\n" + admobMessage, "OK");
				
				
				//Copy classes.jar
				String dstPath = livewallpaperProjDir + Path.DirectorySeparatorChar + "libs" + Path.DirectorySeparatorChar + "classes.jar";
				if (!CopyClassesJar (dstPath)) {
					//Error when copying classes.jar file. User can copy file manually.
					Debug.LogError ("File classes.jar not found. Please copy this file manually. Go to your Unity installation folder and search for this file. Then copy the file to " + livewallpaperProjDir + Path.DirectorySeparatorChar + "libs folder.");
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
			GUILayout.Label ("Ready to build Live Wallpaper...", redBlueStyle);
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
	///  Only copies files inside string array (allowedFiles)
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
		string[] allowedFiles = new string[] { "AndroidManifest.xml", "classpath.tg", "project.tg", "icon.png", "strings.xml", "styles.xml" ,"wallpaper.xml", "wallpaper_settings.xml", "Uni2LWPLibraryOfs.jar" };
		
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

			foreach (string part in allowedFiles){
				if (string.Equals(part, file.Name)){
					string temppath = Path.Combine (destDirName, file.Name);		
					file.CopyTo (temppath, false);
				}
			}
			
		}
		
		if (copySubDirs) {
			foreach (DirectoryInfo subdir in dirs) {
				string temppath = Path.Combine (destDirName, subdir.Name);
				DirectoryCopy (subdir.FullName, temppath, copySubDirs);
			}
		}
	}
	
	/// <summary>
	/// Remove special chars;
	/// To use with folder and class names
	/// </summary>
	/// <param name="strValue">
	/// A <see cref="System.String"/>
	/// </param>
	/// <returns>
	/// A <see cref="System.String"/>
	/// </returns>
	private string RemoveReservedCharacters(string strValue)
	{
	    char[] ReservedChars = {'/', ':','*','?','"', '<', '>', '|', ' ', '%', '\'', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-'};
	
	    foreach (char strChar in ReservedChars)
	        strValue = strValue.Replace(strChar.ToString(), "");
	    
	    return strValue;
	}
	
	/// <summary>
	/// Remove special chars;
	/// To use with AppName and AppDescription
	/// </summary>
	/// <param name="strValue">
	/// A <see cref="System.String"/>
	/// </param>
	/// <returns>
	/// A <see cref="System.String"/>
	/// </returns>
	private string RemoveCharacters(string strValue)
	{
	    char[] ReservedChars = {'/', ':','*','?','"', '<', '>', '|', '%', '\''};
	    foreach (char strChar in ReservedChars)
	        strValue = strValue.Replace(strChar.ToString(), "");

		return strValue;
	}
	
	
	
	private static void CopyIconDirectory(string sourceDirName, string destDirName){
		DirectoryInfo dir = new DirectoryInfo (sourceDirName);
		DirectoryInfo[] dirs = dir.GetDirectories ();
		
		if (!dir.Exists) {
			Debug.LogError ("Source directory does not exist or could not be found: " + sourceDirName);
		}
		
		
		foreach (DirectoryInfo subdir in dirs) {
			if (subdir.FullName.Contains("drawable")){

				string temppath = Path.Combine (destDirName, subdir.Name);
				DirectoryCopy (subdir.FullName, temppath, true);
				
				File.Copy(subdir.FullName + Path.DirectorySeparatorChar + "app_icon.png", temppath + Path.DirectorySeparatorChar + "icon.png",true);
				
			}
		}
		
	}
	
}