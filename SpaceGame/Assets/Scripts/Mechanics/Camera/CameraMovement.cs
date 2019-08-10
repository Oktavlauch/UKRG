using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float targetangle;
    private int RotationSpeed;
    //creating desired traget to follow
    public Transform target;

    public _Rockets rocket;

    //Adding Vector3 to offset camera position in z axis
    private Vector3 offset;


    //Start is called at the Start
    void Start()
    {   
        //sets the camera position to target position at the Start
        var pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y;
        transform.position = pos;

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - target.transform.position;


        //Following Lines are for Rotation (not yet working)
       // Ellipsen ellipsen;

       // ellipsen = GameObject.FindWithTag("Player").GetComponent<Ellipsen>();

        
    }

    //Update is called once per frame
    void Update()
    {
        Zoom();
        
        //RotateCamera();

    }

    // Update is called once per frame after Update was called
    void LateUpdate()
    {
        transform.position = target.position + offset;
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


  /*public void RotateCamera()
    {
        RotationSpeed = 50;
        targetangle = Mathf.Atan(rocket.PlanetDirection.y / rocket.PlanetDirection.x) * Mathf.Rad2Deg;

        if (transform.rotation.eulerAngles.z > (90 - targetangle))
        {
            transform.Rotate(Vector3.back, RotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward, RotationSpeed * Time.deltaTime);
        }
    }*/
}
