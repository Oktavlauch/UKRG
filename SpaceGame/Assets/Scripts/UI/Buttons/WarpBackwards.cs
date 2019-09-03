using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBackwards : MonoBehaviour
{
    public void Slower()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
