using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetGravityNeutralizer : MonoBehaviour {

    //Documentation: Appled to Button. Deactivates the Gravitational pull applied by "PlanetGravitationalPull", using button.

    public PlanetGravitationalPull planetGravitationalPull;
    public GameObject button;
    public Material pushedMaterial;
    public Material notPushedMaterial;
    public bool buttonIsPushed = false;
    public Text pullDeactivatedText;
    public bool buttonBeenPushed = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (buttonIsPushed & buttonBeenPushed != true)
        {
            //deactivate gravitational pull
            planetGravitationalPull.withinAtmosphere = false;
            button.GetComponent<Renderer>().material = pushedMaterial;
            pullDeactivatedText.enabled = true;
            buttonBeenPushed = true;
            button.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Button Pushed");
        }
        //if the user lets up on the button, neutralizer shuts off, text disappears
        //Commenting this out as it causes complication - one push does the job:
        //else if (buttonBeenPushed)
        //{
        //    planetGravitationalPull.withinAtmosphere = true;
        //    button.GetComponent<Renderer>().material = notPushedMaterial;
        //    pullDeactivatedText.enabled = false;

            //PROBLEM #1:
            //need to enter in a line here that if the 10s is up, atmosphereEnterable (of that planet),
            //needs to be turned to false (so user doesnt have to hold button forever) 
        //}

    }

    //when red button is pushed into the collider of the button's base, mark as pushed
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RedButton")
        {
            buttonIsPushed = true;
        }
    }
    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.name == "RedButton")
    //    {
    //        buttonIsPushed = false;
    //    }
    //}


}
