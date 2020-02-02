using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowUnrestricted : MonoBehaviour
{
    public Transform target;
    Vector3 velocity;
    public float time = 0.5f;
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, time);
    }
}
