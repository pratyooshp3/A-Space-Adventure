using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Audio : MonoBehaviour {
	public AudioClip[] audioFiles;
	AudioSource audio;
	public NoticeBoard_VR updateUI;
	// Use this for initialization
	void Start () {
		StartCoroutine(EarthAndMoon());
	}

	private void OnTriggerEnter(Collider col)
	{
        if (col.gameObject.name == "MarsAudioTrigger")
        {
			      updateUI.UpdateCurrentStatus();// UI Update
            audio.clip = audioFiles[2];
            audio.Play();
        }
        else if (col.gameObject.name == "TeslaAudioTrigger")
        {
			      updateUI.UpdateCurrentStatus();// UI Update
            audio.clip = audioFiles[3];
            audio.Play();
        }
        else if (col.gameObject.name == "JupiterAudioTrigger")
        {
			      updateUI.UpdateCurrentStatus();// UI Update
            audio.clip = audioFiles[4];
            audio.Play();
        }
        else if (col.gameObject.name == "Jupiter")
        {
			      updateUI.UpdateCurrentStatus();// UI Update
            audio.clip = audioFiles[5];
            audio.Play();
        }
		//updateUI.UpdateCurrentStatus();// UI Update
    }
    IEnumerator EarthAndMoon()
    {
        audio = GetComponent<AudioSource>();
		    updateUI.UpdateCurrentStatus();// UI Update
        audio.clip = audioFiles[0];
        audio.Play();

        yield return new WaitForSeconds(audio.clip.length + 1.0f);
		    updateUI.UpdateCurrentStatus();// UI Update
        audio.clip = audioFiles[1];
        audio.Play();
    }
}
