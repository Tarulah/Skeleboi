using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

//täällä on myös animaatiot

public class PlayerHit : MonoBehaviour {

    public Slider milkMeter;
    Animator anim;

    float milk = 0;
    int untilChange = 2;

    void Start()
    {
        anim = GameObject.Find("ForAnimation").GetComponent<Animator> ();
    }

    void Update()
    {
        milkMeter.value = milk;

        anim.GetBool("Win");
        anim.GetBool("Lose");

        if(milk >= 100)
        {
            anim.SetBool("Win", true);
            StartCoroutine(ChangeScene(untilChange));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Törmätäänkö esteeseen...
        if(col.gameObject.tag == "Obstacle")
        {
            //Ääntä ja animaatiota
            anim.SetBool("Lose", true);

            Success.SharedSuccess.success = false;
            StartCoroutine(ChangeScene(untilChange));
            //Tuhoaa pelaajan
            //Destroy(gameObject);
        }
        //... vai maitopurkkiin
        else if(col.gameObject.tag == "Collectable")
        {
            //joku kiva ääni tähän
            milk += 10;
            //Tuhoaa maitopurkin
            Destroy(col.gameObject);
        }
    }


    IEnumerator ChangeScene(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene("Break", LoadSceneMode.Single);
    }
}
