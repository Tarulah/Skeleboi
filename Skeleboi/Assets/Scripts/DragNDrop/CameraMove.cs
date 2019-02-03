using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public GameObject stopPoint;
    public float speed = 5f;

	Animator anim;

	void Start(){
		anim = GameObject.Find("DragNDropSkeleboi").GetComponent<Animator> ();
        GameObject.Find("DragNDropSkeleboi").SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		anim.GetBool ("CamFinished");

		if (DragNDropBoneCounter.SharedBoneCounter.counter == 14) {
			SmoothMove();
		}
       
    }

    void SmoothMove()
    {
        Vector2 currPos = transform.position;
        Vector2 endPos = stopPoint.transform.position;
        Vector2 dirOfTravel = endPos - currPos;

        //now normalize the direction, since we only want the direction information
        dirOfTravel.Normalize();

        //scale the movement on axis by the directionOfTravel vector components
		gameObject.transform.Translate(dirOfTravel.x * speed * Time.deltaTime, 0, 0);

        if(currPos.x > endPos.x)
        {
            gameObject.transform.position = stopPoint.transform.position;
			anim.SetBool ("CamFinished", true); 
        }
    }
}
