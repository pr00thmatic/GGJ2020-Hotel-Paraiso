using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorDetector : MonoBehaviour {
  public bool isInFloor = false;
  public Collider debug;

  void OnTriggerStay (Collider c) {
    debug = c;
    isInFloor = true;
  }

  void OnTriggerExit (Collider c) {
    isInFloor = false;
  }
}
