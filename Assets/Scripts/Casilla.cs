using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class Casilla : MonoBehaviour {

    
    private int posMatrizX;

    private int posMatrizZ;
    
    private float posX, posZ;

    private GameObject ficha;

    private bool ocupada = false;

    private Logica instanciaLogica;

    // Use this for initialization
    void Awake()
    {
        instanciaLogica = Logica.instancia;

        this.posX = transform.position.x;
        this.posZ = transform.position.z;
    }
    	
    public void crearJardin(GameObject ficha, int numeroEdificiosAdyacentes, int numeroIndustriasAdyacentes)
    {
        this.ficha  = Instantiate(ficha, new Vector3(posX, 1f, posZ), transform.rotation);

        Jardin jardin = ficha.GetComponent<Jardin>();

        jardin.setLogica(instanciaLogica);

        jardin.setNumeroEdificiosAdyacentes(numeroEdificiosAdyacentes);

        jardin.setNumeroIndustriasAdyacentes(numeroIndustriasAdyacentes);
       
        this.ocupada = true;
    }

    public void crearTurbina(GameObject ficha)
    {
        this.ficha = Instantiate(ficha, new Vector3(posX, 1f, posZ), transform.rotation);

        this.ocupada = true;
    }

    public void crearFicha(GameObject ficha)
    {
        this.ficha = Instantiate(ficha, new Vector3(posX, 1f, posZ), transform.rotation);

        this.ocupada = true;
    }


    void OnMouseDown()
    {
        if(ocupada == false)
        {
            instanciaLogica.crearFichaEnCasillaSeleccionada(this);
        }
    }

    public bool estaOcupado()
    {
        return ocupada;
    }

    public GameObject getFicha()
    {
        return ficha;
    }

    public void setPosicionMatriz(int posMatrizX, int posMatrizZ)
    {
        this.posMatrizX = posMatrizX;

        this.posMatrizZ = posMatrizZ;
    }

    public int getPosicionMatrizX()
    {
        return this.posMatrizX;    
    }

    public int getPosicionMatrizZ()
    {
        return this.posMatrizZ;
    }

 








}
