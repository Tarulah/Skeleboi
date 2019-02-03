using UnityEngine;
using System.Collections;

public class Success {
    private static Success SuccessInstance = null;
    public static Success SharedSuccess
    {
        get
        {
            if (SuccessInstance == null)
            {
                SuccessInstance = new Success();
            }
            return SuccessInstance;
        }
    }
    public bool success = true;
}

public class SuccessScript : MonoBehaviour
{

}
