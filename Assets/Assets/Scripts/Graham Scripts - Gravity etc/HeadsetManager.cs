using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HeadsetManager : MonoBehaviour {

    public GameObject viveRig;
    public GameObject oculusRig;
    private bool hmdChosen;

    // Use this for initialization
    void Start()
    {
        if (XRDevice.model == "vive")
        {
            viveRig.SetActive(true);
            oculusRig.SetActive(false);
            hmdChosen = true; 
        }
        if (XRDevice.model == "oculus")
        {
            viveRig.SetActive(false);
            oculusRig.SetActive(true);
            hmdChosen = true;
        }
    }	
	// Update is called once per frame
	void Update () {
        if (!hmdChosen)
        {
            if (XRDevice.model == "vive")
            {
                viveRig.SetActive(true);
                oculusRig.SetActive(false);
                hmdChosen = true;
            }
            if (XRDevice.model == "oculus")
            {
                viveRig.SetActive(false);
                oculusRig.SetActive(true);
                hmdChosen = true;
            }
        }
		
	}
}
