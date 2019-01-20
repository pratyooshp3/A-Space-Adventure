using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class CameraJoystickRotate : MonoBehaviour {

    public Camera spaceCamera;
    public float speed = 1;
    public Vector2 oculusJoystick;
    public Vector2 steamTouchPad;


    // Use this for initialization
    void Start () {
        oculusJoystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        steamTouchPad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
    }
	
	// Update is called once per frame
	void Update () {

        //make camera look at the pivot object (spaceship?)
        spaceCamera.transform.LookAt(transform);
        transform.Rotate(Vector3.up * oculusJoystick.y * speed * Time.deltaTime);
        transform.Rotate(Vector3.right * oculusJoystick.x * speed * Time.deltaTime);



    }
}
