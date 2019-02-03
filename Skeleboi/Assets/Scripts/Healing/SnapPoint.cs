using UnityEngine;
using System.Collections;

public class SnapPoint : MonoBehaviour {

    public GameObject HealingMilk;
    public GameObject snapPoint;
    public GameObject[] snapPoints;

    private bool check = true;

    Vector3 origPos;

    Ray ray;
    RaycastHit hit;


    void Start()
    {

        snapPoints = GameObject.FindGameObjectsWithTag("PointTag");
        origPos = transform.position;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        MilkToPoint();
    }

    void MilkToPoint()
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            if(HealingMilk.transform.position != snapPoint.transform.position)
            {
                if (Physics.Raycast(ray, out hit, 10))
                {
                    HealingMilk.transform.position = origPos;
                }
            }
        }
    }
}
