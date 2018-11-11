using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel2 : MonoBehaviour 
{

	public Tablero tablero;
	public GameObject industria;

	public void Start()
	{
		tablero.getCasilla(1, 1).crearFicha(industria);
	}
}
