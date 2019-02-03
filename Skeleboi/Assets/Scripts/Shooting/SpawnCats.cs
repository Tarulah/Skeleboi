using UnityEngine;
using System.Collections;

public class SpawnCatsUpOrDown
{
    private static SpawnCatsUpOrDown SpawnUpOrDownInstance = null;
    public static SpawnCatsUpOrDown SharedSpawnUpOrDown
    {
        get
        {
            if (SpawnUpOrDownInstance == null)
            {
                SpawnUpOrDownInstance = new SpawnCatsUpOrDown();
            }
            return SpawnUpOrDownInstance;
        }
    }
    public int raffleUpOrDown = 1;
}

public class SpawnCats : MonoBehaviour {

    public GameObject spawnPointUp;
    public GameObject spawnPointDown;
    public GameObject HappyCat;
    public GameObject GrumpyCat;

    int spawnTime = 2;


    // Update is called once per frame
    void Start () {

        ShootCatsScore.SharedShootScore.ShootingScore = 1;
        InvokeRepeating("WhereSpawn", 1f, spawnTime);
    }

    void WhereSpawn()
    {
        SpawnCatsUpOrDown.SharedSpawnUpOrDown.raffleUpOrDown = Random.Range(1, 3);

        if (SpawnCatsUpOrDown.SharedSpawnUpOrDown.raffleUpOrDown == 1)
        {
            SpawnCat(spawnPointUp);
        }
        else
        {
            SpawnCat(spawnPointDown);
        }
    }

    void SpawnCat(GameObject spawnPoint)
    {
        int raffle = Random.Range(1, 4);

        if (raffle == 1 || raffle == 2)
        {
            Instantiate(HappyCat, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else
        {
            Instantiate(GrumpyCat, spawnPoint.transform.position, spawnPointUp.transform.rotation);
        }
    }
}
