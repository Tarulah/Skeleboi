using UnityEngine;
using System.Collections;

public class MoveObjects : MonoBehaviour {

    public GameObject pointDestroy;

    public int speed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 currPos = transform.position;
        Vector2 endPos = pointDestroy.transform.position;
        Vector2 dirOfTravel = endPos + currPos;

        dirOfTravel.Normalize();

        gameObject.transform.Translate(dirOfTravel.x * speed * Time.deltaTime, 0, 0);

        if (currPos.x <= endPos.x)
        {
            Destroy(gameObject);
        }
    }
}
