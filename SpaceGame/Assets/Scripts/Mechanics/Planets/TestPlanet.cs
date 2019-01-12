using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlanet : _Planet
{

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();

        rb.IsAwake();
        rb.gravityScale = 0;
        rb.angularDrag = 0;
        rb.mass = GetMass();
        //rb.freezeRotation();
        //Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = RotationSpeed;
    }

}
