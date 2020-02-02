using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Extinguisher : MonoBehaviour, IInteractive {
  public bool isGrabbed = false;
  InteractivePlayer _owner;

  void Update () {
    if (!isGrabbed) {
      _owner = null;
      return;
    }

    if (!_owner) {
      _owner = GetComponentInParent<InteractivePlayer>();
    }

    if (Verbs.Use(_owner.number) && _owner.fireSensor.fire) {
      _owner.fireSensor.fire.Interact(_owner);
      _owner.anims.TriggerExtintor();
    }
  }

  public void Interact (InteractivePlayer player) {
    isGrabbed = true;
    player.Grab(this.gameObject);
  }

  public void Toss () {
    isGrabbed = false;
  }

  /// <summary>
  /// OnCollisionEnter is called when this collider/rigidbody has begun
  /// touching another rigidbody/collider.
  /// </summary>
  /// <param name="other">The Collision data associated with this collision.</param>
  void OnCollisionEnter(Collision other)
  {
      Floor floor = other.gameObject.GetComponentInParent<Floor>();
      if (floor) {
        transform.parent = floor.transform;
      }
  }
}
