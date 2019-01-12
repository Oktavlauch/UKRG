using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipsen : MonoBehaviour
{
    LineRenderer lr;
    private Rigidbody2D rb;

    public int segments;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        CalculateEllipse();
    }
    public float aSquared;
    public float bSquared;
   
    void CalculateEllipse()
    {
       
    Vector3[] points = new Vector3[segments + 1];

        //public float aSquared = -(rb.position.y * Mathf.Sqrt(rb.position.x)) / rb.velocity.y - (rb.position.y * rb.position.x * rb.velocity.x) / rb.velocity.y + (rb.position.x * rb.position.y) / rb.velocity.y + rb.position.x;
        //public float bSquared = -(rb.position.x * Mathf.Sqrt(rb.position.y)) / rb.velocity.x - (rb.position.x * rb.position.y * rb.velocity.y) / rb.velocity.x + (rb.position.y * rb.position.x) / rb.velocity.x + rb.position.y;


        for (int i = 0; i < segments; i++)
        {
            
    
   
            //
            float angle = ((float)i / (float)segments) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * Mathf.Sqrt(bSquared); //*radius        
            float y = Mathf.Sin(angle) * Mathf.Sqrt(aSquared); //*radius
            points[i] = new Vector3(x, y, 0f);
        }
        points[segments] = points[0];

        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            CalculateEllipse();
        }
    }
}
