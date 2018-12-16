using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;


public class Logica : MonoBehaviour {

    public static Logica instancia;

    private int fichaSeleccionada = 0;

    public int contaminacion = 0;

    public Text mText;

    public GameObject celda, edificio1, edificio2, edificio3, jardin, industria, turbina, rocas;

    public int numCol, numFil = 0;

    private Casilla[,] matrizCasillas;

    public Text textoBotonParques, textoBotonTurbinas;

    public int  numeroParquesDisponibles, numeroTurbinasDisponibles = 0;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        textoBotonParques.text = numeroParquesDisponibles.ToString();

        textoBotonTurbinas.text = numeroTurbinasDisponibles.ToString();

        matrizCasillas = new Casilla[numFil, numCol];

        for (int i = 0; i < numFil; i++)
        {
            for (int j = 0; j < numCol; j++)
            {
                Casilla casilla = Instantiate(celda, new Vector3(i * 2f, 0, j * 2f), celda.transform.rotation).GetComponent<Casilla>();

                casilla.setPosicionMatriz(i, j);

                matrizCasillas[i, j] = casilla;
            }
        }
       
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

                crearJardin(casilla);
                break;

            case 2:

                crearTurbina(casilla);
                break;

        }

        comprobarVictoria();
    }


    public void crearJardin(Casilla casilla)
    {
        if (hayParquesAdyacentes(casilla) == false && numeroParquesDisponibles > 0)
        {
            casilla.crearJardin(jardin, hayEdificiosAdyacentes(casilla), hayIndustriasAdyacentes(casilla));
            numeroParquesDisponibles--;
            textoBotonParques.text = numeroParquesDisponibles.ToString();

        }
    }

    public void crearTurbina(Casilla casilla)
    {
        if (hayEdificiosAdyacentes(casilla) == 0 && numeroTurbinasDisponibles > 0)
        {
            casilla.crearTurbina(turbina);
            numeroTurbinasDisponibles--;
            textoBotonTurbinas.text = numeroTurbinasDisponibles.ToString();
        }
    }

    public void comprobarVictoria()
    {

        if (numeroParquesDisponibles == 0 && numeroTurbinasDisponibles == 0 && contaminacion <= 0)
        {
            StartCoroutine(cambioEscena("win"));
        }
        if (numeroParquesDisponibles == 0 && numeroTurbinasDisponibles == 0 && contaminacion > 0)
        {
            StartCoroutine(cambioEscena("GameOver"));
        }

    }

    public int hayIndustriasAdyacentes(Casilla casilla)
    {
        int numeroIndustriasAdyacentes = 0;

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

                if (cas.getFicha() != null && cas.getFicha().tag == "Industria")
                {
                    numeroIndustriasAdyacentes++;
                }
            }
        }
        return numeroIndustriasAdyacentes;
    }

    public int hayEdificiosAdyacentes(Casilla casilla)
    {
        int numeroEdificiosAdyacentes = 0;

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
                    numeroEdificiosAdyacentes++;
                }
            }
        }
        return numeroEdificiosAdyacentes;
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

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(Logica));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    IEnumerator cambioEscena(string escena)
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(escena);
    }

    public Casilla getCasilla(int posMatrizX, int posMatrizZ)
    {
        return matrizCasillas[posMatrizX, posMatrizZ];
    }

    public int getContaminacion()
    {
        return contaminacion;
    }

    public void setContaminacion(int nuevaContaminacion)
    {
        mText.text = "Contaminacion: " + nuevaContaminacion;
        this.contaminacion = nuevaContaminacion;
    }


}
