using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
  

    public void Zoomout()
    {
        Camera.main.orthographicSize = 3000f;
    }
}
