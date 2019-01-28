using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2_Narration : MonoBehaviour {

	// Use this for initialization
	public AudioSource narrate_scene2;

	void Start () {
		narrate_scene2 = GetComponent<AudioSource>();
		narrate_scene2.Play (0);
		}

	// Update is called once per frame
	void Update () {


	}
}
