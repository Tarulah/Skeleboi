using UnityEngine;
using System.Collections;

public class ShootCatsScore
{
    private static ShootCatsScore ShootScoreInstance = null;
    public static ShootCatsScore SharedShootScore
    {
        get
        {
            if (ShootScoreInstance == null)
            {
                ShootScoreInstance = new ShootCatsScore();
            }
            return ShootScoreInstance;
        }
    }
    public int ShootingScore = 1;
}

public class ShootCats : MonoBehaviour {

    Ray ray;
    RaycastHit hit;

    Animator animHappy, animGrumpy;

    void Start()
    {
        //animHappy = gameObject.GetComponentInChildren<Animator>();
        //animGrumpy = gameObject.GetComponentInChildren<Animator>();
    }

	// Update is called once per frame
	void Update () {

        //animHappy.GetBool("IsShot");
        //animGrumpy.GetBool("IsShot");

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit, 10f))
            {
                //gameObject.transform.position = gameObject.transform.position;
                StartCoroutine(waitAfterShooting(2f));
            }
        }
	}

    IEnumerator waitAfterShooting(float waitTime)
    {
        hit.collider.GetComponent<SpriteRenderer>().enabled = false;
        if (SpawnCatsUpOrDown.SharedSpawnUpOrDown.raffleUpOrDown == 1)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
        }
        else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = 3;
            Debug.Log(gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder);
        }

        if (hit.collider.tag == "HappyCatColliderTag")
        {
            //animHappy.SetBool("IsShot", true);
            ShootCatsScore.SharedShootScore.ShootingScore += 10;
        }
        else if (hit.collider.tag == "GrumpyCatColliderTag")
        {
            //animGrumpy.SetBool("IsShot", true);
            ShootCatsScore.SharedShootScore.ShootingScore -= 10;
        }

        yield return new WaitForSeconds(waitTime);
        Destroy(hit.transform.gameObject);
    }
}
