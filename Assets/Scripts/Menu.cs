using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void doExitGame() {
        Application.Quit();
    }

    public void seleccionarNivel(string s)
    {
        SceneManager.LoadScene("Nivel"+s, LoadSceneMode.Single);
    }
}