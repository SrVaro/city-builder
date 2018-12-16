using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParqueEolico : MonoBehaviour {

    private Logica instanciaLogica;

    public int contContrarrestada;

    // Use this for initialization
    void Awake()
    {
        instanciaLogica = Logica.instancia;

        instanciaLogica.setContaminacion(instanciaLogica.getContaminacion() - contContrarrestada);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void setLogica(Logica logica)
    {
        this.instanciaLogica = logica;
    }
}
