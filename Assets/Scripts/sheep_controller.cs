using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep_controller : MonoBehaviour
{
    public float velocidad;
    private Vector3 movimiento;
    private bool volando;
    public GameObject explosion;
    public float tiempo_explosion; 
    private float dano;
    private AudioSource fuenteAudio;
    private bool active;
    private float dir;
    private bool exploto;
    // Start is called before the first frame update
    public void Setup(Vector3 shootDir, float force, float dano)
    {
        active = false;
        fuenteAudio = gameObject.GetComponent<AudioSource>();
        this.dano = dano;
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(shootDir * force, ForceMode2D.Impulse);
        dir = (shootDir.x / Mathf.Abs(shootDir.x)) * -1;
    }
    void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("Walking",true);
        if(dir == 1){
            movimiento = Vector3.left * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(dir == -1){
            movimiento = Vector3.right * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        exploto = false;
        volando = false;
        tiempo_explosion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && volando )
        {
            gameObject.GetComponent<Animator>().SetBool("Walking",false);
            gameObject.GetComponent<Animator>().SetBool("FlyingH",true);
            gameObject.GetComponent<Animator>().SetBool("FlyingV",false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            movimiento = Vector3.right * velocidad * Time.deltaTime;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)&& volando)
        {
            gameObject.GetComponent<Animator>().SetBool("Walking",false);
            gameObject.GetComponent<Animator>().SetBool("FlyingH",true);
            gameObject.GetComponent<Animator>().SetBool("FlyingV",false);
            transform.rotation = Quaternion.Euler(180, 0, 180);
            movimiento = Vector3.left * velocidad * Time.deltaTime;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

        }
        else if (Input.GetKey(KeyCode.DownArrow) && volando)
        {
            gameObject.GetComponent<Animator>().SetBool("Walking",false);
            gameObject.GetComponent<Animator>().SetBool("FlyingV",true);
            gameObject.GetComponent<Animator>().SetBool("FlyingH",false);
            transform.rotation = Quaternion.Euler(0, 0, 180);
            movimiento = Vector3.down * velocidad * Time.deltaTime;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            volando = true;
            gameObject.GetComponent<Animator>().SetBool("Walking",false);
            gameObject.GetComponent<Animator>().SetBool("FlyingV",true);
            gameObject.GetComponent<Animator>().SetBool("FlyingH",false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            movimiento = Vector3.up * velocidad * Time.deltaTime;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);

        }
        transform.position += movimiento;
        
        if( tiempo_explosion >= PlayerPrefs.GetInt("tiempoRonda") && !exploto){
            exploto = true;
            GameObject exp = Instantiate(explosion) as GameObject;
            exp.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            exp.GetComponent<Destructible2D.Examples.D2dExplosion>().StampSize = new Vector2(2f, 2f);
            exp.GetComponent<CircleCollider2D>().radius = new Vector2(1.5f, 1.5f).magnitude;
            exp.GetComponent<explocionV>().dano = dano;
            Destroy(gameObject, 0.01f);
        }   
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (volando && collision.gameObject.tag != "worm"&& !exploto)
        {
            exploto = true;
            gameObject.GetComponent<Animator>().SetBool("Explosion",true);
            gameObject.GetComponent<Animator>().SetBool("FlyingH",false);
            gameObject.GetComponent<Animator>().SetBool("FlyingV",false);
            GameObject exp = Instantiate(explosion) as GameObject;
            exp.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            exp.GetComponent<Destructible2D.Examples.D2dExplosion>().StampSize = new Vector2(2f, 2f);
            exp.GetComponent<CircleCollider2D>().radius = new Vector2(1.5f, 1.5f).magnitude;
            exp.GetComponent<explocionV>().dano = dano;
            Destroy(gameObject, 0.01f);
        }
        if(collision.gameObject.tag == "worm"&& !exploto){
            exploto = true;
            gameObject.GetComponent<Animator>().SetBool("Explosion",true);
            gameObject.GetComponent<Animator>().SetBool("FlyingH",false);
            gameObject.GetComponent<Animator>().SetBool("FlyingV",false);
            GameObject exp = Instantiate(explosion) as GameObject;
            exp.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            exp.GetComponent<Destructible2D.Examples.D2dExplosion>().StampSize = new Vector2(2f, 2f);
            exp.GetComponent<CircleCollider2D>().radius = new Vector2(1.5f, 1.5f).magnitude;
            exp.GetComponent<explocionV>().dano = dano;
            Destroy(gameObject, 0.01f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "water")
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
