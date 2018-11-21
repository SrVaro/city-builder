using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1 : MonoBehaviour
{

	public Logica logica;
	public GameObject edificio1;
    public GameObject edificio2;
    public GameObject edificio3;

    public void Start()
	{
		logica.getCasilla(0,1).crearFicha(edificio1);
		logica.getCasilla(1,0).crearFicha(edificio2);
		logica.getCasilla(1,2).crearFicha(edificio3);
		logica.getCasilla(2,1).crearFicha(edificio1);
	}
}
