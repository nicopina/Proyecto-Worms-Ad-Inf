using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Controller : MonoBehaviour
{
    //variables generales
    public bool can_jump;
    public bool is_falling;
    //Editor
    [Header("Parametros de movimiento")]
    public float velocidad;
    public float potencia_salto;
    public int angulo_salto;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del gusano
        if (Input.GetKey(KeyCode.RightArrow) && !is_falling)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += Vector3.right * velocidad * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.LeftArrow) && !is_falling)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += Vector3.left * velocidad * Time.deltaTime;

        }
        if (Input.GetKeyDown("return"))
        {
            if (Input.GetKeyDown("return"))
            {
                saltar();
            }
                

        }

        //verificacion de velocidad
        if (GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0))
        {
            is_falling = true;
            can_jump = false;
        }
        else
        {
            is_falling = false;
            can_jump = true;
        }
    }

    void saltar()
    {
        if (transform.rotation == Quaternion.Euler(0, 0, 0) && can_jump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3((-potencia_salto) * Mathf.Cos(angulo_salto) * 2, potencia_salto, 0));
        }
        if (transform.rotation == Quaternion.Euler(0, -180, 0) && can_jump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3((potencia_salto) * Mathf.Cos(angulo_salto) * 2, potencia_salto, 0));
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("ground"))
        {
            can_jump = true;
            return;
        }
        if(!collision.CompareTag("ground"))
        {
            can_jump = false;
            return;
        }

    }*/

}
