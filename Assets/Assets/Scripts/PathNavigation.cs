using UnityEngine;
using System.Collections;
using System;

public class PathNavigation : MonoBehaviour
{
    public Transform[] marsPath;
    public Transform[] jupiterPath;
    public GameObject finish;

    Vector3 direction;

    private bool buttonActivated;


    float rotateSpeed = 2.0f;


    void Start()
    {
        iTween.Init(this.gameObject);
        tween(marsPath);
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
        iTween.DrawPath(marsPath);
    }

    void tween(Transform[] navPath)
    {
        float time = 0.0f;
        if(navPath == marsPath)
        {
            time = 20.0f;
        }
        iTween.MoveTo(gameObject, iTween.Hash("path", navPath, "time", time, "orienttopath", true, "looktime", .9, "easetype", "easeInOutSine", "oncomplete", "complete"));
       // iTween.MoveTo(gameObject, iTween.Hash("path", navPath, "time", time,  "easetype", "easeInOutSine", "oncomplete", "complete"));
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("planet"))
        {
            iTween.Pause();
        }
    }
    
        
    
    /*void reset(){
		buttonActivated=false;
		transform.position=new Vector3(0,0,0);
		transform.eulerAngles=new Vector3(0,0,0);
	}*/

    void complete()
    {
        buttonActivated = true;
    }
}
