using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light[] lights;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clicked(GameObject ob)
    {
        audioSource.Play();
        bool switchstate=false;
        if (lights.Length > 0)
        {
            foreach (Light alight in lights)
            {
                alight.enabled = !alight.enabled;
                switchstate = alight.enabled;
            }
        }
        if (switchstate)
        {
            transform.localRotation = Quaternion.Euler(-15, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(15, 0, 0);
        }
    }

}
