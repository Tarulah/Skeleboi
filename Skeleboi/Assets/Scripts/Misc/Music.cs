using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {

    // RHYTHMIIN OMA MUSA JA SEN JÄLKEEN TAKAISIN PELIMUSA
    private static Music instanceRef = null;
    public bool destroyed;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Awake()
    {
        if(instanceRef == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        CheckRhythm();
    }

    void CheckRhythm()
    {
        while(SceneManager.GetActiveScene().name == "Rhythm")
        {
            gameObject.SetActive(false);
        }

        gameObject.SetActive(true);
    }
}
