using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravitationalPull : MonoBehaviour {

    //Documentation: This script is applied to Ship. Activates gravity when the ship enters the 
    //planetary atmosphere (i.e. trigger area)

    public bool withinAtmosphere = false;
    public float gravitationalSpeed;
    public Transform targetPlanet;
    public float timePulled;
    public iTween iTweenScript;
    public GameObject thisShip;
    public float pullTimeLimit;
    public PlanetGravityNeutralizer planetGravitationalNeutralizer;
    public bool neutralized;
    public GravityPull gravityPull;

    // Use this for initialization
    void Start () {
        iTweenScript = thisShip.GetComponent<iTween>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time < 2)
        {
            iTweenScript = thisShip.GetComponent<iTween>();
            //Debug.Log(Time.time);
        }
        //if in atmosphere (per below trigger), apply force to ship, moving it towards planet
        if (withinAtmosphere & timePulled < pullTimeLimit)
        {
            planetGravitationalNeutralizer.button.GetComponent<Rigidbody>().isKinematic = false;
            iTweenScript.enabled = false;
            timePulled = timePulled + Time.deltaTime;
            float gravityPace = gravitationalSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPlanet.position, gravityPace);
            //Debug.Log("gravity pace: " + gravityPace);
        }

        //cancel force to ship
        if (timePulled > pullTimeLimit || planetGravitationalNeutralizer.buttonBeenPushed & neutralized !=true)
        {
            Debug.Log("Pull Neutralized & GravityPull Script DeActivated");
            iTweenScript.enabled = true;
            withinAtmosphere = false;
            neutralized = true;
            gravityPull.enabled = false;

        }
	}
    
}
