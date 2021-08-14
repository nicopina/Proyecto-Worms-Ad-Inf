using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class weapon : MonoBehaviour
{
    public double angulo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        angulo = gameObject.GetComponentInParent<Worm_Controller>().mira.GetComponent<Apuntar>().getAngulo();
        angulo = angulo * (360 / (2 * Mathf.PI)); //Convertir el angulo a grados.
        
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,Convert.ToSingle(angulo));

        if (angulo > 90)
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}
