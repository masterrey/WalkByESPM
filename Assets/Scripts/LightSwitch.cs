using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light light;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clicked(GameObject ob)
    {
        light.enabled = !light.enabled;

        if (light.enabled)
        {
            transform.localRotation = Quaternion.Euler(-15, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(15, 0, 0);
        }
    }

}
