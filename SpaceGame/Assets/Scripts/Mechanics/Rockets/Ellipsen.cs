using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipsen : MonoBehaviour
{
    LineRenderer lr;
    public Rigidbody2D rb;
    public GameObject protoplanet;
    public Rigidbody2D rbplanet;

    public int segments;
    public float a;
    public float b;
    public Vector2 PlanetDirection;
    public float angle;
    public float angleTangente;
    public float midAngle;
    public float resultingAngle;
    public float FocusPointDistance;
    public float StretchingFactor;
    public float FocusPointY;
    public Vector2 FocusPoint;
    public Vector2 Center;
    public float SteigungCenterLine;
    public float rotatedAngle;
    public Vector2 e;
   // float at = 5000f;
    //float bt = 5000f;
   
    void Awake()
    {
        rbplanet = protoplanet.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        //CalculateEllipse();
    }

    void LateUpdate()
    {
        a = 1 / (2 / Mathf.Sqrt(Mathf.Pow(PlanetDirection.x, 2) + Mathf.Pow(PlanetDirection.y, 2))) - ((Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.y, 2)) / rbplanet.mass);
        PlanetDirection = new Vector2(rb.position.x - rbplanet.position.x, rb.position.y - rbplanet.position.y);//funktioniert
        angleTangente = Mathf.Atan(rb.velocity.y / rb.velocity.x);//funktioniert
        angle = Mathf.PI/2 - Mathf.Atan(PlanetDirection.y / PlanetDirection.x) - (Mathf.PI / 2 - Mathf.Atan(rb.velocity.y / rb.velocity.x));//funktioniert
        if (angleTangente <= 0)
        {
            midAngle = angleTangente + angle;
            resultingAngle = angleTangente + midAngle;
        }
        else
        {
            midAngle = angle - angleTangente;
            resultingAngle = angleTangente - midAngle;
        }
        FocusPointDistance = 2 * a - Mathf.Sqrt(Mathf.Pow(PlanetDirection.x, 2) + Mathf.Pow(PlanetDirection.y, 2));
        FocusPointY = Mathf.Atan(resultingAngle);
        StretchingFactor = FocusPointDistance / Mathf.Sqrt(1 + Mathf.Pow(FocusPointY, 2));
        if (resultingAngle >= 0)
        {
            FocusPoint = new Vector2(rb.position.x - StretchingFactor, rb.position.y - FocusPointY * StretchingFactor);
        }
        else
        {
            FocusPoint = new Vector2(rb.position.x + StretchingFactor, rb.position.y - FocusPointY * StretchingFactor);
        }
            Center = new Vector2(FocusPoint.x + (rbplanet.position.x - FocusPoint.x) / 2 , FocusPoint.y + (rbplanet.position.y - FocusPoint.y) / 2 );
        SteigungCenterLine = (rbplanet.position.y - FocusPoint.y) / (rbplanet.position.x - FocusPoint.x);
        rotatedAngle = Mathf.Atan(SteigungCenterLine);
        e = new Vector2(Center.x - FocusPoint.x, Center.y - FocusPoint.y);
        b = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(a, 2) - (Mathf.Pow(e.x, 2) + Mathf.Pow(e.y, 2))));
        CalculateEllipse();
    }

    void CalculateEllipse()
    {
    Vector3[] points = new Vector3[segments + 1];

        for (int i = 0; i < segments; i++)
        {
            float angleEllipse = ((float)i / (float)segments) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Cos(angleEllipse) * Mathf.Sqrt(b);        
            float y = Mathf.Sin(angleEllipse) * Mathf.Sqrt(a);
            float xrotated = x * Mathf.Cos(rotatedAngle) - y * Mathf.Sin(rotatedAngle);
            float yrotated = x * Mathf.Sin(rotatedAngle) + y * Mathf.Cos(rotatedAngle);
            float xtranslated = xrotated + Center.x ;
            float ytranslated = yrotated + Center.y ;
            points[i] = new Vector3(xtranslated, ytranslated, 0f);
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
