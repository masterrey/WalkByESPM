using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public bool closed=true;
    public bool locked;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator Opening()
    {
        float deltaopen = 0;

        while (deltaopen < 1)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 90, 0), deltaopen);
            deltaopen += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();

        }
        closed = false;
        transform.localRotation = Quaternion.Euler(0, 90, 0);
    }

    IEnumerator Closing()
    {
        float deltaopen = 0;

        while (deltaopen < 1)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 0, 0), deltaopen);
            deltaopen += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();

        }
        closed = true;
        audioSource.Play();
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }


    public void Clicked(GameObject ob)
    {
        if (closed)
        {
            if(!locked)
            StartCoroutine(Opening());
        }
        else
        {
            StartCoroutine(Closing());
        }
        
    }

    public void Unlock()
    {
        locked = false;
        StartCoroutine(Opening());
    }
}
