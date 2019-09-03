using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpForwards : MonoBehaviour
{
    public void Faster()
        {
        Time.timeScale = 5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
