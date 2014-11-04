using UnityEngine;
using System.Collections;

public class WhenTappedScr : MonoBehaviour {
	
	public ParticleSystem explode;
	bool ready = true; 
	bool test = true;
	bool test2 = true;
	int counter;
	
	public static bool anima = false;
	
	public static bool getAnima(){ return anima; }
	public static void setAnima(bool val ) { anima = val; } 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if(HomeSwitch.getTapped())
		{
			//anima = true;
			explode.enableEmission = true;
			HomeSwitch.setTapped(false);
			//test = false;
		}	
		
	}
				
	
}
