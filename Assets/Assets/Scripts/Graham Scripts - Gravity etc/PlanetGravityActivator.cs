using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravityActivator : MonoBehaviour {
    public bool atmosphereEnterable = true;
    public PlanetGravitationalPull planetGravitationalPull;
    public GameObject ship;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        //if object setting is turned on to enter (can turn off for control purposes)
        if (atmosphereEnterable)
        {
            if (other.gameObject == ship)
            {
                Debug.Log("atmophere entered");

                //pull object towards planet

                planetGravitationalPull.withinAtmosphere = true;
            }
        }
    }
}
