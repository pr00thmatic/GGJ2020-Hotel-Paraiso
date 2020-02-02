using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Perifono : MonoBehaviour {
  public ClientVoice PickAClientVoice () {
    ClientVoice[] voices = GetComponents<ClientVoice>();
    return voices[Random.Range(0, voices.Length)];
  }

  public void PlayFuego (int piso) {
    PickAClientVoice().PlayFuego(piso);
  }

  public void PlayLuz (int piso) {
    PickAClientVoice().PlayLuz(piso);
  }
}
