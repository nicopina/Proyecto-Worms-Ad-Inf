using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Controller : MonoBehaviour
{
    //variables generales
    public bool onGround;
    //Editor
    [Header("Parametros de movimiento")]
    public float velocidad;
    public float potencia_salto;
    public int angulo_salto;


    // Start is called before the first frame update
    void Start()
    {
        if (Quaternion.Euler(0, 0, 0).Equals(Vector3.zero))
        {
            print("wena");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del gusano
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += Vector3.right * velocidad * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            transform.position += Vector3.left * velocidad * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (onGround)
            {

                if (transform.rotation == Quaternion.Euler(0, 0, 0))
                {
                    transform.position += Vector3.up * Mathf.Cos(angulo_salto) * potencia_salto *
                        Time.deltaTime + Vector3.left * Mathf.Sin(angulo_salto) * potencia_salto * Time.deltaTime;
                }
                if (transform.rotation == Quaternion.Euler(0, -180, 0))
                {
                    transform.position += Vector3.up * Mathf.Cos(angulo_salto) * potencia_salto *
                        Time.deltaTime + Vector3.right * Mathf.Sin(angulo_salto) * potencia_salto * Time.deltaTime;
                }

            }


        }

        //Control del polygon collider2D
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("ground"))
        {
            onGround = true;
            return;
        }
        if(!collision.CompareTag("ground"))
        {
            onGround = false;
            return;
        }

    }

}
