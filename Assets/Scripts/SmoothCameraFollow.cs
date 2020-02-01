using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmoothCameraFollow : MonoBehaviour {
  public Transform target;
  public Vector3 velocity;
  public float smoothTime = 0.25f;

  void FixedUpdate () {
    Vector3 targetPosition =
    transform.position =
      Vector3.SmoothDamp(transform.position,
                         new Vector3(transform.position.x,
                                     target.position.y,
                                     transform.position.z),
                         ref velocity, smoothTime);
  }
}
