﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour {

    private int posMatrizX;
    private int posMatrizZ;

    private float posX;
    private float posZ;

    private GameObject ficha;

    public bool ocupada = false;

    private Material mat;

    public static bool pulsada;

    private Logica logica;

    private MeshRenderer renderer;

    

    // Use this for initialization
    void Awake () {

        this.posX = transform.position.x;
        this.posZ = transform.position.z;

        renderer = GetComponentInChildren<MeshRenderer>();

    }
    	
	// Update is called once per frame
	void Update () {
		
	}

    public void crearFicha(GameObject ficha)
    {
        this.ficha  = Instantiate(ficha, new Vector3(posX, 1f, posZ), transform.rotation);
    
        ocupada = true;
    }

    void OnMouseDown()
    {

        Debug.Log(posMatrizX + ", " + posMatrizZ);
        if(ocupada == false)
        {

            logica.crearFichaEnCasillaSeleccionada(this);
        }

    }


    void OnMouseUp()
    {

    }


    public bool estaOcupado()
    {
        return ocupada;
    }

    public void setLogica(Logica logica)
    {
        this.logica = logica;
    }

    public GameObject getFicha()
    {
        return ficha;
    }

    public void setPosicionMatriz(int posMatrizX, int posMatrizZ)
    {
        this.posMatrizX = posMatrizX;

        this.posMatrizZ = posMatrizZ;
    }

    public int getPosicionMatrizX()
    {
        return this.posMatrizX;    
    }

    public int getPosicionMatrizZ()
    {
        return this.posMatrizZ;
    }







}
