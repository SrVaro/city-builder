using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jardin  : MonoBehaviour  {

    private Logica instanciaLogica;

    private int numeroEdificiosAdyacentes; 

    private int numeroIndustriasAdyacentes;

    public int contPorEdificio;

    public int contPorIndustria;

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setNumeroIndustriasAdyacentes(int numeroIndustriasAdyacentes) 
    {
        this.numeroIndustriasAdyacentes = numeroIndustriasAdyacentes;

        instanciaLogica.setContaminacion(instanciaLogica.getContaminacion() - numeroIndustriasAdyacentes * contPorIndustria);

        
    }

    public int getNumeroIndustriasAdyacentes()
    {
        return numeroIndustriasAdyacentes;
    }

    public void setNumeroEdificiosAdyacentes(int numeroEdificiosAdyacentes)
    {
        this.numeroEdificiosAdyacentes = numeroEdificiosAdyacentes;

        instanciaLogica.setContaminacion(instanciaLogica.getContaminacion() - numeroEdificiosAdyacentes * contPorEdificio);
    }

    public int getNumeroEdificiosAdyacentes()
    {
        return numeroEdificiosAdyacentes;
    }

    public void setLogica(Logica logica)
    {
        this.instanciaLogica = logica;
    }


}
