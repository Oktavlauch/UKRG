using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRocketGravity : MonoBehaviour
{
    /// <summary>
    /// magnitude of the force
    /// </summary>
    float ForceValue=1;
    /// <summary>
    /// direction of the force
    /// </summary>
    Vector2 ForceDirection;
    Vector2 ObjectPos = new Vector2(1.0f, 0.0f);

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ForceDirection = new Vector2(ObjectPos.x - transform.position.x, ObjectPos.y - transform.position.y);

        rb.AddRelativeForce(ForceDirection.normalized * ForceValue);
    }
}
