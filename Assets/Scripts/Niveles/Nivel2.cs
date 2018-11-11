using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel2 : MonoBehaviour {

	public Tablero tablero;
	public GameObject parque;

	public void Start()
	{
		tablero.getCasilla(0,1).crearFicha(parque);
		tablero.getCasilla(1,0).crearFicha(parque);
		tablero.getCasilla(1,2).crearFicha(parque);
		tablero.getCasilla(2,1).crearFicha(parque);
	}
}
