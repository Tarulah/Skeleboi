using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DressUpCheck
{
    private static DressUpCheck DressUpCheckInstance = null;
    public static DressUpCheck SharedDressUpScore
    {
        get
        {
            if (DressUpCheckInstance == null)
            {
                DressUpCheckInstance = new DressUpCheck();
            }
            return DressUpCheckInstance;
        }
    }
    public int flowerTheme = 0;
    public int rainTheme = 0;
    public int relaxedTheme = 0;
}

public class DressUpController : MonoBehaviour
{

    int flowerTheme, rainTheme, relaxedTheme;
    float timer = 15f;
    bool won = false;
    public Slider milkBar;
    public GameObject lostFace, wonFace;
    bool win = false;

    void Start()
    {
        lostFace.SetActive(false);
        wonFace.SetActive(false);

        DressUpCheck.SharedDressUpScore.flowerTheme = 0;
        DressUpCheck.SharedDressUpScore.rainTheme = 0;
        DressUpCheck.SharedDressUpScore.relaxedTheme = 0;

        LoadedLevel.SharedLevel.loadedLevel = "DressUp";
    }

    void Update()
    {

        flowerTheme = DressUpCheck.SharedDressUpScore.flowerTheme;
        rainTheme = DressUpCheck.SharedDressUpScore.rainTheme;
        relaxedTheme = DressUpCheck.SharedDressUpScore.relaxedTheme;

        if ((flowerTheme == 3 || rainTheme == 4 || relaxedTheme == 4) && !win)
        {
            Win();
            win = true;
        }

        Lose();

        Timer();

    }

    void Win()
    {
        won = true;
        GameScore.SharedGameScore.gameScore++;
        // ANIMAATIOT TÄHÄN!!!!
        wonFace.SetActive(true);
        StartCoroutine(ChangeScene(2f));
    }

    void Lose()
    {
        if (timer <= 0)
        {
            Success.SharedSuccess.success = false;
            // ANIMAATIOT TÄHÄN!!!
            lostFace.SetActive(true);
            StartCoroutine(ChangeScene(2f));
        }
    }

    void Timer()
    {
        milkBar.value = timer;

        if (!won)
        {
            timer -= Time.deltaTime;
        }


    }

    IEnumerator ChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Break", LoadSceneMode.Single);
    }
}
