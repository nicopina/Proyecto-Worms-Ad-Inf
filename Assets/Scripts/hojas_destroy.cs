using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hojas_destroy : MonoBehaviour
{
    public GameObject punto;
    private float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo > 2f){
            Destroy(gameObject,10);
            tiempo = 0;
        }
//        if (tiempo > 5f){
//            gameObject.transform.position = punto.transform.position;
//            tiempo = 0;
//        }
    }
}
