using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoPanels : MonoBehaviour
{
    public GameObject Panel;
    
    public void OnOff()
    {    
        if(Panel.gameObject.activeSelf == true)  { 
            Panel.gameObject.SetActive(false); 
        }
        else 
        {
            Panel.gameObject.SetActive(true); 
        }
        
        SoundManager.instence.PlaySE("button_sound");
   
    }

    public void on()
    {
        Panel.gameObject.SetActive(true); 
    }
    
    public void off()
    {
        Panel.gameObject.SetActive(false); 
    }
    
}
