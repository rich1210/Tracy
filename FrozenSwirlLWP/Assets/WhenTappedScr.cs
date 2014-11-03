using UnityEngine;
using System.Collections;

public class WhenTappedScr : MonoBehaviour {
	
	public GameObject explode;
	GameObject copy;
	bool ready = true; 
	bool test = true;
	bool test2 = true;
	int counter;
	
	public static bool anima = false;
	
	public static bool getAnima(){ return anima; }
	public static void setAnima(bool val ) { anima = val; } 

	// Use this for initialization
	void Start () {
		explode.gameObject.SetActive(false);
		

	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(HomeSwitch.getTapped())
		{
			//anima = true;
			copy = (GameObject)Instantiate( explode);
			copy.gameObject.SetActive(true);
			HomeSwitch.setTapped(false);
			//test = false;
		}
		
		if(HomeSwitch.getTappedCtr())
		{
			counter++;
			if( counter >= 162)
			{
				Destroy(copy);
				counter = 0;
				//anima = false;
				HomeSwitch.setTappedCtr(false);
				//test2 = false;
			}
		}
			
		
	}
				
	
}
