using UnityEngine;
using System.Collections;

public class MoveSkeleboi : MonoBehaviour {

    int speed = 5;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(0, -1 * speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(1 * speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(0, 1 * speed * Time.deltaTime, 0);
        }
    }
}
