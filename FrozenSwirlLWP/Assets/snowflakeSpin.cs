using UnityEngine;
using System.Collections;

public class snowflakeSpin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// Slowly rotate the object around its z axis at 1 degree/second.
		transform.Rotate(0, 0, .7f);
	}
}
