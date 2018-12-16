using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edificio : MonoBehaviour {

    private Logica instanciaLogica;

    public int ContaminacionEdificio;

    // Use this for initialization
    void Awake()
    {
        instanciaLogica = Logica.instancia;

        instanciaLogica.setContaminacion(instanciaLogica.getContaminacion() + ContaminacionEdificio);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
