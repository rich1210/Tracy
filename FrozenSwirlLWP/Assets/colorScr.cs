using UnityEngine;
using System.Collections;

public class colorScr : MonoBehaviour {
	
	
	public ParticleAnimator[] paArray = new ParticleAnimator[6];
	private int index; 
	Color[] colors;
	
	
	//colorScr.colors[0].colorArray[0,0]
	
	// Use this for initialization
	void Start () {
		
		colors = new Color[5]
		{ 
			new Color (
				SetColorsSrc.getColorSet(0, 0, 0),
				SetColorsSrc.getColorSet(0, 0, 1),
				SetColorsSrc.getColorSet(0, 0, 2)
				),
			
			new Color (
				SetColorsSrc.getColorSet(0, 1, 0),
				SetColorsSrc.getColorSet(0, 1, 1),
				SetColorsSrc.getColorSet(0, 1, 2)
				),
			
			new Color (
				SetColorsSrc.getColorSet(0, 2, 0),
				SetColorsSrc.getColorSet(0, 2, 1),
				SetColorsSrc.getColorSet(0, 2, 2)
				),
			
			new Color (
				SetColorsSrc.getColorSet(0, 2, 0),
				SetColorsSrc.getColorSet(0, 2, 1),
				SetColorsSrc.getColorSet(0, 2, 2)
				),
			
			new Color (
				SetColorsSrc.getColorSet(0, 2, 0),
				SetColorsSrc.getColorSet(0, 2, 1),
				SetColorsSrc.getColorSet(0, 2, 2)
				),
			
			};
		
		
		Debug.Log (SetColorsSrc.getColorSet(0, 0, 0) + " " +
				   SetColorsSrc.getColorSet(0, 0, 1) + " " +
					SetColorsSrc.getColorSet(0, 0, 2) );
		
		paArray[0].colorAnimation = colors;
	}
	
	// Update is called once per frame
	void Update () {	
		
		if(SetColorsSrc.getChangeCol())
		{
			//resetColors
	
			
			//first color option
			setColor(0);
			paArray[0].colorAnimation = colors;
			
			setColor(1);
			paArray[1].colorAnimation = colors;
			
			setColor(2);
			paArray[2].colorAnimation = colors;
			
			setColor(3);
			paArray[3].colorAnimation = colors;
			
			setColor(4);
			paArray[4].colorAnimation = colors;
			
			setColor(5);
			paArray[5].colorAnimation = colors;
			
			SetColorsSrc.setChangeCol( false );
		}
		
	
	}
	
	
	void setColor( int index)
	{
		colors = new Color[5]
		{ 
			new Color (
				SetColorsSrc.getColorSet(index, 0, 0),
				SetColorsSrc.getColorSet(index, 0, 1),
				SetColorsSrc.getColorSet(index, 0, 2)
				),
			
			new Color (
				SetColorsSrc.getColorSet(index, 1, 0),
				SetColorsSrc.getColorSet(index, 1, 1),
				SetColorsSrc.getColorSet(index, 1, 2)
				),
			
			new Color (
				SetColorsSrc.getColorSet(index, 2, 0),
				SetColorsSrc.getColorSet(index, 2, 1),
				SetColorsSrc.getColorSet(index, 2, 2)
				),
			
			new Color (
				SetColorsSrc.getColorSet(index, 2, 0),
				SetColorsSrc.getColorSet(index, 2, 1),
				SetColorsSrc.getColorSet(index, 2, 2)
				),
			
			new Color (
				SetColorsSrc.getColorSet(index, 2, 0),
				SetColorsSrc.getColorSet(index, 2, 1),
				SetColorsSrc.getColorSet(index, 2, 2)
				),
			
			};
	}
}
