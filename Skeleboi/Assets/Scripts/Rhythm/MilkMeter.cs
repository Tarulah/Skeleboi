using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MilkMeter : MonoBehaviour
{

    public Slider MilkBar;
    public bool won = false;

    void Start()
    {
        RythmScore.SharedRythmScore.score = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        MilkBar.value = RythmScore.SharedRythmScore.score;

        if (RythmScore.SharedRythmScore.score >= 100 && !won)
        {
            CheckPoints();
            won = true;
        }
    }

    void CheckPoints()
    {
        GameScore.SharedGameScore.gameScore++;
    }
}