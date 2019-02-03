using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShootingSceneManager : MonoBehaviour {

    public Slider MilkBar;
    bool won = false;

	// Use this for initialization
	void Start () {
        LoadedLevel.SharedLevel.loadedLevel = "Shooting";
    }
	
	// Update is called once per frame
	void Update () {
        MilkBar.value = ShootCatsScore.SharedShootScore.ShootingScore;

        if(ShootCatsScore.SharedShootScore.ShootingScore >= 100 && !won)
        {
            GameScore.SharedGameScore.gameScore++;
            won = true;
            SceneManager.LoadScene("Break", LoadSceneMode.Single);
        }
        else if(ShootCatsScore.SharedShootScore.ShootingScore <= 0)
        {
            Success.SharedSuccess.success = false;
            SceneManager.LoadScene("Break", LoadSceneMode.Single);
        }
    }
}
