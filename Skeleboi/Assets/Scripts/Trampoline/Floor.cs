using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour
{
    public GameObject[] spilled;
    float losePoint = 10f;
    int index;
    float destroySpillTime = 2f;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        index = Random.Range(0, spilled.Length);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // jos maitopurkki tippuu lattialle, niin maitojälki lattiaan ja tuhoa maitopurkki
        if (collision.gameObject.name == "Milk(Clone)")
        {
            // SPLÄTS SOUND HERE!!!!!!!!!!!!!
            GameObject clone = Instantiate(spilled[index], collision.transform.position, Quaternion.identity) as GameObject;
            Destroy(collision.gameObject);
            TrampoScore.SharedTrampoScore.score -= losePoint;

            StartCoroutine(DestroySpill(clone));
        }
    }

    IEnumerator DestroySpill(GameObject destroyObj)
    {
        yield return new WaitForSeconds(destroySpillTime);
        Destroy(destroyObj);
    }
}
