﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
abstract public class _Planet : MonoBehaviour
{
    //PlanetVariables:
    /// <summary>
    /// Mass of Planet in kg
    /// </summary>
    public int Mass;

    /// <summary>
    /// Pressure of Planet on Surfacelevel
    /// Surfacelevel = rSurface
    /// </summary>
    public int StandardPressure;

    /// <summary>
    /// Rotation of Planet around itself
    /// </summary>
    public int RotationSpeed;

    /// <summary>
    /// r (in Meters) from Centre of Mass to Surfacelevel
    /// </summary>
    public int DistanceSurface;

    /// <summary>
    /// r (in Meters) between the center of Mass of the Planet to it's Center of Rotation (e.g. Sun)
    /// </summary>
    public int DistanceRotatingObject;

    /// <summary>
    /// The Speed at which a Planet is going (m/s)
    /// </summary>
    public int Speed;

    /// <summary>
    /// r (in Meters) from Center of Mass to end of Sphere of Influence
    /// </summary>
    public int DistanceSphereOfInfluence;

    /// <summary>
    /// The Starting position of the planet at t(0)
    /// May be subject to change
    /// </summary>
    public Vector2 PositionNaught;

    /// <summary>
    /// The current posiiton of the planet at t(t)
    /// <!--May be subject to change; development assistance-->
    /// </summary>
    public Vector2 CurrentPosition;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPosition = transform.position;
    }

    /// <summary>
    /// Updates Position of Planet
    /// </summary>
    /// <returns>Position of Planet as Vector2</returns>
    public Vector2 GetPosition()
    {
        CurrentPosition = new Vector2(transform.position.x,transform.position.y);
        return CurrentPosition;
    }
    /// <summary>
    /// Mass of a Planet
    /// </summary>
    /// <returns>Mass of Planet in kg</returns>
    public int GetMass()
    {
        return Mass;
    }

    /// <summary>
    /// Pressure of Planet on Surfacelevel
    /// </summary>
    /// <returns>Returns Pressure in Pascal</returns>
    public int GetPressure()
    {
        return StandardPressure;
    }

    /// <summary>
    /// The Surfacelevel is the distance from the center of the planet to its surface
    /// </summary>
    /// <returns>Returns the distance r (radius) from the center of the planet to its surface in [r]=m</returns>
    public int GetSurfaceLevel()
    {
        return DistanceSurface;
    }


    /// <summary>
    /// IsInRange checks if a certain Point (Coordinate) is within the sphere of influence of a Planet.
    /// </summary>
    /// <param name="Pos">Pos is the position of the Point (World Coordinates) to be checked</param>
    /// <returns>Returns true if the point is within the sphere of influence</returns>
    public bool IsInRange(Vector2 Pos)
    {
        bool InRange = false;
        if(Vector2.Distance(Pos, GetPosition()) <= DistanceSphereOfInfluence){
            InRange = true;
        }
        return InRange;
    }

    /// <summary>
    /// Rigidbody for Planet;
    /// </summary>
    public Rigidbody2D rb;
    
    //public void Rotate()
    //{
    //    rb.GetComponent<Rigidbody2D>();
    //    rb.angularVelocity = RotationSpeed;
    //}
}
