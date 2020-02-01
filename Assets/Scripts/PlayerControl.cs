using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
  public Rigidbody body;
  public float speed = 8;
  public float jumpSpeed = 3;
  public FloorDetector detector;
  public float rotationSpeed = 500f;
  public float desiredPolarity = 1;

  public void UpdateOrientation () {
    if (Input.GetAxis("Horizontal") != 0) {
      desiredPolarity = Mathf.Sign(-Input.GetAxis("Horizontal"));
    }

    transform.forward =
      Vector3.RotateTowards(transform.forward,
                            new Vector3(desiredPolarity,0,0.01f),
                            rotationSpeed * Mathf.Deg2Rad * Time.deltaTime, 0);
  }

  void Update () {
    Vector3 v = body.velocity;
    v.x = -Input.GetAxis("Horizontal") * speed;
    body.velocity = v;

    if (detector.isInFloor && Input.GetKeyDown(KeyCode.UpArrow)) {
      body.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
    }

    UpdateOrientation();
  }
}
