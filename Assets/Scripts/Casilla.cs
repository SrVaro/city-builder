using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour {

    private float posX;
    private float posZ;

    private GameObject ficha;

    public bool ocupada = false;

    private Material mat;

    public static bool pulsada;

    private Tablero tablero;

    private MeshRenderer renderer;

    // Use this for initialization
    void Awake () {

        this.posX = transform.position.x;
        this.posZ = transform.position.z;

        renderer = GetComponentInChildren<MeshRenderer>();

    }
    	
	// Update is called once per frame
	void Update () {
		
	}

    public void crearFicha(GameObject ficha)
    {
        this.ficha  = Instantiate(ficha, new Vector3(posX, 1f, posZ), transform.rotation);
    
        ocupada = true;
    }

    public GameObject getFicha()
    {
        return ficha;
    }

    void OnMouseDown()
    {
        if(ocupada == false)
        {
            mat = renderer.material;

            mat.color = Color.green;

            tablero.crearFichaEnCasillaSeleccionada(this);
           
        }
        else
        {
            mat = renderer.material;

            mat.color = Color.red;

        }

    }

    void OnMouseUp()
    {

        mat = renderer.material;

        mat.color = Color.white;
    }


    public bool estaOcupado()
    {
        return ocupada;
    }

    public void setTablero(Tablero tablero)
    {
        this.tablero = tablero;
    }
    


    



}
