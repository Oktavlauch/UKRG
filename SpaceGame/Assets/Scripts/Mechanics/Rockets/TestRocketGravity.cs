﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRocketGravity : MonoBehaviour
{
    /// <summary>
    /// magnitude of the force
    /// </summary>
    float ForceValue=1;
    /// <summary>
    /// direction of the force
    /// </summary>
    Vector2 ForceDirection;
    /// <summary>
    /// Position of the "planet" or point around which to rotate
    /// </summary>
    Vector2 ObjectPos = new Vector2(1.0f, 0.0f);
    /// <summary>
    /// Velocity of the rocket at the beginning
    /// </summary>
    Vector2 StartVelocity=new Vector2(0,1);

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = StartVelocity;
    }

    // Update is called once per frame
    /// <summary>
    /// Adds Force and changes it according to currentposition;
    /// </summary>
    void Update()
    {
        ForceDirection = new Vector2(ObjectPos.x - transform.position.x, ObjectPos.y - transform.position.y);//direction from which to go towards center of oscillation
        ForceValue = (float) (1 / Math.Pow(ForceDirection.magnitude,2));//The how strong the force is (Q Mm / r^2) simplified
        rb.AddRelativeForce(ForceDirection.normalized * ForceValue);
    }
}