using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DragNDropBoneCounter {
	private static DragNDropBoneCounter BoneCounterInstance = null;
	public static DragNDropBoneCounter SharedBoneCounter{
		get {
			if(BoneCounterInstance == null){
				BoneCounterInstance = new DragNDropBoneCounter ();
			}
			return BoneCounterInstance;
		}
	}
	public int counter = 0;
}

public class DragNDropTimer {
	private static DragNDropTimer TimerInstance = null;
	public static DragNDropTimer SharedTimer{
		get {
			if(TimerInstance == null){
				TimerInstance = new DragNDropTimer ();
			}
			return TimerInstance;
		}
	}
	public float timer = 100f;
}

public class DragNDropScript : MonoBehaviour {

	public Slider MilkBar;
    public GameObject Skeleboi_prefab;
    public GameObject Skeleboi_parts;

    Animator anim, anim1, anim2, anim3, anim4, anim5, anim6, anim7, anim8, anim9, anim10, anim11, anim12, anim13;

    void Start() {
        anim = GameObject.Find("ThighRightChild").GetComponent<Animator>();
        anim1 = GameObject.Find("ForearmLeftChild").GetComponent<Animator>();
        anim2 = GameObject.Find("ArmLeftChild").GetComponent<Animator>();
        anim3 = GameObject.Find("ThighLeftChild").GetComponent<Animator>();
        anim4 = GameObject.Find("ArmRightChild").GetComponent<Animator>();
        anim5 = GameObject.Find("HandLeftChild").GetComponent<Animator>();
        anim6 = GameObject.Find("HandRightChild").GetComponent<Animator>();
        anim7 = GameObject.Find("ForearmRightChild").GetComponent<Animator>();
        anim8 = GameObject.Find("TorsoChild").GetComponent<Animator>();
        anim9 = GameObject.Find("LegRightChild").GetComponent<Animator>();
        anim10 = GameObject.Find("FootRightChild").GetComponent<Animator>();
        anim11 = GameObject.Find("FootLeftChild").GetComponent<Animator>();
        anim12 = GameObject.Find("HeadChild").GetComponent<Animator>();
        anim13 = GameObject.Find("LegLeftChild").GetComponent<Animator>();

        LoadedLevel.SharedLevel.loadedLevel = "DragNDrop";
    }

	void  Update (){
        if (anim != null | anim1 != null | anim2 != null | anim3 != null | anim4 != null | anim5 != null 
            | anim6 != null | anim7 != null | anim8 != null | anim9 != null | anim10 != null | anim11 != null 
            | anim12 != null | anim13 != null)
        {
            anim.GetBool("TimeUp");
            anim1.GetBool("TimeUp1");
            anim2.GetBool("TimeUp2");
            anim3.GetBool("TimeUp3");
            anim4.GetBool("TimeUp4");
            anim5.GetBool("TimeUp5");
            anim6.GetBool("TimeUp6");
            anim7.GetBool("TimeUp7");
            anim8.GetBool("TimeUp8");
            anim9.GetBool("TimeUp9");
            anim10.GetBool("TimeUp10");
            anim11.GetBool("TimeUp11");
            anim12.GetBool("TimeUp12");
            anim13.GetBool("TimeUp13");
        }


        if(DragNDropBoneCounter.SharedBoneCounter.counter < 14)
        {
            //laskee aikaa
            DragNDropTimer.SharedTimer.timer -= Time.deltaTime;
        }
       
		MilkBar.value = DragNDropTimer.SharedTimer.timer;

        CheckTimeOrWin();

	}


    private IEnumerator WaitForAnimation(float TimeVar)
    {
        yield return new WaitForSeconds(TimeVar);
        SceneManager.LoadScene("Break", LoadSceneMode.Single);
    }


    void CheckTimeOrWin() {
        //Katsoo loppuiko aika
        if (DragNDropTimer.SharedTimer.timer <= 0)
        {
            Success.SharedSuccess.success = false;
            anim.SetBool("TimeUp", true);
            anim1.SetBool("TimeUp1", true);
            anim2.SetBool("TimeUp2", true);
            anim3.SetBool("TimeUp3", true);
            anim4.SetBool("TimeUp4", true);
            anim5.SetBool("TimeUp5", true);
            anim6.SetBool("TimeUp6", true);
            anim7.SetBool("TimeUp7", true);
            anim8.SetBool("TimeUp8", true);
            anim9.SetBool("TimeUp9", true);
            anim10.SetBool("TimeUp10", true);
            anim11.SetBool("TimeUp11", true);
            anim12.SetBool("TimeUp12", true);
            anim13.SetBool("TimeUp13", true);
            StartCoroutine(WaitForAnimation(2f));
        }
        //Tarkistaa voittaako pelaaja
        else if (DragNDropBoneCounter.SharedBoneCounter.counter >= 14)
        {
            GameScore.SharedGameScore.gameScore = 0;
            GameScore.SharedGameScore.gameScore++;
            Skeleboi_parts.SetActive(false);
            Skeleboi_prefab.SetActive(true);
            StartCoroutine(WaitForAnimation(4.45f));

        }
    }
}
