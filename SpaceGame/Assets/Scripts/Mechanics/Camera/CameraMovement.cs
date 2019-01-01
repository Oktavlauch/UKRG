using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour

   
{
    //creating desired traget to follow
    public Transform target;

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
    }

    // Update is called once per frame after Update was called
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
