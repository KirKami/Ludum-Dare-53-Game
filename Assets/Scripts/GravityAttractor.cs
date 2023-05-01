using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{

    const float G = 667.4f;

    public static List<GravityAttractor> Attractors;

    public Rigidbody rb;

    void FixedUpdate()
    {
        foreach (var attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<GravityAttractor>();

        Attractors.Add(this);
    }

    void OnDisable()
    {
        Attractors.Remove(this);
    }

    void Attract(GravityAttractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }

}