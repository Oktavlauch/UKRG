using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class _Rockets : MonoBehaviour
{
    /// <summary>
    /// Mass of the Rocket(stage) in kg
    /// </summary>
    int Mass;

    /// <summary>
    /// The current Speed of the rocket in x,y coordinates
    /// [v]=m/s
    /// </summary>
    Vector2 Velocity;

    /// <summary>
    /// The Rockets current Orientation(0-k*2PI)
    /// [orientation]=rad
    /// Orientation Counterclockwise! ; origin(1,0)
    /// </summary>
    int Orientation;

    /// <summary>
    /// The rate at which the orientation changes (angular velocity)
    /// [omega]=rad/s
    /// </summary>
    float AngularVelocity;

    /// <summary>
    /// The rate at which the Angular Velocity changes (angular accelaration)
    /// [AngularAccelaration]=rad*s^-2
    /// </summary>
    float AngularAcceleration;

    /// <summary>
    /// The force with which the rocket propels itself (2-Dimensional)
    /// [F]=m*a
    /// => a = Force/Mass
    /// </summary>
    Vector2 Force;

    /// <summary>
    /// Current Temperature of the Rocket
    /// [T]=°C
    /// </summary>
    int Temperature;

    /// <summary>
    /// Critical Temperature at which the rocket will have some serious problems
    /// [T]=°C
    /// </summary>
    int MaxTemperature;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
