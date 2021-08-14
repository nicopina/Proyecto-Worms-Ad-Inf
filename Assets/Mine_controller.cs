using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_controller : MonoBehaviour
{
    public float dano;
    public GameObject explosion;
    public float time_to_explotion;
    private int Touch = 0;
    private float rotacion;
    private float dir;
    private AudioSource fuenteAudio;
    public float t_ini;
    public bool active;

    public void Setup(Vector3 shootDir, float force, float dano)
    {
        active = false;
        fuenteAudio = gameObject.GetComponent<AudioSource>();
        this.dano = dano;
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(shootDir * force, ForceMode2D.Impulse);
        dir = (shootDir.x / Mathf.Abs(shootDir.x)) * -1;
    }

    // Update is called once per frame
    void Update()
    {
        active = gameObject.transform.Find("detector").gameObject.active;
        t_ini = t_ini + Time.deltaTime;
        if (t_ini >= 5 && active)
        {
            time_to_explotion = time_to_explotion + Time.deltaTime;
            rotacion = (rotacion + 2 * dir);
            if (Touch == 0) gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, rotacion);
            if (time_to_explotion >= 4)
            {
                GameObject exp = Instantiate(explosion) as GameObject;
                exp.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
                exp.GetComponent<Destructible2D.Examples.D2dExplosion>().StampSize = new Vector2(1f, 1f);
                exp.GetComponent<CircleCollider2D>().radius = new Vector2(0.75f, 0.75f).magnitude;
                exp.GetComponent<explocionV>().dano = dano;
                Destroy(gameObject);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Touch++;
        if (collision.gameObject.tag == "worm")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }
        fuenteAudio.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "water")
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
