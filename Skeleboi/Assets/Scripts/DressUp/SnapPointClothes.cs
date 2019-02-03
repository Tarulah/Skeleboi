using UnityEngine;
using System.Collections;

public class SnapPointClothes : MonoBehaviour {

    public GameObject[] clothes;
    public GameObject snapPoint;
    public float distance = 0.6f;
    float dist;
    bool check = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ClothesToPoint();
	}

    void ClothesToPoint()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 snap = new Vector3(snapPoint.transform.position.x, snapPoint.transform.position.y, snapPoint.transform.position.z);

            for(int i = 0; i < clothes.Length; i++)
            {
                Vector3 cloth = new Vector3(clothes[i].transform.position.x, clothes[i].transform.position.y, clothes[i].transform.position.z);

                dist = Vector3.Distance(snap, cloth);

                if(dist < distance)
                {
                    clothes[i].transform.position = snapPoint.transform.position;

                    if(clothes[i].transform.gameObject.tag == "Relaxed" && check)
                    {
                        //ANIMAATIOT TÄHÄN SEMMONE BLINGBLING
                        DressUpCheck.SharedDressUpScore.relaxedTheme++;
                        check = false;
                    }
                    else if (clothes[i].transform.gameObject.tag == "Flower" && check)
                    {
                        //ANIMAATIOT TÄHÄN SEMMONE BLINGBLING
                        DressUpCheck.SharedDressUpScore.flowerTheme++;
                        check = false;
                    }
                    else if (clothes[i].transform.gameObject.tag == "Rain" && check)
                    {
                        //ANIMAATIOT TÄHÄN SEMMONE BLINGBLING
                        DressUpCheck.SharedDressUpScore.rainTheme++;
                        check = false;
                    }
                }
            }
        }
    }
}
