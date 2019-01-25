using UnityEngine;
using System.Collections;
using System;

public class PathNavigation : MonoBehaviour
{
    public Transform[] path;
    public GameObject finish;

    Vector3 direction;

    private bool buttonActivated;


    float rotateSpeed = 2.0f;
    float time = 180.0f;

    void Start()
    {
        iTween.Init(this.gameObject);
        //Invoke("tween", 10.0f);
        tween();
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
        iTween.DrawPath(path);
    }

    void tween()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", time, "orienttopath", true, "easetype", "linear", "looktime", .5, "oncomplete", "complete"));
        // iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", time, "orienttopath",  "easetype", "easeInOutSine", "oncomplete", "complete"));
    }



}
