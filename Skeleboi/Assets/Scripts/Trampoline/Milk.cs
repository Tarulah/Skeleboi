using UnityEngine;
using System.Collections;

public class Milk : MonoBehaviour
{
    float force = 10f;

    // http://noobtuts.com/unity/2d-pong-game
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "trampoline")
        {
            // BOING SOUND HERE!!!!!!!!!!!!
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * force;
        }
    }

    float hitFactor(Vector2 milkPos, Vector2 trampolinePos, float trampolineWidth)
    {
        return (milkPos.x - trampolinePos.x) / trampolineWidth;
    }

}
