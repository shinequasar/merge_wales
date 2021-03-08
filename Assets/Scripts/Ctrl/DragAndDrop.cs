using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
   private Vector3 screenSpace;
   private Vector3 offset;

   private void OnMouseDown()
   {
      Debug.Log("오브젝트 터치");
      
      //translate the cubes position from the world to Screen Point
      screenSpace = Camera.main.WorldToScreenPoint(transform.position);

      //calculate any difference between the cubes world position and the mouses Screen position converted to a world point  
      offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

      
   }

   private void OnMouseDrag()
   {
      //keep track of the mouse position
      var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

      //convert the screen mouse position to world point and adjust with offset
      var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

      //update the position of the object in the world
      transform.position = curPosition;
      
      Debug.Log("드래그앤 드롭 작동중");
   }

   private void OnMouseUp()
   {
      Debug.Log("오브젝트에서 손 뗌");
   }
}
