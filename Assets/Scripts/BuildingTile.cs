using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingTile : MonoBehaviour {
  public bool IsOnFire { get => fire.GetComponent<InteractiveFire>().isOn; }
  public ParticleSystem fire;

  public void TurnFireOn () {
    fire.GetComponent<InteractiveFire>().StartFire();
  }

  public void TurnFireOff () {
    fire.Stop();
  }
}
