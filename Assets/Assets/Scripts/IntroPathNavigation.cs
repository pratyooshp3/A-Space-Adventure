using UnityEngine;
using System.Collections;
using System;

public class IntroPathNavigation : MonoBehaviour
{
    public Transform[] introPath;
    public GameObject station;

    Vector3 direction;

    private bool buttonActivated;


    float rotateSpeed = 2.0f;
    float introTime = 50.0f;

    void Start()
    {

        iTween.Init(this.gameObject);
        IntroTween();
    }
    private void Update()
    {
        transform.LookAt(station.transform);
    }


    /*void OnGUI () {
		if(buttonActivated){
			if(GUILayout.Button ("Reset")){
				reset();
				tween();
			}
		}
	}*/

    void OnDrawGizmos()
    {
        iTween.DrawPath(introPath);
    }

    void IntroTween()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", introPath, "time", introTime, "easetype", "linear", "looktime", .5, "oncomplete", "complete"));
        // iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", time, "orienttopath",  "easetype", "easeInOutSine", "oncomplete", "complete"));
    }
}