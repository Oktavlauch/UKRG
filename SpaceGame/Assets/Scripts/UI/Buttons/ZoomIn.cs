using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{


    public void Zoomin()
    {
        Camera.main.orthographicSize = 10f;
    }
}

