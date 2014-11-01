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
		
		changed = true;
	}
	
	/*
	void setColor2( string R1, string B1, string G1,
					string R2, string B2, string G2,
					string R3, string B3, string G3)	
	{
		 setAllColor( 1, R1, B1, G1, R2, B2, G2, R3, B3, G3);
		
		colors[1].changed = true;
	}
	
	
	void setColor3( string R1, string B1, string G1,
					string R2, string B2, string G2,
					string R3, string B3, string G3)	
	{
		 setAllColor( 2, R1, B1, G1, R2, B2, G2, R3, B3, G3);
		
		colors[2].changed = true;
		
	}
	
	
	void setColor4( string R1, string B1, string G1,
					string R2, string B2, string G2,
					string R3, string B3, string G3)	
	{
		 setAllColor( 3, R1, B1, G1, R2, B2, G2, R3, B3, G3);
		
		colors[3].changed = true;
		
	}
	
	
	void setColor5( string R1, string B1, string G1,
					string R2, string B2, string G2,
					string R3, string B3, string G3)	
	{
		 setAllColor( 4, R1, B1, G1, R2, B2, G2, R3, B3, G3);
		
		colors[4].changed = true;
		
	}
	
	void setColor6( string R1, string B1, string G1,
					string R2, string B2, string G2,
					string R3, string B3, string G3)	
	{
		 setAllColor( 5, R1, B1, G1, R2, B2, G2, R3, B3, G3);
		
		colors[5].changed = true;
		
	}
	*/
}
