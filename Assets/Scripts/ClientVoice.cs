using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientVoice : MonoBehaviour {
  public AudioSource perifono;
  public List<AudioClip> pisos;
  public List<AudioClip> fuego;
  public List<AudioClip> luz;

  public void PlayFuego (int piso) {
    StartCoroutine(_Perifonear(piso, fuego));
  }

  public void PlayLuz (int piso) {
    StartCoroutine(_Perifonear(piso, luz));
  }

  IEnumerator _Perifonear (int piso, List<AudioClip> evento) {
    AudioClip perifoneado = evento[Random.Range(0, evento.Count)];
    perifono.PlayOneShot(perifoneado);
    yield return new WaitForSeconds(perifoneado.length);
    perifono.PlayOneShot(pisos[piso]);
  }
}
