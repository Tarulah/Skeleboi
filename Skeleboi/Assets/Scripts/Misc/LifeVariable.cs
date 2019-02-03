using UnityEngine;
using System.Collections;

public class Life {

    private static Life LifeVariableInstance = null;
    public static Life SharedLifeVariable
    {
        get
        {
            if (LifeVariableInstance == null)
            {
                LifeVariableInstance = new Life();
            }
            return LifeVariableInstance;
        }
    }
    public int lives = 3;
}

public class LifeVariable : MonoBehaviour { }