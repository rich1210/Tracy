using UnityEngine;
using System.Collections;

public class SettingsScr : MonoBehaviour {
	
	private bool settings = false;
	private bool once = true;
	
	public GameObject snowTwirl1; // EPE->World Velocity -> z = 0 to z = 5 random between 0 and 1 sec
	//public GameObject snowTwirl2; // PA -> Local Rot Axis -> z = -2 to z = -1 random between 0 and 1 sec
	public ParticleAnimator PA2;
	//public GameObject snowTwirl3; //PA -> Local Rot Axis -> y = 0 to y = -1 random between 0 and 1 sec
	public ParticleAnimator PA3; 
	public GameObject snowTwirl4; // EPE->Local Velocity -> z = 0 to z = 5 random between 0 and 1 sec
	//public GameObject snowTwirl5; //PA -> Local Rot Axis -> z = -1 to z = -2 random between 0 and 1 sec	
	public ParticleAnimator PA5;
	//int counter, st1, st2, st3, st4, st5;
	int[ , ] ctrArray = new int[2,5];// [0,?] = ctr and [1,?] = test var
	
	
	// Use this for initialization
	void Start () 
	{
		ctrArray[1,0] = Random.Range (0, 27);
		snowTwirl1.GetComponent("EllipsoidParticleEmitter").particleEmitter.worldVelocity = new Vector3( 10f, 5f, 0f);
		
		ctrArray[1,1] = Random.Range (0, 27);
		PA2.localRotationAxis = new Vector3(0f,-2f, -2f ); 
		
		ctrArray[1,2] = Random.Range (0, 27);
		PA3.localRotationAxis = new Vector3(0f,-1f, 0f ); 
		
		ctrArray[1,3] = Random.Range (0, 27);
		snowTwirl4.GetComponent("EllipsoidParticleEmitter").particleEmitter.localVelocity = new Vector3( 5f, 0f, 0f);
		
		ctrArray[1,4] = Random.Range (0, 27);
		PA5.localRotationAxis = new Vector3(0f, 0f, 0f );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( settings )
		{
			// if the first partical varibale is activated 
			if ( ctrArray[0,0] >= ctrArray[1,0] )
			{
				if( snowTwirl1.GetComponent("EllipsoidParticleEmitter").particleEmitter.worldVelocity.z == 0)
				{
					snowTwirl1.GetComponent("EllipsoidParticleEmitter").particleEmitter.worldVelocity = new Vector3( 10f, 5f, 5f);
				}
				else
				{
					snowTwirl1.GetComponent("EllipsoidParticleEmitter").particleEmitter.worldVelocity = new Vector3( 10f, 5f, 0f);
				}
			
				ctrArray[0,0] = 0;
				ctrArray[1,0] = Random.Range (0, 27);
			}
			
			// if the second partical varibale is activated 
			if ( ctrArray[0,1] >= ctrArray[1,1] )
			{
				if( PA2.localRotationAxis.z == -2f)
				{
					PA2.localRotationAxis = new Vector3(0f,-2f, -1f );
				}
				else
				{
					PA2.localRotationAxis = new Vector3(0f,-2f, -2f );
				}
			
				ctrArray[0,1] = 0;
				ctrArray[1,1] = Random.Range (0, 27);
			}
			
			// if the third partical varibale is activated 
			if ( ctrArray[0,2] >= ctrArray[1,2] )
			{
				if( PA3.localRotationAxis.z == 0f)
				{
					PA3.localRotationAxis = new Vector3(0f,0f, -1f );
				}
				else
				{
					PA3.localRotationAxis = new Vector3(0f,0f, 0f );
				}
			
				ctrArray[0,2] = 0;
				ctrArray[1,2] = Random.Range (0, 27);
			}
			
			// if the forth partical varibale is activated 
			if ( ctrArray[0,3] >= ctrArray[1,3] )
			{
				if( snowTwirl4.GetComponent("EllipsoidParticleEmitter").particleEmitter.localVelocity.z == 0)
				{
					snowTwirl4.GetComponent("EllipsoidParticleEmitter").particleEmitter.localVelocity = new Vector3( 5f, 0f, 5f);
				}
				else
				{
					snowTwirl4.GetComponent("EllipsoidParticleEmitter").particleEmitter.localVelocity = new Vector3( 5f, 0f, 0f);
				}
			
				ctrArray[0,3] = 0;
				ctrArray[1,3] = Random.Range (0, 27);
			}
			
			// if the fifth partical varibale is activated 
			if ( ctrArray[0,4] >= ctrArray[1,4] )
			{
				if( PA5.localRotationAxis.z == -1f)
				{
					PA5.localRotationAxis = new Vector3(0f, 0f, -2f );
				}
				else
				{
					PA5.localRotationAxis = new Vector3(0f, 0f, -1f );
				}
			
				ctrArray[0,4] = 0;
				ctrArray[1,4] = Random.Range (0, 27);
			}
	
	
		
		
			// increment all counters
			for(int i = 0; i < 5; i++)
			{
				ctrArray[0,i] += 1;
			}
			Debug.Log(" index " + ctrArray[0,0] + " "  +  ctrArray[1,0]);
			once = true;
		}
		else
		{
			// this only needs to be called once after the varibles have been played with so the boolean once 
			if( once )
			{
				snowTwirl1.GetComponent("EllipsoidParticleEmitter").particleEmitter.worldVelocity = new Vector3( 10f, 5f, 0f);
						
				PA2.localRotationAxis = new Vector3(0f, 0f, -2f ); 
			
				PA3.localRotationAxis = new Vector3(0f,0f, -1f ); 
			
				snowTwirl4.GetComponent("EllipsoidParticleEmitter").particleEmitter.localVelocity = new Vector3( 5f, 0f, 0f);
			
				PA5.localRotationAxis = new Vector3(0f,0f, -1f );
				
				Debug.Log ( " GOT HERE ");
				
				once = false;
				
			}
		}
	}
	

}