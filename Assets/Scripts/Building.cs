using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {
  public Perifono perifono;
  public InteractivePlayer[] players;
  public Floor[] floors;
  public RandomRange disasterTime = new RandomRange(6, 12);
  public RandomRange displaceAmount = new RandomRange(0, 2);
  public float displacedDisasterProbability = 0.8f;

  void Start () {
    floors = GetComponentsInChildren<Floor>();
    players = GetComponentsInChildren<InteractivePlayer>();
    StartCoroutine(_PeriodicDisaster());
  }

  IEnumerator _PeriodicDisaster () {
    while (true) {
      yield return new WaitForSeconds(disasterTime.Uniform);
      int floor;

      if (Random.Range(0,1f) < displacedDisasterProbability) {
        floor = (int) Mathf.Clamp(players[Random.Range(0, players.Length)].floor +
                                  0, (int) displaceAmount.Uniform, floors.Length);
      } else {
        floor = Random.Range(0, floors.Length);
      }

      floors[floor].StartDisaster();
    }
  }
}
