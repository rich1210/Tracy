using UnityEngine;
using System.Collections;

public class colorScr : MonoBehaviour {
	
	
	public ParticleAnimator[] paArray = new ParticleAnimator[6];
	private int index; 
	Color[] colors;
	
	
	//colorScr.colors[0].colorArray[0,0]
	
	// Use this for initialization
	void Start () {
		
		
		colors = new Color[5]{ new Color (SetColorsSrc.getColorSet(0, 0, 0),
								  SetColorsSrc.getColorSet(0, 0, 1),
								SetColorsSrc.getColorSet(0, 0, 2)), Color.green, Color.blue, Color.cyan, Color.white};
		
		Debug.Log (SetColorsSrc.getColorSet(0, 0, 0) + " " +
				   SetColorsSrc.getColorSet(0, 0, 1) + " " +
					SetColorsSrc.getColorSet(0, 0, 2) );
		
		paArray[0].colorAnimation = colors;
	}
	
	// Update is called once per frame
	void Update () {	
		
		if(SetColorsSrc.getChangeCol())
		{
			//first color option
			paArray[0].colorAnimation = colors;
			/*
			//second color option
			paArray[index].colorAnimation[2] = new Color(coloring.colors[index].colorArray[1,0],
														coloring.colors[index].colorArray[1,1],
														coloring.colors[index].colorArray[1,2]);
			
			//third color option
			paArray[index].colorAnimation[3] = new Color(coloring.colors[index].colorArray[3,0],
														coloring.colors[index].colorArray[3,1],
														coloring.colors[index].colorArray[3,2]);
			*/
			
			
			SetColorsSrc.setChangeCol( false );
		}
		
	
	}
}
