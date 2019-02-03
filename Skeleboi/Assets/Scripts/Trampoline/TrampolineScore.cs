using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrampoScore
{
    private static TrampoScore TrampoScoreInstance = null;
    public static TrampoScore SharedTrampoScore
    {
        get
        {
            if (TrampoScoreInstance == null)
            {
                TrampoScoreInstance = new TrampoScore();
            }
            return TrampoScoreInstance;
        }
    }
    public float score = 11f;
}

public class TrampolineScore : MonoBehaviour {

    public Slider milkBar;
    bool won = false;

    void Start()
    {
        TrampoScore.SharedTrampoScore.score = 11f;
    }

	void Update ()
    {
        milkBar.value = TrampoScore.SharedTrampoScore.score;

        WinLose();
    }

    void WinLose()
    {
        if (TrampoScore.SharedTrampoScore.score >= 60 && !won) {
			GameScore.SharedGameScore.gameScore++;
            won = true;
			SceneManager.LoadScene ("Break", LoadSceneMode.Single);

		} else if (TrampoScore.SharedTrampoScore.score <= 0) {
			Success.SharedSuccess.success = false;
			SceneManager.LoadScene ("Break", LoadSceneMode.Single);
		}
    }
}
