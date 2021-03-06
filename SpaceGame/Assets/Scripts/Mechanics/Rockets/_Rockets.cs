﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class _Rockets : MonoBehaviour
{
    /// <summary>
    /// [Constant!] is used to define gravity
    /// </summary>
    public int G = 100000;

    /// <summary>
    /// Mass of the Rocket(stage) in kg
    /// </summary>
    public float Mass;

    /// <summary>
    /// The current Speed of the rocket in x,y coordinates
    /// [v]=m/s
    /// </summary>
    public Vector2 Velocity;

    /// <summary>
    /// The starting Velocity (can be 0,0) of the rocket
    /// </summary>
    public Vector2 StartingVelocity;

    /// <summary>
    /// The Rockets current Orientation(0-k*2PI)
    /// [orientation]=rad
    /// Orientation Counterclockwise! ; origin(1,0)
    /// </summary>
    public int Orientation;

    /// <summary>
    /// The rate at which the orientation changes (angular velocity)
    /// [omega]=rad/s
    /// </summary>
    public float AngularVelocity;

    /// <summary>
    /// The rate at which the Angular Velocity changes (angular accelaration)
    /// [AngularAccelaration]=rad*s^-2
    /// </summary>
    public float AngularAcceleration;

    /// <summary>
    /// The force with which the rocket propels itself (2-Dimensional)
    /// [F]=m*a
    /// => a = Force/Mass
    /// </summary>
    public Vector2 Force;

    /// <summary>
    /// Current Temperature of the Rocket
    /// [T]=°C
    /// </summary>
    public int Temperature;

    /// <summary>
    /// Critical Temperature at which the rocket will have some serious problems
    /// [T]=°C
    /// </summary>
    public int MaxTemperature;

    /// <summary>
    /// The thrusting Power of a rocket
    /// [F]=N
    /// </summary>
    public float Thrust;

    /// <summary>
    /// The Torque defines how fast the rocket can turn
    /// </summary>
    public float Torque;

    /// <summary>
    /// The mass of the fuel of the rocket
    /// [F] = kg
    /// </summary>
    public float Fuel;

    ///<summary>
    /// The efficiency of the attached engine
    /// [F] = s
    /// </summary>
    public float Isp;

    //----------------------------------------------------------
    // Forcefields etc.
    //----------------------------------------------------------
    ///// <summary>
    ///// magnitude of the force
    ///// </summary>
    //public float ForceValue = 0;
    

    /// <summary>
    /// Airresistance in Newtons
    /// F=c_w * A * 1/2 ρ * v^2
    /// </summary>
    public int Drag = 0;

    /// <summary>
    /// Drag Coefficient c_w for airresistance calculatiosn
    /// F=c_w * A * 1/2 ρ * v^2
    /// </summary>
    public int DragCoefficient = 1;

    /// <summary>
    /// CrossSectionArea A stores the Cross Section Area /Querschnittsflläche/ of the rocket
    /// [A] = m^2
    /// </summary>
    public float CrossSectionArea = 1;

    public ParticleSystem pr;

    /// <summary>
    /// Applies gravitational Force to an object.
    /// </summary>
    /// <param name="rb">The Rigidbody to which the force will be applied (e.g. Rockets)</param>
    /// <param name="ObjectPos">The Planet with which the "Rigidbody" will interact.</param>
    public void ApplyGravity(Rigidbody2D rb, _Planet planet)
    {
        Vector2 planetPosition = planet.GetPosition();
        Vector2 ForceDirection = new Vector2(planetPosition.x - transform.position.x, planetPosition.y - transform.position.y); //direction from which to go towards center of oscillation
        float ForceValue = (float)((planet.GetMass() * Mass) / Math.Pow(ForceDirection.magnitude, 2)); // how strong the force is (G Mm / r^2) simplified (currently no G)
        rb.AddForce(ForceDirection.normalized * ForceValue);
     
    }
    /// <summary>
    /// Enables Rocket to get controlled by Player Instance
    /// </summary>
    /// <param name="rb">The Rigidbody to which the force will be applied (e.g. Rockets)</param>
    public void Controlling(Rigidbody2D rb)
    {
        if (Time.timeScale == 1f)
        {
            if (Fuel > 0)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    rb.AddRelativeForce(new Vector2(0, 1) * Thrust);
                    Fuel = Fuel - Thrust / Isp * Time.deltaTime;
                    Mass = Mass - Thrust / Isp * Time.deltaTime;
                    pr.Play();
                }
                else
                {
                    pr.Stop();
                }
            }
            else
            {
                Fuel = 0;
                pr.Stop();
            }


            if (Input.GetKey(KeyCode.A))
            {
                rb.AddTorque(Torque);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(-Torque);
            }
        }
    }

    public void ApplyDrag(Rigidbody2D rb, float density, Vector2 WindSpeedDirection)
    {
        //F = c_w * A * 1 / 2 ρ* v^2
        float ForceMagnitude =(float) (DragCoefficient * CrossSectionArea / 2 * density * rb.velocity.sqrMagnitude);
        float WindSpeedDirectionDiff =(float)( rb.velocity.magnitude*Math.Cos(Vector2.Angle(WindSpeedDirection, rb.velocity))); //Difference between Rocket velocity and wind speed
        float WindForceMagnitude = (float)(DragCoefficient * CrossSectionArea / 2 * density * Math.Pow(WindSpeedDirectionDiff,2));


        //       negative velocity direction *      Drag      +     Direction of Wind         * Speed of wind
        rb.AddForce( -rb.velocity.normalized * ForceMagnitude + WindSpeedDirection.normalized * WindForceMagnitude);
    }

    //ELLIPSEN

    public new Camera camera;
    public LineRenderer lr;
    public int segments;
    public double a;
    public double b;
    public Vector2 PlanetDirection;
    public float angle;
    public double FocusPointDistance;
    public Vector2 FocusPointDirection;
    public double StretchingFactor;
    public Vector2 FocusPoint;
    public Vector2 Center;
    public float SteigungCenterLine;
    public float rotatedAngle;
    public Vector2 e;
    public Vector2 PlanetPosition;

    public void CalculateEllipse(Rigidbody2D rb, _Planet planet)
    {
            PlanetPosition = planet.GetPosition();
            PlanetDirection = new Vector2(PlanetPosition.x - rb.position.x, PlanetPosition.y - rb.position.y);
            a = 1 / ((2 / PlanetDirection.magnitude) - (rb.velocity.sqrMagnitude /planet.GetMass()));   
            angle = Vector2.SignedAngle(PlanetDirection, rb.velocity) * Mathf.Deg2Rad;
            
            if (angle >= 0.001 || angle <= -0.001) // avoids console error when angle too small
            {
                FocusPointDistance = 2 * a - PlanetDirection.magnitude;
                FocusPointDirection = new Vector2(PlanetDirection.x * Mathf.Cos(Mathf.PI + 2 * angle) - PlanetDirection.y * Mathf.Sin(Mathf.PI + 2 * angle), PlanetDirection.x * Mathf.Sin(Mathf.PI + 2 * angle) + PlanetDirection.y * Mathf.Cos(Mathf.PI + 2 * angle));
                StretchingFactor = FocusPointDistance / PlanetDirection.magnitude;
                FocusPoint = new Vector2(rb.position.x + (float)FocusPointDirection.x * (float)StretchingFactor, rb.position.y + (float)FocusPointDirection.y * (float)StretchingFactor);
                Center = new Vector2(FocusPoint.x + (PlanetPosition.x - FocusPoint.x) / 2, FocusPoint.y + (PlanetPosition.y - FocusPoint.y) / 2);
                SteigungCenterLine = (PlanetPosition.y - FocusPoint.y) / (PlanetPosition.x - FocusPoint.x);
                rotatedAngle = Mathf.Atan(SteigungCenterLine);
                e = new Vector2((PlanetPosition.x - FocusPoint.x) / 2, (PlanetPosition.y - FocusPoint.y) / 2);
                b = Mathf.Sqrt(Mathf.Pow((float)a, 2) - Mathf.Pow(e.magnitude, 2));

                DrawEllipse();
            }
        
    }

    void DrawEllipse()
    {
        segments = 10000;
        Vector3[] points = new Vector3[segments + 1];

        for (int i = 0; i < segments; i++)
        {
            float angleEllipse = ((float)i / (float)segments) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Sin(angleEllipse) * (float)a;
            float y = Mathf.Cos(angleEllipse) * (float)b;
            float xrotated = x * Mathf.Cos(rotatedAngle) - y * Mathf.Sin(rotatedAngle);
            float yrotated = x * Mathf.Sin(rotatedAngle) + y * Mathf.Cos(rotatedAngle);
            float xtranslated = xrotated + Center.x;
            float ytranslated = yrotated + Center.y;
            points[i] = new Vector3(xtranslated, ytranslated, 1f);
        }
        points[segments] = points[0];

        if (camera.orthographicSize < 10)
        {
            lr.positionCount = 0;
        }
        else
        {
            lr.positionCount = segments + 1;
            lr.SetPositions(points);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


//edited on ma ipad lelz
