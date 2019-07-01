using System.Collections;
using System.Collections.Generic;
using System;
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
    public float FocusPointDistance;
    public Vector2 FocusPointDirection;
    public float StretchingFactor;
    public Vector2 FocusPoint;
    public Vector2 Center;
    public float SteigungCenterLine;
    public float rotatedAngle;
    public Vector2 e;
    float planetMass = 5972000;
    // float at = 5000f;
    //float bt = 5000f;

    void Awake()
    {
        rbplanet = protoplanet.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        lr.SetWidth(1f, 1f);
        CalculateEllipse();
    }

    void LateUpdate()
    {
        CalculateEllipse();
    }

    void CalculateEllipse()
    {
        PlanetDirection = new Vector2(rbplanet.position.x - rb.position.x, rbplanet.position.y - rb.position.y); //funktioniert
        a = 1 / ((2 / PlanetDirection.magnitude) - (rb.velocity.sqrMagnitude / planetMass)); //Finally Correct, yay :)
        angle = Vector2.SignedAngle(PlanetDirection, rb.velocity) * Mathf.Deg2Rad;

        if (angle >= 0.01 || angle <= -0.01) // avoids console error when angle too small
        {
            FocusPointDistance = 2 * a - PlanetDirection.magnitude;
            FocusPointDirection = new Vector2(PlanetDirection.x * Mathf.Cos(Mathf.PI + 2 * angle) - PlanetDirection.y * Mathf.Sin(Mathf.PI + 2 * angle), PlanetDirection.x * Mathf.Sin(Mathf.PI + 2 * angle) + PlanetDirection.y * Mathf.Cos(Mathf.PI + 2 * angle));
            StretchingFactor = FocusPointDistance / PlanetDirection.magnitude;
            FocusPoint = new Vector2(rb.position.x + FocusPointDirection.x * StretchingFactor, rb.position.y + FocusPointDirection.y * StretchingFactor); // should work
            Center = new Vector2(FocusPoint.x + (rbplanet.position.x - FocusPoint.x) / 2, FocusPoint.y + (rbplanet.position.y - FocusPoint.y) / 2);
            SteigungCenterLine = (rbplanet.position.y - FocusPoint.y) / (rbplanet.position.x - FocusPoint.x);
            rotatedAngle = Mathf.Atan(SteigungCenterLine);
            e = new Vector2((rbplanet.position.x - FocusPoint.x) / 2, (rbplanet.position.y - FocusPoint.y) / 2);
            b = Mathf.Sqrt(Mathf.Pow(a, 2) - Mathf.Pow(e.magnitude, 2));

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
            float x = Mathf.Sin(angleEllipse) * a;
            float y = Mathf.Cos(angleEllipse) * b;
            float xrotated = x * Mathf.Cos(rotatedAngle) - y * Mathf.Sin(rotatedAngle);
            float yrotated = x * Mathf.Sin(rotatedAngle) + y * Mathf.Cos(rotatedAngle);
            float xtranslated = xrotated + Center.x;
            float ytranslated = yrotated + Center.y;
            points[i] = new Vector3(xtranslated, ytranslated, 1f);
        }
        points[segments] = points[0];

        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }

    //Calculates Angle which the orbit is rotated
    public float GetAngle()
    {
        return 10;
    }
}

