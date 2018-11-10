using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour {

    private int fichaSeleccionada = 0;

    private int limitecontaminacion;

    public GameObject celda;

    public GameObject edificio;

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

                casilla.setTablero(this);

                matrizCasillas[i, j] = casilla;

            }
        }


    }

    // Update is called once per frame
    void Update()
    {



    }

    public string fichaPosterior(int posMatrizX, int posMatrizZ)
    {   
        return null;
    }



    public void seleccionarFicha(int tipoFicha)
    {
        this.fichaSeleccionada = tipoFicha;

    }

   public void crearFichaEnCasillaSeleccionada(Casilla casilla)
    {
        switch (fichaSeleccionada)
        {
            case 0:

                Debug.Log("No hay ficha seleccionada");
                break;

            case 1:

                casilla.crearFicha(edificio);
                break;

            case 2:

                casilla.crearFicha(industria);
                break;

            case 3:

                casilla.crearFicha(parque);
                break;

        }

    }

}
