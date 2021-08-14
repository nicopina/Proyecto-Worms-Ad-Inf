using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class avion_engine : MonoBehaviour
{
    public int altura;
    private int contador = 0;
    public GameObject misil;
    public GameObject fuego;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "cubo")
        {
            altura = 9;
        }
        if (SceneManager.GetActiveScene().name == "bosque")
        {
            altura = 10;
        }
        if (SceneManager.GetActiveScene().name == "ciudad")
        {
            altura = 10;
        }
        if (SceneManager.GetActiveScene().name == "desierto")
        {
            altura = 7;
        }
        if (SceneManager.GetActiveScene().name == "nieve")
        {
            altura = 7;
        }

        transform.position = new Vector3(-15,altura,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime*5, altura, 0);

        if (PlayerPrefs.GetString("tipo_ataque") == "air_strike")
        {
            if (contador == 0 && transform.position.x >= (PlayerPrefs.GetFloat("pos_misil") - 2f))
            {
                contador++;
                GameObject mis = Instantiate(misil, (this.gameObject.GetComponent<Transform>().position), this.gameObject.GetComponent<Transform>().rotation);
                mis.GetComponent<Misil_controller>().Setup(new Vector3(0, -1, 0), 5, 15);
            }

            if (contador == 1 && transform.position.x >= (PlayerPrefs.GetFloat("pos_misil")))
            {
                contador++;
                GameObject mis = Instantiate(misil, (this.gameObject.GetComponent<Transform>().position), this.gameObject.GetComponent<Transform>().rotation);
                mis.GetComponent<Misil_controller>().Setup(new Vector3(0, -1, 0), 5, 15);
            }

            if (contador == 2 && transform.position.x >= (PlayerPrefs.GetFloat("pos_misil") + 2f))
            {
                contador++;
                GameObject mis = Instantiate(misil, (this.gameObject.GetComponent<Transform>().position), this.gameObject.GetComponent<Transform>().rotation);
                mis.GetComponent<Misil_controller>().Setup(new Vector3(0, -1, 0), 5, 15);
            }
        }

        if (PlayerPrefs.GetString("tipo_ataque") == "napalm")
        {
            

            if ((contador < 25) && transform.position.x >= (PlayerPrefs.GetFloat("pos_misil")))
            {
                contador++;
                GameObject fue = Instantiate(fuego, (this.gameObject.GetComponent<Transform>().position), this.gameObject.GetComponent<Transform>().rotation);
                fue.GetComponent<fuego_controller>().Setup(new Vector3(0, -1, 0), 1, 5);
            }


        }

        if (transform.position.x == 50) Destroy(gameObject);
    }
}
