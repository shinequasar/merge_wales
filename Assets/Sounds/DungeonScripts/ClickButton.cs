using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class ClickButton : MonoBehaviour

{
 
    
    public void OnMouseDown()

    {

//depth = depth + goldPerClick;
        

        DataController.Instance.depth -= DataController.Instance.goldPerClick;

    }

}