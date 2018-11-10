using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetarJuego : MonoBehaviour {

    public GameObject edificio;

    int posX;

	// Use this for initialization
	void Start () {

        for(int i = 0; i < 16; i++)
        {
            Instantiate(edificio, new Vector3(i * 2, 0, 0), transform.rotation);
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        

    }
}
