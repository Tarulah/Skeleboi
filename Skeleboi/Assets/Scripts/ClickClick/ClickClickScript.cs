using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class ClickClickMilkBar
{
    private static ClickClickMilkBar MilkBarInstance = null;
    public static ClickClickMilkBar SharedMilkBar
    {
        get
        {
            if (MilkBarInstance == null)
            {
                MilkBarInstance = new ClickClickMilkBar();
            }
            return MilkBarInstance;
        }
    }
    public float milkMeter = 50f;
}

public class ClickClickScript : MonoBehaviour
{

    public Slider Milkbar;
    public GameObject splash;
    public GameObject RedBeam;
    public GameObject BlueBeam;
    GameObject Beam;
    int delay = 10;

    // KORJAA VÄHENEMISTÄ NIIN ETTÄ EI VÄHENE KUN KASVAA, VÄHENEE SILLOIN KUN EI PAINETA
    float grow = 0.03f;
    float shrink = 0.001f;
    float maxX = 0.3450886f;
    float maxY = 0.3450886f;

    public bool max = false;

    float changeSceneTime = 2f;

    Animator anim;

    bool wonGame = false;

    void Start()
    {
        ClickClickMilkBar.SharedMilkBar.milkMeter = 50;
        anim = GameObject.Find("Skeleboi").GetComponent<Animator>();
        Instantiate(RedBeam);
        splash.transform.localScale = new Vector3(0, 0, 0);

        LoadedLevel.SharedLevel.loadedLevel = "ClickClick";
    }

    //Tarkistaa, ollaanko maitopurkin päällä
    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && gameObject.name == "maitopurkki")
        {
            //kasvattaa mittaria, kun klikataan
            if (GameObject.Find("BlueBeamPrefab(Clone)") == null)
            {
                anim.SetBool("IsShootingBeams", true);
                splash.transform.localScale = new Vector3(splash.transform.localScale.x + grow, splash.transform.localScale.y + grow, 0);
                Beam = Instantiate(BlueBeam);
            }
            delay = 10;
            ClickClickMilkBar.SharedMilkBar.milkMeter += 1.5f;
        }

        else if (delay == 0)
        {
            Destroy(Beam);
            anim.SetBool("IsShootingBeams", false);
        }
    }

    void Update()
    {

        anim.GetBool("IsShootingBeams");
        anim.GetBool("Won");
        anim.GetBool("Lost");


        MilkMeter();

        Scale();

        DelayCheck();

        Lose();

        if (!wonGame && ClickClickMilkBar.SharedMilkBar.milkMeter >= 100.0f)
        {
            Win();
            wonGame = true;
        }
    }

    //tarkistaa voittaako pelaaja
    void Win()
    {
        //mahdollisesti jotain animaatiota
        GameScore.SharedGameScore.gameScore++;
        anim.SetBool("Won", true);
        StartCoroutine(ChangeScene(changeSceneTime));
    }

    //tarkistaa häviääkö pelaaja
    void Lose()
    {
        if (ClickClickMilkBar.SharedMilkBar.milkMeter <= 0.0f)
        {
            //mahdollisesti jotain animaatiota
            Success.SharedSuccess.success = false;
            anim.SetBool("Lost", true);
            StartCoroutine(ChangeScene(changeSceneTime));
        }
    }

    void DelayCheck()
    {
        if (delay > 0)
        {
            delay--;
        }
        else
        {
            delay = 10;
        }
    }

    void MilkMeter()
    {
        //vähentää mittaria koko ajan
        if (!wonGame)
        {
            ClickClickMilkBar.SharedMilkBar.milkMeter -= 0.1f;
        }

        splash.transform.localScale = new Vector3(splash.transform.localScale.x - shrink, splash.transform.localScale.y - shrink, 0);

        if (Milkbar.name == "MilkBar")
        {
            Milkbar.value = ClickClickMilkBar.SharedMilkBar.milkMeter;
        }
    }

    void Scale()
    {
        // MIN VALUE
        if (splash.transform.localScale.x < 0 && splash.transform.localScale.y < 0)
        {
            splash.transform.localScale = new Vector3(0, 0, 0);
        }

        // MAX VALUE
        // KORJAA RAJAHDYS NIIN ETTÄ SE PYSYY MAKSIMISSA
        if (splash.transform.localScale.x > maxX && splash.transform.localScale.y > maxY)
        {
            splash.transform.localScale = new Vector3(maxX, maxY, 0);
            shrink = 0;
            max = true;
        }
        else
        {
            shrink = 0.001f;
            max = false;
        }
    }

    IEnumerator ChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Break", LoadSceneMode.Single);
    }
}

