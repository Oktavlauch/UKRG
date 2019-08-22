using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    //Start is called at the Start
    void Start()
    {   
        
    }

    //Update is called once per frame
    void Update()
    {
        Zoom();
        

    }



    public void Zoom()
    {
        //Enables to zoom with the mousewheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize >= 10)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize - 5;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize >= 100)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize - 50;
        }

        //enables finer tuning
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize <= 10)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize - 1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize >= 10)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize + 5;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize >= 100)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize + 50;
        }

        //enables finer tuning
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize <= 10)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize + 1;
        }

        //makes sure Camera doesnt get inverted when <= 0
        if (Camera.main.orthographicSize <= 1)
        {
            Camera.main.orthographicSize = 1;
        }
    }
}
