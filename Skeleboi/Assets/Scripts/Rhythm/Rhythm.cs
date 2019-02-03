using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// https://www.youtube.com/watch?v=GDAd2FycS5A

public class Rhythm : MonoBehaviour
{
    public float speed;
    public GameObject pointDestroy;
    public GameObject pointScore;
    private bool collide = false;

    public GameObject BadPointLower;
    public GameObject BadPointUpper;
    public GameObject GoodPointLower;
    public GameObject GoodPointUpper;
    public GameObject ExcelentPoint;

    public GameObject Bad;
    public GameObject Good;
    public GameObject Excellent;

    public bool levelEnd;

    float losePoint = 10f;
    float badPoint = 0;
    float goodPoint = 5f;
    float excellentPoint = 10f;
    float extension = 0.2f;

    float waitingTime = 0.5f;
    bool checkCheckPos = true;
    Vector2 feedbackPos = new Vector2(-6, 0);
    SpriteRenderer idle, right, left, up, won, lost;

    Animator anim;

    void Start()
    {
        anim = GameObject.Find("BadassGlasses").GetComponent<Animator>();

        idle = GameObject.Find("SkeleboiIdle").GetComponent<SpriteRenderer>();
        right = GameObject.Find("SkeleboiRight").GetComponent<SpriteRenderer>();
        left = GameObject.Find("SkeleboiLeft").GetComponent<SpriteRenderer>();
        up = GameObject.Find("SkeleboiUp").GetComponent<SpriteRenderer>();
        won = GameObject.Find("SkeleboiWin").GetComponent<SpriteRenderer>();
        lost = GameObject.Find("SkeleboiLost").GetComponent<SpriteRenderer>();
    }

	void Update ()
    {
	    MoveArrow();
		WinOrLose ();
    }

    void MoveArrow()
    {
        Vector2 currPos = transform.position;
        Vector2 endPos = pointDestroy.transform.position;
        Vector2 dirOfTravel = endPos - currPos;

        //now normalize the direction, since we only want the direction information
        dirOfTravel.Normalize();

        //scale the movement on axis by the directionOfTravel vector components
        gameObject.transform.Translate(0, -dirOfTravel.y * speed * Time.deltaTime, 0);

        if (currPos.y >= endPos.y)
        {
            Destroy(gameObject);         
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        collide = true;

        if (other.transform.name == "LeftArrow")
        {
            if (Input.GetKey(KeyCode.LeftArrow))              
            {
                idle.enabled = false;
                left.enabled = true;
                right.enabled = false;
                up.enabled = false;
                won.enabled = false;
                lost.enabled = false;

                CheckPos();
            }
        }
        else if (other.transform.name == "UpArrow")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                idle.enabled = false;
                left.enabled = false;
                right.enabled = false;
                up.enabled = true;
                won.enabled = false;
                lost.enabled = false;

                CheckPos();
            }
        }
        else if (other.transform.name == "RightArrow")
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                idle.enabled = false;
                left.enabled = false;
                right.enabled = true;
                up.enabled = false;
                won.enabled = false;
                lost.enabled = false;

                CheckPos();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.name == "LeftArrowPointScore" || other.transform.name == "DownArrowPointScore" ||
            other.transform.name == "UpArrowPointScore" || other.transform.name == "RightArrowPointScore")
        {
            RythmScore.SharedRythmScore.score -= losePoint;
        }
    }

    void WinOrLose()
    {
		if (RythmScore.SharedRythmScore.score >= 100) {

            speed = 0;

            idle.enabled = false;
            left.enabled = false;
            right.enabled = false;
            up.enabled = false;
            won.enabled = true;
            lost.enabled = false;

            anim.SetBool("hasWon", true);
            StartCoroutine(ChangeScene(2.5f));

		} else if (RythmScore.SharedRythmScore.score <= 0) {

			Success.SharedSuccess.success = false;

            speed = 0;

            idle.enabled = false;
            left.enabled = false;
            right.enabled = false;
            up.enabled = false;
            won.enabled = false;
            lost.enabled = true;

            StartCoroutine(ChangeScene(2f));
        }
    }

    void CheckPos()
    {
        Vector2 currPos = transform.position;
        Vector2 BadPosLow = BadPointLower.transform.position;
        Vector2 BadPosUp = BadPointUpper.transform.position;
        Vector2 GoodPosLow = GoodPointLower.transform.position;
        Vector2 GoodPosUp = GoodPointUpper.transform.position;
        Vector2 ExcellentPos = ExcelentPoint.transform.position;

        if (currPos.y <= BadPosLow.y + extension && currPos.y >= BadPosLow.y - extension && checkCheckPos == true)
        {
            checkCheckPos = false;
            //Pisteet +- 0
            //Joku indikaattori siitä, että pelaaja onnistui
            GameObject BadObject = Instantiate(Bad, feedbackPos, gameObject.transform.rotation) as GameObject;
            //piilottaa nuolen kuvan poistamatta gameobjectia, jotta ei häiritse pelaajaa, mutta suorittaa koodin loppuun
            transform.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(waitAnimStop(waitingTime, BadObject));
        }

        else if (currPos.y <= BadPosUp.y + extension && currPos.y >= BadPosUp.y - extension && checkCheckPos == true)
        {
            checkCheckPos = false;
            //Pisteet +- 0
            //Joku indikaattori siitä, että pelaaja onnistui
            GameObject BadObjectUp = Instantiate(Bad, feedbackPos, gameObject.transform.rotation) as GameObject;
            transform.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(waitAnimStop(waitingTime, BadObjectUp));
        }

        else if (currPos.y <= GoodPosLow.y + extension && currPos.y >= GoodPosLow.y - extension && checkCheckPos == true)
        {
            checkCheckPos = false;
            //Pisteet + 5
            RythmScore.SharedRythmScore.score += goodPoint;
            //Joku indikaattori siitä, että pelaaja onnistui
            GameObject GoodObject = Instantiate(Good, feedbackPos, gameObject.transform.rotation) as GameObject;
            transform.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(waitAnimStop(waitingTime, GoodObject));
        }

        else if (currPos.y <= GoodPosUp.y + extension && currPos.y >= GoodPosUp.y - extension && checkCheckPos == true)
        {
            checkCheckPos = false;
            //Pisteet + 5
            RythmScore.SharedRythmScore.score += goodPoint;
            //Joku indikaattori siitä, että pelaaja onnistui
            GameObject GoodObjectUp = Instantiate(Good, feedbackPos, gameObject.transform.rotation) as GameObject;
            transform.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(waitAnimStop(waitingTime, GoodObjectUp));
        }

        else if (currPos.y <= ExcellentPos.y + extension && currPos.y >= ExcellentPos.y - extension && checkCheckPos == true)
        {
            checkCheckPos = false;
            //Pisteet + 10
            RythmScore.SharedRythmScore.score += excellentPoint;
            //Joku indikaattori siitä, että pelaaja onnistui
            GameObject ExcellentObject = Instantiate(Excellent, feedbackPos, gameObject.transform.rotation) as GameObject;
            transform.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(waitAnimStop(waitingTime, ExcellentObject));
        }
    }

    IEnumerator waitAnimStop(float waitTime, GameObject destroyable)
    {
        speed = 0;
        yield return new WaitForSeconds(waitTime);
        Destroy(destroyable);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    IEnumerator ChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Break", LoadSceneMode.Single);
    }
}