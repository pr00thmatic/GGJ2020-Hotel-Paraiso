using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorDetector : MonoBehaviour {
  public bool isInFloor = false;

  void OnTriggerStay (Collider c) {
    isInFloor = true;
  }

  void OnTriggerExit (Collider c) {
    isInFloor = false;
  }
}
