using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class _Planet : MonoBehaviour
{
    //PlanetVariables:
    /// <summary>
    /// Mass of Planet in kg
    /// </summary>
    int Mass;
    /// <summary>
    /// Pressure of Planet on Surfacelevel
    /// Surfacelevel = rSurface
    /// </summary>
    int StandardPressure;
    /// <summary>
    /// Rotation of Planet around itself
    /// </summary>
    int RotationSpeed;

    /// <summary>
    /// r (in Meters) from Centre of Mass to Surfacelevel
    /// </summary>
    int DistanceSurface;
    /// <summary>
    /// r (in Meters) between the center of Mass of the Planet to it's Center of Rotation (e.g. Sun)
    /// </summary>
    int DistanceRotatingObject;

    /// <summary>
    /// The Speed at which a Planet is going (m/s)
    /// </summary>
    int Speed;
    /// <summary>
    /// The Starting position of the planet at t(0)
    /// May be subject to change
    /// </summary>
    Vector2 PositionNaught;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
