using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingTile : MonoBehaviour {
  public ParticleSystem fire;

  public void TurnFireOn () {
    fire.Play();
  }

  public void TurnFireOff () {
    fire.Stop();
  }
}
