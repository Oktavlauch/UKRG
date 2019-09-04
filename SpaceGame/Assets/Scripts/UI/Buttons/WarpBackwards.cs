using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBackwards : MonoBehaviour
{
    public void Slower()
    {
        if (Time.timeScale == 5f)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else if(Time.timeScale == 10f)
        {
            Time.timeScale = 5f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else if (Time.timeScale == 100f)
        {
            Time.timeScale = 10f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
}