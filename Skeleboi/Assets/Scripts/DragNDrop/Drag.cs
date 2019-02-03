using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour
{
    // REMEMBER COLLIDER TO MAKE THIS WORK
    void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objPos;
        //Debug.Log("Dragging!");
    }
}
