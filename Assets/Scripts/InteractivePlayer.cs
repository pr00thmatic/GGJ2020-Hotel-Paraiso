using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractivePlayer : MonoBehaviour {
  public int number = 0;
  public int floor = 0;

  public PlayerAnimations anims;
  public GameObject model;
  public InteractiveItem interaction;
  public GameObject interactionIndicator;
  public float tossVelocity = 4;
  public FireSensor fireSensor;

  public Transform itemAnchor;
  public GameObject current;

  public void Toss () {
    if (!current) return;

    Rigidbody body = current.GetComponent<Rigidbody>();
    body.isKinematic = false;
    body.AddForce(transform.forward * tossVelocity + GetComponent<Rigidbody>().velocity,
                  ForceMode.VelocityChange);
    current.transform.parent = null;
    current.GetComponentInChildren<IInteractive>().Toss();
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

    if (Verbs.GrabDown(number) && interaction) {
      interaction.GetComponentInChildren<IInteractive>().Interact(this);
    }

    if (Verbs.TossDown(number)) {
      Toss();
    }
  }

  void LateUpdate () {
    Vector3 p = transform.position;
    p.z = 1;
    transform.position = p;
  }
}
