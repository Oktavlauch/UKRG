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


    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 1f;
        lr.endWidth = 1f;
        lr.sortingOrder = 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = StartingVelocity;
        rb.mass = Mass;
    }

    private void LateUpdate()
    {
        CalculateEllipse(rb, testPlanet); 
    }
    // Update is called once per frame
    /// <summary>
    /// Adds Force and changes it according to currentposition;
    /// </summary>
    void FixedUpdate()
    {
        ApplyGravity(rb, testPlanet);
        Controlling(rb);
        //ApplyDrag(rb, testPlanet.GetDensity(rb.position), testPlanet.AirSpeedDirection(rb.position));
        //rb.velocity = (testPlanet.AirSpeedDirection(rb.position));

    }
}
//G=0.0000000000667408