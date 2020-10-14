using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkHere : MonoBehaviour
{
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
        //devolve a posiçao da bolinha 
        ob.SendMessage("ToPosition", transform.position);
    }
}
