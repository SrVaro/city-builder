using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1 : MonoBehaviour
{

	public Tablero tablero;
	public GameObject edificio1;
    public GameObject edificio2;
    public GameObject edificio3;

    public void Start()
	{
		tablero.getCasilla(0,1).crearFicha(edificio1);
		tablero.getCasilla(1,0).crearFicha(edificio2);
		tablero.getCasilla(1,2).crearFicha(edificio3);
		tablero.getCasilla(2,1).crearFicha(edificio1);
	}
}
