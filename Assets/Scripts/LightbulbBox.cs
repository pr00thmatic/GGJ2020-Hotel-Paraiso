using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightbulbBox : MonoBehaviour, IInteractive {
  public GameObject lightBulb;

  public void Interact (InteractivePlayer player) {
    player.Grab(Instantiate(lightBulb));
  }

  public void Toss () {}
}
