using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tablero : MonoBehaviour {

    private int fichaSeleccionada = 0;

    private int contaminacionActual = 0;

    public GameObject celda, edificio, parque, industria, turbina, rocas;

    public int numCol, numFil = 0;

    private Casilla[,] matrizCasillas;

    public string nombreEscena;

    public Text Texto;

    public int numeroEdificiosDisponibles , numeroIndustriasDisponibles, numeroParquesDisponibles, numeroTurbinaDisponibles, numeroRocasDisponibles = 0;


    // Use this for initialization
    void Start () {

        Texto.text = "Contaminacion: " + contaminacionActual;

        matrizCasillas = new Casilla[numFil, numCol];

        for (int i = 0; i < numFil; i++)
        {
            for (int j = 0; j < numCol; j++)
            {
                Casilla casilla = Instantiate(celda, new Vector3(i * 2f, 0, j * 2f), celda.transform.rotation).GetComponent<Casilla>();

                casilla.setPosicionMatriz(i, j);

                casilla.setTablero(this);

                matrizCasillas[i, j] = casilla;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(nombreEscena);
        }
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

                if (hayIndustriasAdyacentes(casilla) == false)
                {
                    casilla.crearFicha(edificio);
                }
                break;
                
            case 2:

                if (hayEdificiosAdyacentes(casilla) == false)
                {
                    casilla.crearFicha(industria);
                }
                break;

            case 3:

                if(hayParquesAdyacentes(casilla) == false && numeroParquesDisponibles > 0)
                {
                    casilla.crearFicha(parque);
                    numeroParquesDisponibles--;
                }
                break;

            case 4:

                if(hayEdificiosAdyacentes(casilla) == false)
                {
                    casilla.crearFicha(turbina);
                }
                break;

            case 5:

                casilla.crearFicha(rocas);
                break;
        }
    }

    public bool hayIndustriasAdyacentes(Casilla casilla)
    {
        Vector2Int[] v = new Vector2Int[4];
        v[0] = new Vector2Int(casilla.getPosicionMatrizX(), casilla.getPosicionMatrizZ() + 1);
        v[1] = new Vector2Int(casilla.getPosicionMatrizX(), casilla.getPosicionMatrizZ() - 1);
        v[2] = new Vector2Int(casilla.getPosicionMatrizX() + 1, casilla.getPosicionMatrizZ());
        v[3] = new Vector2Int(casilla.getPosicionMatrizX() - 1, casilla.getPosicionMatrizZ());


        for (int i=0; i< v.Length; i++)
        {
            if (v[i].x >= 0 && v[i].x < numCol && v[i].y < numFil && v[i].y >= 0)
            {
                Casilla cas = matrizCasillas[v[i].x, v[i].y];

                Debug.Log(v[i]);

                if (cas.getFicha() != null && cas.getFicha().tag == "Industria")
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool hayEdificiosAdyacentes(Casilla casilla)
    {
        Vector2Int[] v = new Vector2Int[4];
        v[0] = new Vector2Int(casilla.getPosicionMatrizX(), casilla.getPosicionMatrizZ() + 1);
        v[1] = new Vector2Int(casilla.getPosicionMatrizX(), casilla.getPosicionMatrizZ() - 1);
        v[2] = new Vector2Int(casilla.getPosicionMatrizX() + 1, casilla.getPosicionMatrizZ());
        v[3] = new Vector2Int(casilla.getPosicionMatrizX() - 1, casilla.getPosicionMatrizZ());

        for (int i = 0; i < v.Length; i++)
        {
            if (v[i].x >= 0 && v[i].x < numCol && v[i].y < numFil && v[i].y >= 0)
            {
                Casilla cas = matrizCasillas[v[i].x, v[i].y];

                if (cas.getFicha() != null && cas.getFicha().tag == "Edificio")
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool hayParquesAdyacentes(Casilla casilla)
    {
        Vector2Int[] v = new Vector2Int[4];
        v[0] = new Vector2Int(casilla.getPosicionMatrizX(), casilla.getPosicionMatrizZ() + 1);
        v[1] = new Vector2Int(casilla.getPosicionMatrizX(), casilla.getPosicionMatrizZ() - 1);
        v[2] = new Vector2Int(casilla.getPosicionMatrizX() + 1, casilla.getPosicionMatrizZ());
        v[3] = new Vector2Int(casilla.getPosicionMatrizX() - 1, casilla.getPosicionMatrizZ());

        for (int i = 0; i < v.Length; i++)
        {
            if (v[i].x >= 0 && v[i].x < numCol && v[i].y < numFil && v[i].y >= 0)
            {
                Casilla cas = matrizCasillas[v[i].x, v[i].y];

                if (cas.getFicha() != null && cas.getFicha().tag == "Parque")
                {
                    return true;
                }
            }
        }
        return false;
    }

    public Casilla getCasilla( int posMatrizX, int posMatrizZ )
    {
        return matrizCasillas[posMatrizX, posMatrizZ];
    }
}
