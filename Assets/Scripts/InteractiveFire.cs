using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractiveFire : MonoBehaviour {
  public ParticleSystem fire;
  public float hp = 100;
  public float step = 1;
  public float gainPerSeconds = 2;
  public bool isOn = false;

  void Update () {
    hp = Mathf.Clamp(hp+gainPerSeconds * Time.deltaTime, 0, 100);
    var wtf = fire.emission;
    wtf.rateOverTime = (hp/100f) * 20;
  }

  public void StartFire () {
    isOn = true;
    hp = 10;
    fire.Play();
  }

  public void Interact (InteractivePlayer player) {
    hp -= step;
    if (hp <= 0) {
      GetComponentInParent<BuildingTile>().TurnFireOff();
      isOn = false;
    }
  }
}
