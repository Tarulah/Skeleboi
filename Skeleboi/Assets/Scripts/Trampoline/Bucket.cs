using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour
{
    float addPoint = 10f;

    // KORJAAA MAIDON TARTTUMINEN ÄMPÄRIIN!!!!!!!!!!!!
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        TrampoScore.SharedTrampoScore.score += addPoint;
    }
}
