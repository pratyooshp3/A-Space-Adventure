using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet_rotation_tilt : MonoBehaviour {

	// Use this for initialization

	public float tiltAngleZ=30.0f;
	public float rotateSpeed=25.0f;

	void Start () {

		Debug.Log (" Tilt Angle along Z: " + tiltAngleZ);
		Debug.Log (" Planet Rotation Speed: " + rotateSpeed);
		transform.rotation=Quaternion.Euler (0.0f,0.0f,tiltAngleZ);
		
	}
	
	// Update is called once per frame
	void Update () {
		

		transform.Rotate(transform.up*rotateSpeed*Time.deltaTime,Space.World);


	}
}

