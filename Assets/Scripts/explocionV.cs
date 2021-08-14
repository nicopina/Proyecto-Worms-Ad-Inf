using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class explocionV : MonoBehaviour
{
    public float dano;
    private Vector2 dir;
    private float fuerza;

    private void Start()
    {
        if (dano == 5)
        {
            fuerza = 1f;
        }
        else
        {
            fuerza = 10f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "worm")
        {
            Vector2 res = collision.GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;
            dano = dano + dano * (gameObject.GetComponent<CircleCollider2D>().radius-(res).magnitude)/gameObject.GetComponent<CircleCollider2D>().radius;
            dir = (res).normalized;
            gameObject.GetComponent<Transform>().Find("White Flash").GetComponent<explocionVH>().dano = dano;
            collision.GetComponent<Rigidbody2D>().AddForce(dir * fuerza * ((gameObject.GetComponent<CircleCollider2D>().radius-(res).magnitude) / gameObject.GetComponent<CircleCollider2D>().radius), ForceMode2D.Impulse);
        }
    }
}
