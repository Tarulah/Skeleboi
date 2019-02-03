using UnityEngine;
using System.Collections;

public class SpawnPoints : MonoBehaviour {

    public float spawningDelay = 1f;
    public Transform[] spawnPoints;
    public GameObject milk;

    bool isSpawning = false;
    int index;

	void Update ()
    {
        SpawnFew();
	}

    IEnumerator SpawnMilk(int spawnIndex, float spawnTime)
    {
        //Debug.Log("Waiting: " + spawnTime);
        yield return new WaitForSeconds(spawnTime);
        
        Instantiate(milk, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

        isSpawning = false;
    }

    void SpawnFew()
    {
        int milkCount = MilkCounter();

        if (milkCount == 0)
        {
            if (!isSpawning)
            {
                isSpawning = true;
                index = Random.Range(0, spawnPoints.Length);
                StartCoroutine(SpawnMilk(index, spawningDelay));
            }
        }
    }

    // counts how many milks in the scene
    int MilkCounter()
    {
        GameObject[] listMilks = GameObject.FindGameObjectsWithTag("Milk");
        int milks = listMilks.Length;
        return milks;
    }
}
