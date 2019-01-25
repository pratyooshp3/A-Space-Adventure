using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPull : MonoBehaviour
{

    Vector3 originPosition;
    Quaternion originRotation;

    public Light redLight; // Add desired red light in inspector

    //Camera Shake
    float shake_intensity;  // Intensity of Camera Shake

    //Light Flash
    float flashRate = 1.0f;  //How fast light flashes
    float canFlash = 0.0f;
    Coroutine flasher = null;

  
    private void Start()
    {
        redLight.gameObject.SetActive(false);
    }


    void Shake()
    {

            originPosition = transform.position;
            originRotation = transform.rotation;
            shake_intensity = .003f;
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
        
    }
   IEnumerator Flash()
    {
        while (true)
        {
            if (redLight.gameObject.activeSelf)
            {
                redLight.gameObject.SetActive(false);
            }
            else
            {
                redLight.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }


    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("GravPull"))
        {
            Shake();
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("GravPull"))
        {
            flasher = StartCoroutine(Flash());
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("GravPull"))
        {
            StopCoroutine(flasher);
            redLight.gameObject.SetActive(false);
        }
    }
}
