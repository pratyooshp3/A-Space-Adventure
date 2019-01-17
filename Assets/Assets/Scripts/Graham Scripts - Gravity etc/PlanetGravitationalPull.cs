using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravitationalPull : MonoBehaviour {

    public bool withinAtmosphere = false;
    public float gravitationalSpeed;
    public Transform targetPlanet;
    public float timePulled;

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        //if in atmosphere (per below trigger), apply force to ship, moving it towards planet
		if (withinAtmosphere & timePulled < 10.0)
        {
            timePulled = timePulled + Time.deltaTime;
            float gravityPace = gravitationalSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPlanet.position, gravityPace);
            Debug.Log(gravityPace);
        }

        //reset the timer, so that ship can be pulled into another planet later & reset atmosphere
        if (timePulled > 10.0)
        {
            Debug.Log("TimeReset");
            timePulled = 0;
            withinAtmosphere = false;
        }
	}

    //if A object enters the planets atmosphere (the trigger), pull object toward planet
    
}
