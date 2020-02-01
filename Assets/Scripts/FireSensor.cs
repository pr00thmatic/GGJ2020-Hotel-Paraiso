using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireSensor : MonoBehaviour {
  public InteractiveFire fire;

  void OnTriggerStay (Collider c) {
    InteractiveFire possibleFire = c.GetComponentInParent<InteractiveFire>();
    if (possibleFire) {
      fire = possibleFire;
    }
  }

  void OnTriggerExit (Collider c) {
    InteractiveFire possibleFire = c.GetComponentInParent<InteractiveFire>();
    if (possibleFire && possibleFire == fire) {
      fire = null;
    }
  }
}
