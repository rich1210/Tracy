using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public class Test : MonoBehaviour {
	
	string testVal = ".45,.34,.23,.12,.45,.67";

	// Use this for initialization
	void Start () {
		
		float[] boxIndex = new float[6];
		
		for( int i = 0; i < 6; i++)
		{
			//testVal = testVal.Replace(',', '.');
			string[] digit = testVal.Split(',');
			
			float.TryParse(digit[i], out boxIndex[i]);
				
			//Debug.Log( "testVal :" + boxIndex[i]);
		
			
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
