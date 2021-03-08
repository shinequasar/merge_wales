using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMain : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MAIN;
    public GameObject DUNGEON;

   public void TurnDUNGEON()
   {    
       if(MAIN.gameObject.activeSelf == true)  { 
           MAIN.gameObject.SetActive(false); 
           DUNGEON.gameObject.SetActive(true);
       }
       else 
       {
           MAIN.gameObject.SetActive(true); 
           DUNGEON.gameObject.SetActive(false);
       }
   
   }
   
  
}
