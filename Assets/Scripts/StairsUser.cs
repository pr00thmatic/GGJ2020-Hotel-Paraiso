using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StairsUser : MonoBehaviour {
  public InteractivePlayer player;
  public Stairs current;

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
    if (Verbs.Up(player.number) && current && current.up) {
      GoTo(current.up.transform.position);
    }

    if (Verbs.Down(player.number) && current && current.down) {
      GoTo(current.down.transform.position);
    }
  }

  public void GoTo (Vector3 desired) {
    Vector3 p = player.transform.position;
    p.x = desired.x; p.y = desired.y;
    player.transform.position = p - Vector3.right;
  }
}
