using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1 : MonoBehaviour
{

	public Tablero tablero;
	public GameObject edificio;

	public void Start()
	{
		tablero.getCasilla(0,1).crearFicha(edificio);
		tablero.getCasilla(1,0).crearFicha(edificio);
		tablero.getCasilla(1,2).crearFicha(edificio);
		tablero.getCasilla(2,1).crearFicha(edificio);
	}
}
