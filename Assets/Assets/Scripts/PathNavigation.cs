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
    float time = 70.0f;

    void Start()
    {
        iTween.Init(this.gameObject);
        tween();
    }
    private void Update()
    {

        
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
        iTween.MoveTo(gameObject, iTween.Hash("path", path, "time", time, "orienttopath", true, "looktime", .9, "easetype", "easeInOutSine", "oncomplete", "complete"));
       // iTween.MoveTo(gameObject, iTween.Hash("path", navPath, "time", time,  "easetype", "easeInOutSine", "oncomplete", "complete"));
    }

}
