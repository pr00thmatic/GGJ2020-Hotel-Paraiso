using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisposableLightbulb : MonoBehaviour, IDisposable, IFixable, IInteractive {
  public bool IsOk { get => ok.activeSelf; }
  public GameObject ok;
  public GameObject notOk;
  public ParticleSystem sparks;
  public RandomRange fireTime = new RandomRange(3, 6);
  public BuildingTile tile;

  float _fireMilestone = 0;
  float _elapsed = 0;

  bool _fireSpawned = false;

  void Start () {
    ResetTimers();
  }

  void Update () {
    _elapsed += Time.deltaTime;

    if (!IsOk && _elapsed >= _fireMilestone && !_fireSpawned) {
      _fireSpawned = true;
      SpawnFire();
    }

    if (!IsOk && _elapsed >= _fireMilestone && !tile.IsOnFire) {
      _elapsed = 0;
      _fireMilestone = fireTime.Uniform;
      _fireSpawned = false;
    }
  }

  public void Interact (InteractivePlayer player) {
    if (!IsOk && player.current &&
        player.current.GetComponent<InteractiveLightbulb>()) {
      Fix(player.current);
    }
  }

  public void Toss () {}

  public void ResetTimers () {
    _fireSpawned = false;
    _elapsed = 0;
    _fireMilestone = fireTime.Uniform;
  }

  public void Dispose () {
    ok.SetActive(false);
    notOk.SetActive(true);
    sparks.Play();
    _elapsed = 0;
  }

  public void Fix (GameObject replacement) {
    if (!replacement) return;
    Destroy(replacement);
    ok.SetActive(true);
    notOk.SetActive(false);
    sparks.Stop();

    ResetTimers();
  }

  public void SpawnFire () {
    tile.TurnFireOn();
    GetComponentInParent<Building>().perifono
      .PlayFuego(GetComponentInParent<Floor>().transform.GetSiblingIndex());
  }
}
