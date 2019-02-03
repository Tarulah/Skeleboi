using UnityEngine;
using System.Collections;

public class SpawnArrows : MonoBehaviour {

    public GameObject spawnPoint;
    public GameObject SpawnArrowsPrefab;

    float spawnTime = 3f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Spawn () {
        Instantiate(SpawnArrowsPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
