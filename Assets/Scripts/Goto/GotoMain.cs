using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class GotoMain : MonoBehaviour
 {
     public GameObject Panel;



     public void GO()
     {
         print(Panel.name);
             Panel.SetActive(true);
           print(Panel.activeSelf);
           SoundManager.instence.PlaySE("button_sound");
     }
     
     public void Back(){
         Panel.gameObject.SetActive(false);
         print(Panel.name); print(Panel.activeSelf); 
         SoundManager.instence.PlaySE("button_sound");
     }
     
     public void Main()
     {
         Panel.gameObject.SetActive(false);
         print(Panel.name); print(Panel.activeSelf);
         SoundManager.instence.PlaySE("button_sound");
 } 
 
 }