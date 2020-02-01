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
    if ((Verbs.Up(player.number) || Verbs.Down(player.number)) && current) {
      Vector3 desired = Vector3.zero;

      if (Verbs.Up(player.number) && current) {
        desired = current.up.transform.position;
      }

      if (Verbs.Down(player.number) && current) {
        desired = current.down.transform.position;
      }

      Vector3 p = player.transform.position;
      p.x = desired.x; p.y = desired.y;
      player.transform.position = p + transform.forward;
    }
  }
}
