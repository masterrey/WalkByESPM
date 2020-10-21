using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoor : MonoBehaviour
{
    Quaternion rotToGo;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotToGo, Time.deltaTime*5);
    }

    public void Clicked(GameObject ob)
    {
        
        if (transform.localRotation.eulerAngles.y > 89)
        {
            rotToGo = Quaternion.Euler(0, 0, 0);
           
            audioSource.PlayDelayed(0.50f);
        }
        else
        {
            rotToGo = Quaternion.Euler(0, 90, 0);
            audioSource.Play();
        }
    }
}
