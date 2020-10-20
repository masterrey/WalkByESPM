﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoor : MonoBehaviour
{
    Quaternion rotToGo;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else
        {
            rotToGo = Quaternion.Euler(0, 90, 0);
        }
    }
}
