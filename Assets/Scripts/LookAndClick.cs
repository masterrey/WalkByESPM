using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAndClick : MonoBehaviour
{
    private int _maxDistance=10;
    public GameObject targetobject;
    public float timelooking=0;
    public GameObject crosshair;
    Material matcross;
    public CharacterController ctrl;
    Vector3 moveto;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        moveto = transform.parent.transform.position;
        audioSource = GetComponent<AudioSource>();
        matcross = crosshair.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //se a subtraçao da posiçao e do moveto der algum valor ele usa este como direçao e velocidade para o destino
        Vector3 destino = moveto - transform.parent.transform.position;
        ctrl.SimpleMove(destino);
       
        //pega velocidade do personagem e usa como volume dos passos 
        audioSource.volume =ctrl.velocity.magnitude;

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
                    matcross.SetColor("_BaseColor", Color.red);
                }
                else
                {
                    matcross.SetColor("_BaseColor", Color.green);
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
                    //pega o objeto do tipo button 
                    Button btn = targetobject.GetComponent<Button>();
                    //se conseguiu pegar é pq é um botao da ui
                    if (btn)
                    {
                        //chamar a acao de clicar
                        btn.onClick.Invoke();
                    }
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
