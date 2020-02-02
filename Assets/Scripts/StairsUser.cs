using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StairsUser : MonoBehaviour {
  public InteractivePlayer player;
  public Stairs current;
  public float cooldown = 0.5f;
  public float elevatorTime = 0.5f;

  bool _blocked = false;

  void OnTriggerStay (Collider c) {
    Stairs possible = c.GetComponentInParent<Stairs>();
    if (possible) current = possible;
  }

  void OnTriggerExit (Collider c) {
    Stairs possible = c.GetComponentInParent<Stairs>();
    if (possible && possible == current) {
      current = null;
    }
  }

  void Update () {
    if (_blocked) return;

    if (Verbs.Up(player.number) && current && current.up) {
      GoTo(current.up.transform.position);
    }

    if (Verbs.Down(player.number) && current && current.down) {
      GoTo(current.down.transform.position);
    }
  }

  public void GoTo (Vector3 desired) {
    Elevator elevator = current.GetComponentInParent<Elevator>();
    _blocked = true;
    player.enabled = false;
    player.GetComponent<PlayerControl>().enabled = false;
    StartCoroutine(_EventuallyReturn(desired, elevator));
  }

  IEnumerator _EventuallyReturn (Vector3 desired, Elevator elevator) {
    float elapsed = 0;
    Vector3 pos = player.transform.position;
    Vector3 animTarget = (desired.y > player.transform.position.y?
                          current.animTargetUp.position: current.animTargetDown.position);
    Rigidbody body = player.GetComponent<Rigidbody>();

    body.isKinematic = true;

    if (elevator) {
      while (elapsed < elevatorTime) {
        elapsed += Time.deltaTime;
        player.transform.position = Vector3.Lerp(pos, animTarget, elapsed / elevatorTime);
        elevator.animator.SetFloat("open close", elapsed / elevatorTime);
        yield return null;
      }
    } else {
      while (elapsed < cooldown) {
        elapsed += Time.deltaTime;
        player.transform.position = Vector3.Lerp(pos, animTarget, elapsed / cooldown);
        yield return null;
      }
    }

    _blocked = false;
    player.enabled = true;
    player.GetComponent<PlayerControl>().enabled = true;
    body.isKinematic = false;
    body.velocity = Vector3.zero;

    Vector3 p = player.transform.position;
    p.x = desired.x; p.y = desired.y;
    player.transform.position = p - Vector3.right;
  }
}
