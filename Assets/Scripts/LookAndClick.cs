using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAndClick : MonoBehaviour
{
    private int _maxDistance=10;
    public GameObject targetobject;
    public float timelooking=0;
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxDistance))
        {
            crosshair.transform.position = hit.point;
            //verifica se tem objeto guardado na memoria
            if (targetobject == null) //se nao tem
            {
                //verifica se o objeto tem o tag player
                if (hit.collider.CompareTag("Player"))
                {
                    //guarda na memoria o objeto a frente
                    targetobject = hit.collider.gameObject;
                    //reseta o contador
                    timelooking = 0;
                }
            }
            //checa se o objetod a memoria é o mesmo q capturou no raycast
            else if(targetobject == hit.collider.gameObject)
            {
                //incrementa o contador
                timelooking += Time.deltaTime;
                if (timelooking > 3)
                {
                    targetobject.SendMessage("Clicked");
                    timelooking = 0;
                }
            }
            else //se nao for o mesmo nem estiver vasio tira o objeto da memoria
            {
                targetobject = null;
            }
            

        }
    }
}
