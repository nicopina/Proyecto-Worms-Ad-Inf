using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class explocionVH : MonoBehaviour
{
    public float dano;
    private Vector2 dir;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "worm")
        {   
            collision.GetComponent<Worm_health>().vida -= Convert.ToInt32(dano);
            collision.GetComponent<Worm_Controller>().IsDano = true;
        }
    }
}
