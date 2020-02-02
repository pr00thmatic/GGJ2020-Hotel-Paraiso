using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {
  public Perifono perifono;
  public InteractivePlayer[] players;
  public Floor[] floors;
  public List<int> availableFloors;
  public RandomRange disasterTime = new RandomRange(6, 12);
  public RandomRange displaceAmount = new RandomRange(0, 2);
  public float displacedDisasterProbability = 0.8f;

  void Start () {
    floors = GetComponentsInChildren<Floor>();
    for (int i=0; i<floors.Length; i++) {
      availableFloors.Add(i);
    }
    players = GetComponentsInChildren<InteractivePlayer>();
    StartCoroutine(_PeriodicDisaster());
    StartCoroutine(_PeriodicDisaster());
  }

  public void DestroyFloor (int index) {
    floors[index].isDestroyed = true;
    availableFloors.Remove(index);
    Extinguisher extinguisher = GetComponentInChildren<Extinguisher>();
    if (extinguisher) {
      extinguisher.transform.position = floors[0].GetComponentInChildren<ExtinguisherPlace>().transform.position;
    }
  }

  IEnumerator _PeriodicDisaster () {
    while (true) {
      yield return new WaitForSeconds(disasterTime.Uniform);
      int floor;

      if (Random.Range(0,1f) < displacedDisasterProbability) {
        floor = (int) Mathf.Clamp(players[Random.Range(0, players.Length)].floor +
                                  0, (int) displaceAmount.Uniform,
                                  availableFloors.Count);
      } else {
        floor = availableFloors[Random.Range(0, availableFloors.Count)];
      }

      floors[floor].StartDisaster();
    }
  }
}
