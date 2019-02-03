using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour
{

    public float speed = 3f;
    Vector3 mousePos;
    Vector3 tmpMousePos;

    Animator anim;

    void Start()
    {
        anim = GameObject.Find("Skeleboi").GetComponent<Animator>();
        tmpMousePos = Input.mousePosition;

        LoadedLevel.SharedLevel.loadedLevel = "Trampoline";
    }

    void Update()
    {
        MoveTrampoline();
    }

    void MoveTrampoline()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(mousePos.x, transform.position.y, 0);

        if(tmpMousePos != Input.mousePosition)
        {
            anim.SetBool("Walking", true);
            tmpMousePos = Input.mousePosition;
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }
}
