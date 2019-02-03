using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadedLevel
{
    private static LoadedLevel LoadedLevelInstance = null;
    public static LoadedLevel SharedLevel
    {
        get
        {
            if (LoadedLevelInstance == null)
            {
                LoadedLevelInstance = new LoadedLevel();
            }
            return LoadedLevelInstance;
        }
    }
    public string loadedLevel;
}

public class BreakScript : MonoBehaviour {

	public float timer = 5f;
    int i = 0;
    int j = 3;
	private static BreakScript instanceRef = null;
    Animator anim1, anim2, anim3;
	Text text;

    int DragNDropID = 3;
    int ClickClickID = 4;
    //int RhythmID = 5;
    int DressUpID = 5;
    int TrampolineID = 6;
    //int ShootingID = 9;
    int SpaceID = 7;
    int HealingID = 8;

    public void Awake (){

		text = GetComponent <Text> ();

		if (instanceRef == null) {
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

    void Start() {

        Cursor.visible = true;
    }

	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        CheckSuccess();
        takeLife();

        RandomScene();

        ShowText();
	}

    void CheckSuccess() {
        //jos minipeli scriptien success on false, vie elämän
        if (Success.SharedSuccess.success == false)
        {
            Life.SharedLifeVariable.lives--;

            Success.SharedSuccess.success = true;

            if (Life.SharedLifeVariable.lives == 0)
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
    }

    void takeLife() {
        for (j = 3; j > Life.SharedLifeVariable.lives; j--)
        {
            if (j == 3 && GameObject.Find("Life3") != null)
            {
                //anim3.SetBool("LoseLife3", true);
                //StartCoroutine(animDelay(2f));
                Destroy(GameObject.Find("Life" + j));
            }
            else if (j == 2 && GameObject.Find("Life2") != null)
            {
                //anim2.SetBool("LoseLife2", true);
                //StartCoroutine(animDelay(2f));
                Destroy(GameObject.Find("Life" + j));
            }
            else if (j == 1 && GameObject.Find("Life1") != null)
            {
                //anim1.SetBool("LoseLife1", true);
                //StartCoroutine(animDelay(2f));
                Destroy(GameObject.Find("Life" + j));
            }
        }
    }

    void RandomScene() {
        //arpoo satunnaisen scenen
        if (timer <= 0)
        {
            int CheckID = 0;
            //KATSO VIELÄ SCENEJEN NUMEROT KUNTOON TÄSSÄ
            int sceneID = Random.Range(4, 9);
            while (sceneID == CheckID)
            {
                sceneID = Random.Range(4, 9);
            }
            CheckID = sceneID;
            SceneManager.LoadScene(sceneID, LoadSceneMode.Single);
        }

    }

    void ShowText()
    {
        //Näyttää pisteet
        if (text != null)
        {
            text.text = "Score: " + GameScore.SharedGameScore.gameScore;
        }
    }

    IEnumerator animDelay(float TimeVar)
    {
        yield return new WaitForSeconds(TimeVar);
        Destroy(GameObject.Find("Life" + j));
    }
}
