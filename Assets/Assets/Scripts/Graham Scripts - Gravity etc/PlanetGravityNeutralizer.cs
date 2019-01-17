﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetGravityNeutralizer : MonoBehaviour {

    public PlanetGravitationalPull planetGravitationalPull;
    public GameObject button;
    public Material pushedMaterial;
    public Material notPushedMaterial;
    public bool buttonPushed = false;
    public Text pullDeactivatedText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (buttonPushed)
        {
            //deactivate gravitational pull
            planetGravitationalPull.withinAtmosphere = false;
            button.GetComponent<Renderer>().material = pushedMaterial;
            pullDeactivatedText.enabled = true;
        }
        //if the user lets up on the button, neutralizer shuts off, text disappears
        else
        {
            planetGravitationalPull.withinAtmosphere = true;
            button.GetComponent<Renderer>().material = notPushedMaterial;
            pullDeactivatedText.enabled = false;

            //PROBLEM #1:
            //need to enter in a line here that if the 10s is up, atmosphereEnterable (of that planet),
            //needs to be turned to false (so user doesnt have to hold button forever) 
        }

    }

    //when red button is pushed into the collider of the button's base, mark as pushed
    void OnCollisionEnter(Collision collision)
    {
        buttonPushed = true;
    }
    void OnCollisionExit(Collision collision)
    {
        buttonPushed = false;
    }


}
