using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Controller : MonoBehaviour
{
    [Header("Estados")]
    //variables generales
    public bool can_jump;
    public bool is_falling;
    public bool salto;
    public bool salto2;
    public bool Dcaida;
    public bool IsDano;
    public bool Uso;
    public bool tiene_tiempo;

    //Editor
    [Header("Parametros de movimiento")]
    public float velocidad;
    public float potencia_salto;
    public int angulo_salto;
    [Header("Sets")]
    public GameObject mira;//mira
    public GameObject arma ;
    public AudioClip audioCaminar;
    public AudioClip audioJet;

    private float Taire;
    private AudioSource fuenteAudio;
    private Vector2 Vvelocidad;
    private float Tanim;
    private string nombre;

    //private GameObject tr = transform.GetChild(0).gameObject;//weapon
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().sharedMaterial.friction = 100;
        gameObject.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = 0;
        fuenteAudio = gameObject.GetComponent<AudioSource>();
        fuenteAudio.clip = audioCaminar;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("win") != 1)
        {
            Vvelocidad = GetComponent<Rigidbody2D>().velocity;

            if (Uso)
            {
                if (!gameObject.GetComponent<Animator>().GetBool("Jetpack"))
                {
                    fuenteAudio.clip = audioCaminar;
                    if (!gameObject.GetComponent<Animator>().GetBool("dano"))
                    {
                        //Movimiento del gusano
                        if (gameObject.GetComponent<Animator>().GetBool("Walking") && !is_falling)
                        {
                            if (!fuenteAudio.loop)
                            {
                                fuenteAudio.loop = true;
                                fuenteAudio.Play();
                            }
                        }
                        else
                        {
                            fuenteAudio.loop = false;
                            fuenteAudio.Stop();
                        }

                        if (Input.GetKey(KeyCode.RightArrow) && !is_falling)
                        {
                            // gameObject.GetComponent<Animator>().enabled = true;
                            gameObject.GetComponent<Animator>().SetBool("Walking", true);
                            if (Uso) mira.SetActive(false);//mira
                            arma.SetActive(false);//weapon
                            mira.GetComponent<Apuntar>().setMovimiento(true);//mira
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.position += Vector3.right * velocidad * Time.deltaTime;
                            //vida y nombre

                            //gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.rotation = Quaternion.Euler(0,180,0);
                            //gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.rotation = Quaternion.Euler(0,180,0);

                            gameObject.GetComponent<Worm_health>().rotation(0);


                        }
                        else if (Input.GetKey(KeyCode.LeftArrow) && !is_falling)
                        {
                            //gameObject.GetComponent<Animator>().enabled = true;
                            gameObject.GetComponent<Animator>().SetBool("Walking", true);
                            if (Uso) mira.SetActive(false);//mira
                            mira.GetComponent<Apuntar>().setMovimiento(true);//mira
                            arma.SetActive(false);//weapon
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.position += Vector3.left * velocidad * Time.deltaTime;
                            //vida y nombre

                            //gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                            //gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.rotation = Quaternion.Euler(0,0,0);

                            gameObject.GetComponent<Worm_health>().rotation(0);

                        }
                        else
                        {
                            gameObject.GetComponent<Animator>().SetBool("Walking", false);
                        }

                        //Salto
                        if (Input.GetKeyDown("return") && can_jump)
                        {
                            gameObject.GetComponent<Animator>().SetBool("Jump", true);
                            salto2 = true;
                        }
                        if (salto)
                        {
                            mira.SetActive(false);//mira
                            arma.SetActive(false);//weapon
                            saltar();
                        }
                    }
                }
                else
                {
                    if (tiene_tiempo)
                    {
                        fuenteAudio.clip = audioJet;
                        mira.SetActive(false);
                        arma.SetActive(false);
                        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow))
                        {
                            if (Input.GetKey(KeyCode.RightArrow))
                            {
                                transform.rotation = Quaternion.Euler(0, 180, 0);
                                //vida y nombre
                                //gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.rotation = Quaternion.Euler(0,180,0);
                                //gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.rotation = Quaternion.Euler(0,180,0);                            

                                gameObject.GetComponent<Worm_health>().rotation(0);

                                Vector2 dir = new Vector2(3, 0);
                                gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 3);
                                if (!fuenteAudio.loop)
                                {
                                    fuenteAudio.loop = true;
                                    fuenteAudio.Play();
                                }
                            }
                            if (Input.GetKey(KeyCode.LeftArrow))
                            {
                                transform.rotation = Quaternion.Euler(0, 0, 0);
                                //vida y nombre

                                //gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                                //gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.rotation = Quaternion.Euler(0,0,0);

                                gameObject.GetComponent<Worm_health>().rotation(0);

                                Vector2 dir = new Vector2(-3, 0);
                                gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 3);
                                if (!fuenteAudio.loop)
                                {
                                    fuenteAudio.loop = true;
                                    fuenteAudio.Play();
                                }
                            }
                            if (Input.GetKey(KeyCode.UpArrow))
                            {
                                Vector2 dir = new Vector2(0, 3);
                                gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 3);
                                if (!fuenteAudio.loop)
                                {
                                    fuenteAudio.loop = true;
                                    fuenteAudio.Play();
                                }
                            }
                        }
                        else
                        {
                            fuenteAudio.loop = false;
                            fuenteAudio.Stop();
                        }
                    }
                }
            }
            if (!Uso)
            {
                gameObject.GetComponent<Animator>().SetBool("Jetpack", false);
                arma.SetActive(false);//weapon
                if (gameObject.GetComponent<Animator>().GetBool("Walking") && !is_falling)
                {
                    if (!fuenteAudio.loop)
                    {
                        fuenteAudio.loop = true;
                        fuenteAudio.Play();
                    }
                }
                else
                {
                    fuenteAudio.loop = false;
                    fuenteAudio.Stop();
                }
            }


            //verificacion de velocidad
            if (Vvelocidad.magnitude >= new Vector2(0, 1).magnitude)
            {
                if (Uso) mira.SetActive(false);//mira     
                if (Uso) mira.GetComponent<Apuntar>().setMovimiento(true);//mira
                arma.SetActive(false);//weapon
                is_falling = true;
                can_jump = false;
            }
            else
            {
                if (Vvelocidad == new Vector2(0, .1f)) gameObject.GetComponent<Animator>().SetBool("Jump", false);
                is_falling = false;
                can_jump = true;
            }

            //caida
            if (gameObject.GetComponent<Worm_health>().Dcaida)
            {
                is_falling = true;
                can_jump = false;
                salto = false;
                salto2 = false;
                if (Uso) mira.SetActive(false);//mira
                arma.SetActive(false);//weapon
                gameObject.GetComponent<Rigidbody2D>().sharedMaterial.friction = 0;
                gameObject.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = .4f;
                gameObject.GetComponent<Animator>().SetBool("falling", true);
                gameObject.GetComponent<Animator>().SetBool("Walking", false);
                IsDano = true;
            }
            if (!gameObject.GetComponent<Worm_health>().Dcaida && !IsDano)
            {
                if (!gameObject.GetComponent<Animator>().GetBool("Walking") &&
                    !gameObject.GetComponent<Animator>().GetBool("Jump") &&
                    !gameObject.GetComponent<Animator>().GetBool("falling")
                    && Uso)
                {
                    mira.SetActive(true);//mira
                    arma.SetActive(true);//weapon
                }
            }
            //animacion dano
            if (IsDano)
            {
                Tanim = Tanim + Time.deltaTime;
                can_jump = false;
                salto = false;
                salto2 = false;
                if (Uso) mira.SetActive(false);//mira
                arma.SetActive(false);//weapon
                gameObject.GetComponent<Rigidbody2D>().sharedMaterial.friction = 0;
                gameObject.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = .4f;
                gameObject.GetComponent<Animator>().SetBool("dano", true);
            }
            if (Vvelocidad.magnitude == 0 && Tanim > 0.5)
            {
                IsDano = false;
                gameObject.GetComponent<Animator>().SetBool("dano", false);
                gameObject.GetComponent<Rigidbody2D>().sharedMaterial.friction = 100;
                gameObject.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = 0;
            }

            //rotacion por dano o caida
            if (gameObject.GetComponent<Animator>().GetBool("falling") && Vvelocidad.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                //vida y nombre

                //gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.rotation = Quaternion.Euler(0,180,0);
                //gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.rotation = Quaternion.Euler(0,180,0);            

                gameObject.GetComponent<Worm_health>().rotation(0);
            }
            if (gameObject.GetComponent<Animator>().GetBool("falling") && Vvelocidad.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                //vida y nombre

                //gameObject.transform.Find("Canvas").gameObject.transform.Find("nombre").gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                //gameObject.transform.Find("Canvas").gameObject.transform.Find("vida").gameObject.transform.rotation = Quaternion.Euler(0,0,0);            

                gameObject.GetComponent<Worm_health>().rotation(0);
            }

        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("win",true);
        }
        
    }
    void saltar()
    {
        if (transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-potencia_salto/1.5f, potencia_salto*1.5f),ForceMode2D.Impulse);
        }
        if (transform.rotation == Quaternion.Euler(0, -180, 0))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(potencia_salto/1.5f, potencia_salto*1.5f), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Animator>().SetBool("Jump", false);
        gameObject.GetComponent<Animator>().SetBool("falling", false);
        if (IsDano)
        {
            Tanim = 0;
        }
    }
    /*
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.name.Contains("Chunk"))
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
        }
        
    }
    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        is_falling = true;
    }*/

}
