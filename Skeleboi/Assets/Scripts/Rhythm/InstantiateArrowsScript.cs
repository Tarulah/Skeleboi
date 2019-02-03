using UnityEngine;
using System.Collections;

public class InstantiateArrowsScript : MonoBehaviour
{

    public GameObject spawnPointUp;
    public GameObject spawnPointRight;
    public GameObject spawnPointLeft;
    public GameObject SpawnArrowsUp;
    public GameObject SpawnArrowsRight;
    public GameObject SpawnArrowsLeft;

    float spawnTime = 1f;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnTime);
    }

    void Spawn()
    {
        int raffle = Random.Range(1, 4);

        if (raffle == 1)
        {
            Instantiate(SpawnArrowsUp, spawnPointUp.transform.position, spawnPointUp.transform.rotation);
        }
        else if (raffle == 2)
        {
            Instantiate(SpawnArrowsLeft, spawnPointLeft.transform.position, spawnPointLeft.transform.rotation);
        }
        else if (raffle == 3)
        {
            Instantiate(SpawnArrowsRight, spawnPointRight.transform.position, spawnPointRight.transform.rotation);
        }
    }
}