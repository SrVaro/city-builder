using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void doExitGame() {
        Application.Quit();
    }

    public void menuPrincipal()
    {
        SceneManager.LoadScene("menu");
    }

    public void creditos()
    {
        SceneManager.LoadScene("creditos");
    }

    public void pantallaSeleccion()
    {
        SceneManager.LoadScene("seleccionarNivel");
    }

    public void cargarNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void cargarNivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }

    public void cargarNivel3()
    {
        SceneManager.LoadScene("Nivel3");
    }
}