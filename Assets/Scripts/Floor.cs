using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Floor : MonoBehaviour {
  public DisposableLightbulb[] lightbulbs;

  void Start () {
    lightbulbs = GetComponentsInChildren<DisposableLightbulb>();
  }

  public void StartDisaster () {
    List<DisposableLightbulb> available = new List<DisposableLightbulb>();

    foreach (DisposableLightbulb lightbulb in lightbulbs) {
      if (lightbulb.IsOk) {
        available.Add(lightbulb);
      }
    }

    if (available.Count == 0) return;
    available[Random.Range(0, available.Count)].Dispose();
    GetComponentInParent<Building>().perifono.PlayLuz(transform.GetSiblingIndex());
  }
}
