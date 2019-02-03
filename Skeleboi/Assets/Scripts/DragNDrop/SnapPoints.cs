using UnityEngine;
using System.Collections;

public class SnapPoints : MonoBehaviour
{
    public GameObject  Sparkle;

    public GameObject bonePart;
    public GameObject snapPoint;
    public GameObject[] snapPoints;

    private bool check = true;
    private GameObject SparkleVar;

    Vector3 origPos;

    Ray ray;
    RaycastHit hit;

    public float distance = 0.6f;

    void Start() {

        snapPoints = GameObject.FindGameObjectsWithTag("PointTag");
        origPos = transform.position;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        BoneToPoint(); 
    }

    void BoneToPoint()
    {
        if (Input.GetMouseButtonUp(0))
        {
			Vector3 snap = new Vector3(snapPoint.transform.position.x, snapPoint.transform.position.y, snapPoint.transform.position.z);
            Vector3 bone = new Vector3(bonePart.transform.position.x, bonePart.transform.position.y, bonePart.transform.position.z);

            float dist = Vector3.Distance(snap, bone);
            if (dist < distance)
            {
                bonePart.transform.position = snapPoint.transform.position;
                if (bonePart.transform.position == snapPoint.transform.position && check == true) {
                    DragNDropBoneCounter.SharedBoneCounter.counter++;
                    //Instanssioi joku kiva pikkuefekti merkiksi, että pelaaja tietää onnistuneensa
                    SparkleVar = Instantiate(Sparkle,snapPoint.transform.position, snapPoint.transform.rotation) as GameObject;
                    StartCoroutine(waitSparkle(0.4f));
                    //joku kiva ääni samaa tarkoitusta varten
                    check = false;
                }
            }
            else
            {
                if (Physics.Raycast(ray, out hit, 10) && hit.collider.gameObject.name == gameObject.name)
                {
                    bonePart.transform.position = origPos;
                }
            }
        }
    }
    IEnumerator waitSparkle(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(SparkleVar);
    }
}