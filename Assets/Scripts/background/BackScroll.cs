using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackScroll : MonoBehaviour
{
    public float scrollSpeed = 0.2f; 
    Material myMaterial;
   
    
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float newOffsetX = myMaterial.mainTextureOffset.x + scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(newOffsetX, 0);
        myMaterial.mainTextureOffset = newOffset;
        
    }

}
