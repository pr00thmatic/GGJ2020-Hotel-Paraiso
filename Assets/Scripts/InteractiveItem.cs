using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractiveItem : MonoBehaviour {
  void OnTriggerStay (Collider c) {
    InteractivePlayer player = c.GetComponentInParent<InteractivePlayer>();
    if (player) {
      player.interaction = this;
    }
  }

  void OnTriggerExit (Collider c) {
    InteractivePlayer player = c.GetComponentInParent<InteractivePlayer>();
    if (player && player.interaction == this) {
      player.interaction = null;
    }
  }
}
