using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractivePlayer : MonoBehaviour {
  public InteractiveItem interaction;
  public GameObject interactionIndicator;
  public float tossVelocity = 4;

  public Transform itemAnchor;
  public GameObject current;

  public void Toss () {
    if (!current) return;

    Rigidbody body = current.GetComponent<Rigidbody>();
    body.isKinematic = false;
    body.AddForce(transform.forward * tossVelocity + GetComponent<Rigidbody>().velocity,
                  ForceMode.VelocityChange);
    current.transform.parent = null;
    current = null;
  }

  public void Grab (GameObject thing) {
    if (current) Toss();
    thing.GetComponent<Rigidbody>().isKinematic = true;
    thing.transform.parent = itemAnchor;
    thing.transform.localPosition = Vector3.zero;
    current = thing;
  }

  void Update () {
    interactionIndicator.SetActive(interaction);

    if (Input.GetKeyDown(KeyCode.Z) && interaction) {
      interaction.GetComponentInChildren<IInteractive>().Interact(this);
    }

    if (Input.GetKeyDown(KeyCode.X)) {
      Toss();
    }
  }
}
