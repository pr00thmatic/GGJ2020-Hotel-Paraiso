using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stairs : MonoBehaviour {
  public Stairs up;
  public Stairs down;
  public Transform animTargetUp;
  public Transform animTargetDown;

  public Stairs GetUp () {
    Stairs newUp = up;
    while (newUp && newUp.GetComponentInParent<Floor>().isDestroyed) {
      newUp = newUp.up;
    }

    return newUp;
  }

  public Stairs GetDown () {
    Stairs newDown = down;
    while (newDown && newDown.GetComponentInParent<Floor>().isDestroyed) {
      newDown = newDown.down;
    }

    return newDown;
  }
}
