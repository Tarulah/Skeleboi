using UnityEngine;
using System.Collections;

public class MoveCats : MonoBehaviour {

    public float speed;
    public GameObject pointDestroyUp;
    public GameObject pointDestroyDown;
    private bool collide = false;

    int i = SpawnCatsUpOrDown.SharedSpawnUpOrDown.raffleUpOrDown;

    void Update () {

        MoveCat();
    }

    void MoveCat() {

        if(i == 1)
        {
            i = 1;
            
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            
            Vector2 currPos = transform.position;
            Vector2 endPos = pointDestroyUp.transform.position;
            Vector2 dirOfTravel = endPos + currPos;

            dirOfTravel.Normalize();

            gameObject.transform.Translate(dirOfTravel.x * speed * Time.deltaTime, 0, 0);

            if (currPos.x <= endPos.x)
            {
                if (gameObject.name == "HappyCat(Clone)")
                {
                    ShootCatsScore.SharedShootScore.ShootingScore -= 10;
                }
                Destroy(gameObject);
            }
        }

        else
        {
            i = 2;

            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;

            Vector2 currPos = transform.position;
            Vector2 endPos = pointDestroyDown.transform.position;
            Vector2 dirOfTravel = endPos - currPos;

            dirOfTravel.Normalize();

            gameObject.transform.Translate(dirOfTravel.x * speed * Time.deltaTime, 0, 0);

            if (currPos.x >= endPos.x - 0.2)
            {
                if (gameObject.name == "HappyCat(Clone)")
                {
                    ShootCatsScore.SharedShootScore.ShootingScore -= 10;
                }
                Destroy(gameObject);
            }
        }
        
    }
}
