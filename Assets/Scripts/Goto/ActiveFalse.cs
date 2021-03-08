using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFalse : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    public void False()
    {
        Panel.gameObject.SetActive(false); 
    }

}
