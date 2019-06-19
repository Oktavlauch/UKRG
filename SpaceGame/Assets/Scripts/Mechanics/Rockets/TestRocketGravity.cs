using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestRocketGravity : _Rockets
{
    public TestPlanet testPlanet;
    
    /// <summary>
    /// Position of the "planet" or point around which to rotate
    /// </summary>
    Vector2 ObjectPos;
    /// <summary>
    /// Velocity of the rocket at the beginning
    /// </summary>

    private Rigidbody2D rb;
    //private bool KeyPressed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = StartingVelocity;
        rb.mass = Mass;
    }

    private void LateUpdate()
    {
        
    }
    // Update is called once per frame
    /// <summary>
    /// Adds Force and changes it according to currentposition;
    /// </summary>
    void FixedUpdate()
    {
        //Moved to SuperClass;
        //ObjectPos = testPlanet.GetPosition();
        ////KeyPressed = false;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    rb.AddRelativeForce(new Vector2(0, 1) * Thrust);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.AddTorque(Torque);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    rb.AddTorque(-Torque);
        //}
        //ForceDirection = new Vector2(ObjectPos.x - transform.position.x, ObjectPos.y - transform.position.y); //direction from which to go towards center of oscillation
        //ForceValue = (float) ((testPlanet.GetMass()* Mass)/ Math.Pow(ForceDirection.magnitude,2)); //The how strong the force is (G Mm / r^2) simplified
        //rb.AddForce(ForceDirection.normalized * ForceValue);

        ApplyForce(rb, testPlanet);
        //ApplyDrag(rb, testPlanet.GetDensity(rb.position), testPlanet.AirSpeedDirection(rb.position));
        //rb.velocity = (testPlanet.AirSpeedDirection(rb.position));

    }
}
//G=0.0000000000667408