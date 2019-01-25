using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Audio : MonoBehaviour {
    public AudioClip[] audioFiles;
    AudioSource audio;
    // Use this for initialization
    void Start () {
        StartCoroutine(EarthAndMoon());
	}

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "MarsAudioTrigger")
        {
            audio.clip = audioFiles[2];
            audio.Play();
        }
        else if (col.gameObject.name == "TeslaAudioTrigger")
        {
            audio.clip = audioFiles[3];
            audio.Play();
        }
        else if (col.gameObject.name == "JupiterAudioTrigger")
        {
            audio.clip = audioFiles[4];
            audio.Play();
        }
        else if (col.gameObject.name == "Jupiter")
        {
            audio.clip = audioFiles[5];
            audio.Play();
        }

    }
    IEnumerator EarthAndMoon()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = audioFiles[0];
        audio.Play();

        yield return new WaitForSeconds(audio.clip.length + 1.0f);
        audio.clip = audioFiles[1];
        audio.Play();
    }
}
