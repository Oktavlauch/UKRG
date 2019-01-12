using System;
using System.Collections;
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
    public float StandardPressure=1f;

    /// <summary>
    /// Density of the Air  on Planet Surfacelevel
    /// Surfacelevel = rSurface
    /// </summary>
    public float StandardDensity=1f;

    /// <summary>
    /// Rotation of Planet around itself
    /// </summary>
    public float RotationSpeed;

    /// <summary>
    /// r (in Meters) from Centre of Mass to Surfacelevel
    /// </summary>
    public float DistanceSurface;

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


    /// <summary>
    /// Surface Gravity is the acceleration on a planets surface (used for AirPressure)
    /// [g]=m*s^-1
    /// </summary>
    public float SurfaceGravity=1;
    
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
    public float GetStandardPressure()
    {
        return StandardPressure;
    }
    /// <summary>
    /// Density of air on Planet Surfacelevel
    /// </summary>
    /// <returns></returns>
    public float GetStandardDensity()
    {
        return StandardDensity;
    }

    /// <summary>
    /// The Surfacelevel is the distance from the center of the planet to its surface
    /// </summary>
    /// <returns>Returns the distance r (radius) from the center of the planet to its surface in [r]=m</returns>
    public float GetSurfaceLevel()
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
    /// GetPressure returns the pressure of the planet at a certain height.
    /// Requires the following values to function:
    /// StandardPressure, StandardDensity, SurfaceGravity
    /// As such, to function correctly, these must be set correctly
    /// </summary>
    /// <param name="Pos">Pos is the position of the object, from which the height will be calculated to then get the pressure.</param>
    /// <returns>Pressure at given point</returns>
    public float GetPressure(Vector2 Pos)
    {
        float deltah = Math.Abs(Vector2.Distance(Pos, GetPosition()))-GetSurfaceLevel(); //Distance of Pos to center of planet - Planet radius -> distance from surface to pos (delta h)
        Debug.Log("deltah" + deltah);

        //P2 = P1 × e^[ –g × M / (R × T) × (z2 – z1) ] = FormelBuch := p=p0 *e^[-Rho0*g/p0*h] --(berücksichtigt G Mm/r^2)
        float pressure = (float) (GetStandardPressure() * Math.Pow(Math.E, -(GetStandardDensity() * SurfaceGravity / GetStandardPressure() * deltah)));
        Debug.Log("pressure"+pressure);
        return pressure;
    }

    /// <summary>
    /// Returns the air density Rho at a given position
    /// (requres the GetPressure function to work; ergo, relies on following values:
    /// StandardPressure, StandardDensity, SurfaceGravity
    /// To function correctly, these must be set correctly.
    /// </summary>
    /// <param name="Pos">the given position at which the air density will be calculated</param>
    /// <returns>Density at given point</returns>
    public float GetDensity(Vector2 Pos)
    {
        Debug.Log("density" + GetPressure(Pos) * GetStandardDensity() / GetStandardPressure());
        return GetPressure(Pos) * GetStandardDensity() / GetStandardPressure();
    }

    /// <summary>
    /// Takes a Pos and calculates how fast and in what direction the air is moving at that point
    /// </summary>
    /// <param name="Pos">is the point for which air speed is calculated</param>
    /// <returns>Vecrot2 with direction of air speed and magnitude of speed</returns>
    public Vector2 AirSpeedDirection(Vector2 Pos)
    {
        Vector2 straightLine = Pos- rb.position;//from center of planet to pos
        Vector2 perpendicular = new Vector2(-straightLine.y, straightLine.x); //rotated 90° anticlockwise
        float speedAtHeight = straightLine.magnitude * RotationSpeed;// winkelgeschw. * r

        Debug.Log("AirSpeed" + speedAtHeight * perpendicular.normalized);
        return speedAtHeight * perpendicular.normalized; //speed * direction 
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
