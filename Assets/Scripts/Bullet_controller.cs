using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet_controller : MonoBehaviour
{
    public float dano;
    public GameObject explosion;
    private int expl = 0;
    void Update()
    {
       gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, (((Mathf.Atan((gameObject.GetComponent<Rigidbody2D>().velocity.y) / (gameObject.GetComponent<Rigidbody2D>().velocity.x))) * 180) / Mathf.PI) - 90);
    }
    public void Setup(Vector3 shootDir, float force, float dano)
    {
        this.dano = dano;
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(shootDir * force, ForceMode2D.Impulse);
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (expl == 0)
        {
            GameObject exp = Instantiate(explosion) as GameObject;
            exp.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
            exp.GetComponent<Destructible2D.Examples.D2dExplosion>().StampSize = new Vector2(0.5f, 0.5f);
            exp.GetComponent<CircleCollider2D>().radius = new Vector2(0.25f, 0.25f).magnitude;
            Destroy(gameObject, 0.01f);
        }
        expl++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "worm")
        {
            collision.GetComponent<Worm_health>().vida -= Convert.ToInt32(dano);
        }

        if (collision.tag == "water")
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
