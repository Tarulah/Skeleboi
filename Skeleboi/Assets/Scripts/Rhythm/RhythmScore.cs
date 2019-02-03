using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RythmScore
{
    private static RythmScore RythmScoreInstance = null;
    public static RythmScore SharedRythmScore
    {
        get
        {
            if (RythmScoreInstance == null)
            {
                RythmScoreInstance = new RythmScore();
            }
            return RythmScoreInstance;
        }
    }
    public float score = 1f;
}

//public class RhythmScore: MonoBehaviour
//{
//    public Slider milkBar;

//    void Start()
//    {        
//        LoadedLevel.SharedLevel.loadedLevel = "Rhythm";
        
//    }

//    void Update()
//    {
//        milkBar.value = RythmScore.SharedRythmScore.score;
//    }
//}


