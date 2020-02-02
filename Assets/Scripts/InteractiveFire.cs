using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractiveFire : MonoBehaviour {
  public ParticleSystem fire;
  public float hp = 100;
  public float step = 1;
  public float gainPerSeconds = 2;
  public bool isOn = false;
  public float damagePerTime = 5;
  public Floor floor;

  BuildingTile _tile;

  void Start () {
    floor = GetComponentInParent<Floor>();
    _tile = GetComponentInParent<BuildingTile>();
  }

  void Update () {
    hp = Mathf.Clamp(hp+gainPerSeconds * Time.deltaTime, 0, 100);
    var wtf = fire.emission;
    wtf.rateOverTime = (hp/100f) * 20;

    if (hp > 10 && _tile.IsOnFire) {
      floor.hp -= (damagePerTime * Time.deltaTime) * hp/100f;
    }
  }

  public void StartFire () {
    isOn = true;
    hp = 10;
    fire.Play();
  }

  public void Interact (InteractivePlayer player) {
    hp -= step;
    if (hp <= 0) {
      _tile.TurnFireOff();
      isOn = false;
    }
  }
}
