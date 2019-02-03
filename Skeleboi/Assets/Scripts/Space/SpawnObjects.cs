using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {

    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;

    public GameObject Planet1; //keskinopea
    public GameObject Planet2; //nopea
    public GameObject Planet3; //hidas
    public GameObject Milk;

    float spawnTime = 2f;
    //Kertoo instanssioidaanko planeetta vai maitopurkki (joka toinen objekti on planeetta ja joka toinen maitopurkki)
    int i = 1;
    //apumuuttuja joka estää kahden planeetan peräkkäisen instanssioinnin
    int j = 0;


    // Use this for initialization
    void Start () {
        InvokeRepeating("WhereSpawn", 1f, spawnTime);
    }
	
	// Update is called once per frame
	void WhereSpawn () {
        //arpoo mihin pisteeseen instanssioidaan
        int pointRaffle = Random.Range(1, 5);

        if(pointRaffle == 1)
        {
            spawnObjects(spawnPoint1);
        }
        else if (pointRaffle == 2)
        {
            spawnObjects(spawnPoint2);
        }
        else if (pointRaffle == 3)
        {
            spawnObjects(spawnPoint3);
        }
        else if (pointRaffle == 4)
        {
            spawnObjects(spawnPoint4);
        }
    }

    //Arpoo mikä objekti instanssioidaan
    void spawnObjects(GameObject spawnPoint)
    {
        if(i == 1)
        {
            //instanssioidaan joku planeetoista

            int raffle = Random.Range(1, 4);

            if (raffle == 1 && j != 1)
            {
                Instantiate(Planet1, spawnPoint.transform.position, spawnPoint.transform.rotation);
                j = 1;
            }
            else if (raffle == 2 && j != 2)
            {
                Instantiate(Planet2, spawnPoint.transform.position, spawnPoint.transform.rotation);
                j = 2;
            }

            else if (raffle == 3 && j != 3)
            {
                Instantiate(Planet3, spawnPoint.transform.position, spawnPoint.transform.rotation);
                j = 3;
            }

            i = 2;
        }
        else if(i == 2)
        {
            //instanssioidaan maito
            Instantiate(Milk, spawnPoint.transform.position, spawnPoint.transform.rotation);
            i = 1;
        }
    }
}
