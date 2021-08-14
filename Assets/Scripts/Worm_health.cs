using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Worm_health : MonoBehaviour
{
    public int vida;
    private float velocidad;
    private int dano;
    public bool Dcaida;
    public bool ahogado = false;
    private float tiempo = 0;
    public string nombre;
    public int equipo;
    public bool c_murio = false;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        vida = PlayerPrefs.GetInt("vidaInicial",100);
        if (equipo == 1){
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto1").gameObject.SetActive(true);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto1").gameObject.SetActive(true);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto2").gameObject.SetActive(false);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto2").gameObject.SetActive(false);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto1").gameObject.GetComponent<Text>().text = vida.ToString();
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto1").gameObject.GetComponent<Text>().text = nombre;
        }
        else{
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto2").gameObject.SetActive(true);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto2").gameObject.SetActive(true);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto1").gameObject.SetActive(false);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto1").gameObject.SetActive(false);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto2").gameObject.GetComponent<Text>().text = vida.ToString();
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto2").gameObject.GetComponent<Text>().text = nombre;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<Worm_Controller>().isActiveAndEnabled) gameObject.GetComponent<AudioSource>().Stop();
        velocidad = GetComponent<Rigidbody2D>().velocity.magnitude;
        if (velocidad >= 5)
        {
            Dcaida = true;
            dano = Convert.ToInt32(velocidad);
        }
        else
        {
            Dcaida = false;
        }
        //gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto").gameObject.GetComponent<Text>().text = vida.ToString();
        //gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto").gameObject.GetComponent<Text>().text = nombre;
        if (equipo == 1){
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto1").gameObject.SetActive(true);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto1").gameObject.SetActive(true);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto2").gameObject.SetActive(false);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto2").gameObject.SetActive(false);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto1").gameObject.GetComponent<Text>().text = vida.ToString();
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto1").gameObject.GetComponent<Text>().text = nombre;
        }
        else{
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto2").gameObject.SetActive(true);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto2").gameObject.SetActive(true);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto1").gameObject.SetActive(false);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto1").gameObject.SetActive(false);
            gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.Find("Texto2").gameObject.GetComponent<Text>().text = vida.ToString();
            gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.Find("Texto2").gameObject.GetComponent<Text>().text = nombre;
        }
        if (vida <= 0)
        {
            if (gameObject.GetComponent<Worm_Controller>().Uso)
            {
                gameObject.GetComponent<Worm_Controller>().mira.SetActive(false);
                gameObject.GetComponent<Worm_Controller>().arma.SetActive(false);
            }
            vida = 0;
            gameObject.GetComponent<Animator>().SetBool("death", true);

            if (c_murio)
            {
                GameObject exp = Instantiate(explosion) as GameObject;
                exp.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
                exp.GetComponent<Destructible2D.Examples.D2dExplosion>().StampSize = new Vector2(1f, 1f);
                exp.GetComponent<CircleCollider2D>().radius = new Vector2(0.75f, 0.75f).magnitude;
                exp.GetComponent<explocionV>().dano = 20;
                Destroy(gameObject, 0.01f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "water")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            ahogado = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "water")
        {
            tiempo = tiempo + Time.deltaTime;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;
            if (tiempo >= 3.2) Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        vida -= dano;
        dano = 0;
    }
    public void rotation(int angulo)
    {
        gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.rotation = Quaternion.Euler(0, angulo, 0);
        gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.rotation = Quaternion.Euler(0, angulo, 0);

    }
}
