using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
  public PlayerAnimations anims;
  public InteractivePlayer player;
  public Rigidbody body;
  public float speed = 8;
  public float jumpSpeed = 3;
  public FloorDetector detector;
  public float rotationSpeed = 500f;
  public float desiredPolarity = 1;
  bool _blockedJump = false;
  public float _jumpLag = 0.2f; 

  public void UpdateOrientation () {
    if (Input.GetAxis("Horizontal" + player.number) != 0) {
      desiredPolarity = Mathf.Sign(-Input.GetAxis("Horizontal" + player.number));
    }

    transform.forward =
      Vector3.RotateTowards(transform.forward,
                            new Vector3(desiredPolarity,0,0.01f),
                            rotationSpeed * Mathf.Deg2Rad * Time.deltaTime, 0);
  }

  void Update () {
    Vector3 v = body.velocity;
    v.x = -Input.GetAxis("Horizontal" + player.number) * speed;
    body.velocity = v;

    if (!_blockedJump && detector.isInFloor && Verbs.Jump(player.number)) {
      StartCoroutine(_EventuallyJump());
      anims.TriggerJump();
    }

    UpdateOrientation();
  }

  IEnumerator _EventuallyJump () {
    _blockedJump = false;
    yield return new WaitForSeconds(_jumpLag);
    body.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
  }
}
