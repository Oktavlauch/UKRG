using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpForwards : MonoBehaviour
{
    public void Faster()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 5f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else if(Time.timeScale == 5f)
        {
            Time.timeScale = 10f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else if (Time.timeScale == 10f)
        {
            Time.timeScale = 100f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
}
