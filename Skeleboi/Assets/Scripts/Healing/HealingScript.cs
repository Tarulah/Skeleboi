using UnityEngine;
using System.Collections;

public class HealingScriptFractureCount
{
    private static HealingScriptFractureCount FractureCountInstance = null;
    public static HealingScriptFractureCount SharedFractureCount
    {
        get
        {
            if (FractureCountInstance == null)
            {
                FractureCountInstance = new HealingScriptFractureCount();
            }
            return FractureCountInstance;
        }
    }
    public int fractures = 17;
}

public class HealingScript : MonoBehaviour {

    public int fadeSpeed = 3;
    public Renderer rend;

    private bool isDone = false;
    private Color matCol;
    private Color newColor;
    private float alfa = 0;

	// Use this for initialization
	void Start () {

        HealingScriptFractureCount.SharedFractureCount.fractures = 17;
        matCol = rend.material.color;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        fadeOut();
    }

    void fadeOut()
    {
        if (!isDone)
        {
            alfa = rend.material.color.a - Time.deltaTime / (fadeSpeed == 0 ? 1 : fadeSpeed);
            newColor = new Color(matCol.r, matCol.g, matCol.b, alfa);
            rend.material.SetColor("_Color", newColor);
            isDone = alfa <= 0 ? true : false;
            if(alfa <= 0)
            {
                HealingScriptFractureCount.SharedFractureCount.fractures -= 1;
                Debug.Log(HealingScriptFractureCount.SharedFractureCount.fractures);
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
