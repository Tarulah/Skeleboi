using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public Button start, credits,  exit, back;

    public Canvas creditsCanvas;

    float growX = 0.05f;
    float growY = 0.0625f;

    float startX, startY;
    float credX, credY;
    float exitX, exitY;
    float backX, backY;

    float volume = 0.5f;

    AudioClip buttonSound, buttonSound1, buttonSound2, backButtonSound;

    void Start()
    {
        startX = start.transform.localScale.x;
        startY = start.transform.localScale.y;
        credX = credits.transform.localScale.x;
        credY = credits.transform.localScale.y;
        exitX = exit.transform.localScale.x;
        exitY = exit.transform.localScale.y;
        backX = back.transform.localScale.x;
        backY = back.transform.localScale.y;

        creditsCanvas = creditsCanvas.GetComponent<Canvas>();

        start = start.GetComponent<Button>();
        credits = credits.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
        back = back.GetComponent<Button>();

        creditsCanvas.enabled = false;

        start.enabled = true;
        credits.enabled = true;
        exit.enabled = true;
        back.enabled = false;

        // Button audio
        //buttonSound = Resources.Load("coin") as AudioClip;
        //buttonSound1 = Resources.Load("pikachu") as AudioClip;
        //buttonSound2= Resources.Load("linkhyaa") as AudioClip;
        backButtonSound = Resources.Load("ButtonOff") as AudioClip;
    }

    // CLICKED START
    public void Play()
    {
        SceneManager.LoadScene("DragNDropIntro", LoadSceneMode.Single);
    }

    // CLICKED HELP
    public void Credits()
    {
        creditsCanvas.enabled = true;

        start.enabled = false;
        credits.enabled = false;
        exit.enabled = false;
        back.enabled = true;
    }

    // EXIT GAME
    public void ExitGame()
    {
        Application.Quit();
    }

    // CLICKED BACK TO THE FRONT PAGE
    public void FrontPage()
    {
        creditsCanvas.enabled = false;

        start.enabled = true;
        credits.enabled = true;
        exit.enabled = true;
        back.enabled = false;
    }

    public void StartBigger()
    {
        start.transform.localScale = new Vector3(startX + growX, startY + growY, 0);
        AudioSource.PlayClipAtPoint(buttonSound, new Vector3(0, 0, -10), 1f);
    }

    public void CreditsBigger()
    {
        credits.transform.localScale = new Vector3(credX + growX, credY + growY, 0);
        AudioSource.PlayClipAtPoint(buttonSound1, new Vector3(0, 0, -10), volume);
    }

    public void ExitBigger()
    {
        exit.transform.localScale = new Vector3(exitX + growX, exitY + growY, 0);
        AudioSource.PlayClipAtPoint(buttonSound2, new Vector3(0, 0, -10), volume);
    }

    public void BackBigger()
    {
        back.transform.localScale = new Vector3(backX + growX, backY + growY, 0);
        AudioSource.PlayClipAtPoint(backButtonSound, new Vector3(0, 0, -10), volume);
    }

    public void StartSmaller()
    {
        start.transform.localScale = new Vector3(startX, startY, 0);
    }

    public void CreditsSmaller()
    {
        credits.transform.localScale = new Vector3(credX, credY, 0);
    }

    public void ExitSmaller()
    {
        exit.transform.localScale = new Vector3(exitX, exitY, 0);
    }

    public void BackSmaller()
    {
        back.transform.localScale = new Vector3(backX, backY, 0);
    }
}
