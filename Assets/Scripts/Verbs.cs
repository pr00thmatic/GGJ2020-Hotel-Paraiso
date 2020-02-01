using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Verbs : MonoBehaviour{
  static Verbs _instance;
  public static Verbs Instance {
    get {
      if (!_instance) {
        _instance = GameObject.FindObjectOfType<Verbs>();
      }

      return _instance;
    }
  }

  public static AxisDown upDown0 = new AxisDown("Up0");
  public static AxisDown upDown1 = new AxisDown("Up1");

  void Start () {
    upDown0 = new AxisDown("Up0");
    upDown1 = new AxisDown("Up1");
  }

  void LateUpdate () {
    upDown0.Update();
    upDown1.Update();
  }

  public static bool Down (int number) {
    if (number == 0) {
      return (upDown0.down < 0 ||
              Input.GetKeyDown(KeyCode.S));
    }
    return upDown1.down < 0 ||
      Input.GetKeyDown(KeyCode.DownArrow);
  }

  public static bool Up (int number) {
    if (number == 0) {
      return upDown0.down > 0 ||
        Input.GetKeyDown(KeyCode.W);
    }
    return upDown1.down > 0 ||
      Input.GetKeyDown(KeyCode.UpArrow);
  }

  public static bool Use (int number) {
    if (number == 0) {
      return Input.GetKeyDown(KeyCode.Joystick1Button0) ||
        Input.GetKeyDown(KeyCode.C);
    }
    return Input.GetKeyDown(KeyCode.Joystick2Button0) ||
      Input.GetKeyDown(KeyCode.Period);
  }

  public static bool Jump (int number) {
    if (number == 0) {
      return Input.GetKeyDown(KeyCode.Joystick1Button2) ||
        Input.GetKeyDown(KeyCode.W);
    }
    return Input.GetKeyDown(KeyCode.Joystick2Button2) ||
      Input.GetKeyDown(KeyCode.UpArrow);
  }

  public static bool GrabDown (int number) {
    if (number == 0) {
      return Input.GetKeyDown(KeyCode.Joystick1Button3) ||
        Input.GetKeyDown(KeyCode.Z);
    }
    return Input.GetKeyDown(KeyCode.Joystick2Button3) ||
      Input.GetKeyDown(KeyCode.M);
  }

  public static bool TossDown (int number) {
    if (number == 0) {
      return Input.GetKeyDown(KeyCode.Joystick1Button1) ||
        Input.GetKeyDown(KeyCode.X);
    }
    return Input.GetKeyDown(KeyCode.Joystick2Button1) ||
      Input.GetKeyDown(KeyCode.Comma);
  }
}
