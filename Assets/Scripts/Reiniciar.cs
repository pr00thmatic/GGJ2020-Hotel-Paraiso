﻿using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reiniciar : MonoBehaviour
{
    public void ReiniciaNivel () {
        SceneManager.LoadScene("SampleScene");
    }
}
