using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public string value;
    public PassLock passLock;


    public void Start()
    {
        passLock = GetComponentInParent<PassLock>();
    }

    public void Clicked(GameObject ob)
    {
        passLock.ButtonReceive(value);
    }

}
