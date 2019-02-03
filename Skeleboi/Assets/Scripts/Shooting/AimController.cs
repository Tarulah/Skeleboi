using UnityEngine;
using System.Collections;

public class AimController : MonoBehaviour {

    public GameObject Ammo;

    float speed = 5f;

    void Update()
    {
        MoveAim();
        InstantiateAmmo();
    }

    void MoveAim()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        //Cursor.visible = false;
    }

    void InstantiateAmmo()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject AmmoVar = Instantiate(Ammo, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            StartCoroutine(WaitAmmo(0.3f, AmmoVar));
        }
        
    }

    IEnumerator WaitAmmo(float waitTime, GameObject AmmoVar)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(AmmoVar);
        
    }
}
