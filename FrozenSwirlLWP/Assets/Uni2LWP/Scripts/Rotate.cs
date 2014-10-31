using UnityEngine;
using System.Collections;

/// <summary>
/// Rotate object
/// </summary>
public class Rotate : MonoBehaviour
{
	public float speed = 10f;
	public bool isEnabled = false;


	void Update ()
	{
		if (isEnabled)
			transform.Rotate (Vector3.down * Time.deltaTime * speed);
	}


	public void SetRotation (bool opt)
	{
		isEnabled = opt;
	}
	
}
