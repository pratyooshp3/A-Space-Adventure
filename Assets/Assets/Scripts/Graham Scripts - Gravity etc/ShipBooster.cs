using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBooster : MonoBehaviour {

    public float speed;
    //public float newZPosition = 1;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        //first failed attempt to boost
        //newZPosition = newZPosition * speed * Time.deltaTime;
        //transform.position = new Vector3(0, 0, newZPosition);

        rb.AddForce(transform.forward * speed);
    }
}
