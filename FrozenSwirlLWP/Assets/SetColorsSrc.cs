using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public class SetColorsSrc : MonoBehaviour 
{
		/*
		 * 		[0]			[1]			[2]
		 * [0]string R1, string B1, string G1,
		 * [1]string R2, string B2, string G2,
		 * [2]string R3, string B3, string G3
		 */
	public static float[, ,] colorArray = new float[6,3,3]; // first color // second RBG
		
	public static bool changed = true;
	
	float[] threeColor = new float[9];
	
	string test;
	
	void setAllColor( int index, string setColor )
	{
		
		
		for( int i = 0; i < 9; i++)
		{
			string[] digits = setColor.Split(',');
			
			float.TryParse(digits[i], out threeColor[i]);
			
			Debug.Log ( "9 Colors :" + threeColor[i]);
		}
		
		
		
		colorArray[index, 0,0] = threeColor[0];
		colorArray[index,0,1] = threeColor[1];
		colorArray[index,0,2] = threeColor[2];
		colorArray[index,1,0] = threeColor[3];
		colorArray[index,1,1] = threeColor[4];
		colorArray[index,1,2] = threeColor[5];
		colorArray[index,2,0] = threeColor[6];
		colorArray[index,2,1] = threeColor[7];
		colorArray[index,2,2] = threeColor[8];
		
		
		changed = true;
	}
	
	public static float getColorSet(int index, int colorNum, int RBG)
	{
		return colorArray[ index,colorNum, RBG];
	}
	
	public static bool getChangeCol( )
	{
		return changed;
	}
	
	public static void setChangeCol(  bool val )
	{
		changed = val;
	}

	void setColor1( string color)	
	{
		 setAllColor( 0, color);
	}
	
	void setColor2( string color )	
	{
		 setAllColor( 1, color);
	}
	
	void setColor3( string color )	
	{
		 setAllColor( 2, color);
	}
	
	void setColor4( string color )	
	{
		 setAllColor( 3, color);
	}
	
	void setColor5( string color )	
	{
		 setAllColor( 4, color);
	}
	
	void setColor6( string color )	
	{
		test = color;
		 setAllColor( 5, color);
	}
	
	
	void OnGUI() 
	{

		if(GUI.Button (new Rect(0, 0, Screen.width/4, Screen.height/4), "Mes :" + HomeSwitch.getTapped()))
		{

		}
	}
}
