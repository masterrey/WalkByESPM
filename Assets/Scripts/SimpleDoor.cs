using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        if (transform.localRotation.eulerAngles.y == 90)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
    }
}
