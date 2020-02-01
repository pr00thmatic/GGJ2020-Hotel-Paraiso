using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerDetector : MonoBehaviour {
  public List<InteractivePlayer> player;

  void OnTriggerStay (Collider c) {
    InteractivePlayer possiblePlayer = c.GetComponentInParent<InteractivePlayer>();
    if (possiblePlayer && player.IndexOf(possiblePlayer) >= 0) {
      player.Add(possiblePlayer);
    }
  }

  void OnTriggerExit (Collider c) {
    InteractivePlayer possiblePlayer = c.GetComponentInParent<InteractivePlayer>();
    if (possiblePlayer && player.IndexOf(possiblePlayer) >= 0) {
      player.Remove(possiblePlayer);
    }
  }
}
