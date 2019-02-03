using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public int sceneId;
    public float waitTime;

    void Start() {
        StartCoroutine(SceneChange());
    }

	// Update is called once per frame
	IEnumerator SceneChange () {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneId, LoadSceneMode.Single);
    }
}
