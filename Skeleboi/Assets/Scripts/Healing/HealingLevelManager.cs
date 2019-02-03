using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealingLevelManager : MonoBehaviour {

    public Slider MilkBar;

    float timer = 100;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        timer = timer - Time.deltaTime;
        MilkBar.value = timer;

        winOrLose();
	}

    void winOrLose()
    {
        if(HealingScriptFractureCount.SharedFractureCount.fractures == 0)
        {
            //JEEE VOITIT
            SceneManager.LoadScene("Break", LoadSceneMode.Single);
        }
        else if(timer <= 0)
        {
            //Nyyh hävisit
            Success.SharedSuccess.success = false;
            SceneManager.LoadScene("Break", LoadSceneMode.Single);
        }
    }
}
