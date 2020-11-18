using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassLock : MonoBehaviour
{
    public string password = "1234";
    public string display;
    public TextMesh lcdDisplay;
    public bool armed = true;
    public GameObject objectToUnlock;
    public GameObject objtoenable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void ButtonReceive(string value)
   {
        
        if (value == "Enter")
        {
            if (password == display)
            {
                armed = false;
                lcdDisplay.text = "unlocked";
                objectToUnlock.SendMessage("Unlock");
                if (objtoenable)///liga qualquer coisa
                {
                    objtoenable.SetActive(!objtoenable.activeSelf);
                }
            }
            else
            {
                display = "";
                lcdDisplay.text = "error";
            }
        }
        else
        {
            display = display + value;
            lcdDisplay.text = display;
        }

       
   }
}
