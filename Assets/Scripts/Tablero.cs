using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour {

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Casilla c = new Casilla(i ,j);


            }
        }


    }

    // Update is called once per frame
    void Update () {
		
	}
}
