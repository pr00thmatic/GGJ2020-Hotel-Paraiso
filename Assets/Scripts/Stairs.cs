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

    return newUp;
  }

  public Stairs GetDown () {
    Stairs newDown = down;
    

    return newDown;
  }
}
