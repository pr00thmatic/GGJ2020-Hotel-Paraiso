using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractiveLightbulb : MonoBehaviour, IInteractive {
  public void Interact (InteractivePlayer player) {
    player.Grab(this.gameObject);
  }
}
