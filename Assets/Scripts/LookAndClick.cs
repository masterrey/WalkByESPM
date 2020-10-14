using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAndClick : MonoBehaviour
{
    private int _maxDistance=10;
    public GameObject targetobject;
    public float timelooking=0;
    public GameObject crosshair;
    public CharacterController ctrl;
    Vector3 moveto;
    // Start is called before the first frame update
    void Start()
    {
        moveto = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //se a subtraçao da posiçao e do moveto der algum valor ele usa este como direçao e velocidade para o destino
        ctrl.SimpleMove(moveto-transform.position );

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
                    //o segundo parametro é a referencia de si mesmo para poder receber mensagens
                    targetobject.SendMessage("Clicked",gameObject);
                    timelooking = 0;
                }
            }
            else //se nao for o mesmo nem estiver vasio tira o objeto da memoria
            {
                targetobject = null;
            }
            

        }
    }
    //recebe a posiçao da bolinha e guarda na variavel moveto
    void ToPosition(Vector3 pos)
    {
        moveto = pos;
    }
}
