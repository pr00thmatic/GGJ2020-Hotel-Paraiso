using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxisDown {
  public int down;
  public string name;
  public float _buffer;

  public AxisDown (string name) {
    this.name = name;
  }

  public void Update () {
    if (_buffer == 0 && Input.GetAxis(name) != 0) {
      down = (int) Mathf.Sign(Input.GetAxis(name));
    } else {
      down = 0;
    }

    _buffer = Input.GetAxis(name);
  }
}
