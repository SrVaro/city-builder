using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel2 : MonoBehaviour 
{

	public Logica logica;
	public GameObject industria;

	public void Start()
	{
        logica.getCasilla(1, 1).crearFicha(industria);
	}
}
