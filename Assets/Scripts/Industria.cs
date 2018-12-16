using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Industria : MonoBehaviour {

    private Logica instanciaLogica;

    public int contaminacionIndustria;

    // Use this for initialization
    void Awake()
    {
        instanciaLogica = Logica.instancia;

        instanciaLogica.setContaminacion(instanciaLogica.getContaminacion() + contaminacionIndustria);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
