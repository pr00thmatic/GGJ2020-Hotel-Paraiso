using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisposableLightbulb : MonoBehaviour, IDisposable, IFixable {
  public GameObject ok;
  public GameObject notOk;
  public ParticleSystem sparks;
  public RandomRange fireTime = new RandomRange(3, 6);

  float _fireMilestone = -1;
  float _elapsed = 0;
  bool _fireSpawned = false;

  void Update () {
    if (ok.activeSelf) {
      _elapsed += Time.deltaTime;
      if (!_fireSpawned && _elapsed >= _fireMilestone) {
        _fireSpawned = true;
      }
    }
  }

  public void Dispose () {
    ok.SetActive(false);
    notOk.SetActive(true);
    sparks.Play();
    _fireMilestone = fireTime.Uniform;
  }

  public void Fix (GameObject replacement) {
    if (!replacement) return;
    Destroy(replacement);
    ok.SetActive(true);
    notOk.SetActive(false);
    sparks.Stop();
    _fireMilestone = -1;
    _fireSpawned = false;
  }
}
