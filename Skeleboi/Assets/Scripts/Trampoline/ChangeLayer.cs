using UnityEngine;
using System.Collections;

public class ChangeLayer : MonoBehaviour
{
    SpriteRenderer sr;
    //public SpriteRenderer[] childSR;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        //childSR = GetComponentsInChildren<SpriteRenderer>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Milk(Clone)")
        {
            GameObject.Find("bucket").GetComponent<SpriteRenderer>().sortingOrder = 2;

            //foreach(SpriteRenderer childrenSR in childSR)
            //{
            //    childrenSR.sortingOrder = 3;
            //}
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(Wait());       
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("bucket").GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
}
