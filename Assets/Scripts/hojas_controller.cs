using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hojas_controller : MonoBehaviour
{
    public GameObject hojas;
    public GameObject punto;
    private float tiempo;

    void Start()
    {
        Instantiate(hojas,punto.transform);
        tiempo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo > 5f){
            Instantiate(hojas,punto.transform);
            tiempo = 0;
        }
    }
}
