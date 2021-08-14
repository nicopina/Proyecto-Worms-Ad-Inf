using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuego_controller : MonoBehaviour
{

    public float dano;
    private float expl;
    public GameObject explosion;
    public bool contacto;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.25f;
        float tiempo = Random.Range(4,7);
        Destroy(gameObject, tiempo);

    }

    // Update is called once per frame
    void Update()
    {
        if (contacto)
        {
            timer = timer + Time.deltaTime;
            if (timer >= 1)
            {
                contacto = false;
                timer = 0;
            }
        }
        
        
    }

    public void Setup(Vector3 shootDir, float force, float dano)
    {
        this.dano = dano;
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(shootDir * force, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!contacto)
        {
            GameObject exp = Instantiate(explosion) as GameObject;
            exp.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            exp.GetComponent<Destructible2D.Examples.D2dExplosion>().StampSize = new Vector2(0.1f, 0.1f);
            exp.GetComponent<CircleCollider2D>().radius = new Vector2(0.1f, 0.1f).magnitude;
            exp.GetComponent<explocionV>().dano = dano;
            contacto = true;
        }

        if(collision.gameObject.tag == "fuego")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), collision.gameObject.GetComponent<CircleCollider2D>());
        }
        if (collision.gameObject.tag == "worm")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CapsuleCollider2D>(), gameObject.GetComponent<CircleCollider2D>());
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
