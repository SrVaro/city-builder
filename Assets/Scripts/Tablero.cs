using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour {

    private int contaminacion;

    public GameObject celda;

    public GameObject parque;

    public GameObject industria;

    public int numCol = 0;

    public int numFil = 0;

    private Casilla[,] matrizCasillas;


    // Use this for initialization
    void Start () {

        matrizCasillas = new Casilla[numFil, numCol];

        for (int i = 0; i < numFil; i++)
        {
            for (int j = 0; j < numCol; j++)
            {
                Casilla casilla = Instantiate(celda, new Vector3(i * 2f, 0, j * 2f), celda.transform.rotation).GetComponent<Casilla>();

                matrizCasillas[i, j] = casilla;

            }
        }


        matrizCasillas[0, 0].crearFicha(industria);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
