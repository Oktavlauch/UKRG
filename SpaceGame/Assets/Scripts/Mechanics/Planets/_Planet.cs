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

    public Vector2 GetPosition()
    {
        CurrentPosition = new Vector2(transform.position.x,transform.position.y);
        return CurrentPosition;
    }
}
