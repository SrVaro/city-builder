using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour {

    private float posX;
    private float posZ;

    public bool ocupada = false;

    // Use this for initialization
    void Awake () {


        this.posX = transform.position.x;
        this.posZ = transform.position.z;

    }
    	
	// Update is called once per frame
	void Update () {
		
	}

    public void crearFicha(GameObject ficha)
    {
        Debug.Log(posX + ", " + posZ);

        Instantiate(ficha, new Vector3(posX, 2, posZ), transform.rotation);

        ocupada = true;

    }

    void OnMouseDown()
    {
        
    }


    

    public bool estaOcupado()
    {
        return ocupada;
    }

    


}
