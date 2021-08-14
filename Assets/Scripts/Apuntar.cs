using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Apuntar : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform gusano;
    public float radio;

    public float velocidadMira;
    private Double angulo = 0;

    public Boolean movimiento = false;
    void Start()
    {
    transform.position = new Vector3(gusano.position.x + radio ,gusano.position.y,gusano.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (gusano != null)
        {
            if (gusano.GetComponent<Animator>().GetBool("Walking"))
            {
                movimiento = true;
            }
            else
            {
                if (gusano.rotation.y == 0)
                {
                    /*if (movimiento){
                        //transform.position = new Vector3(gusano.position.x - radio ,gusano.position.y,gusano.position.z);
                        transform.position = new Vector3(gusano.position.x + Convert.ToSingle((Math.Cos(angulo)*radio)),gusano.position.y + Convert.ToSingle((Math.Sin(angulo)*radio)),gusano.position.z);
                        movimiento = false;
                    }*/
                    if (angulo >= 5 || angulo <= 1.571)
                    {
                        angulo = 3.14;
                    }
                    else if ((Input.GetKey(KeyCode.UpArrow) || movimiento) && angulo >= 1.65)
                    {
                        movimiento = false;
                        angulo = angulo - (velocidadMira * Time.deltaTime);
                        transform.position = new Vector3(gusano.position.x + Convert.ToSingle((Math.Cos(angulo) * radio)), gusano.position.y + Convert.ToSingle((Math.Sin(angulo) * radio)), gusano.position.z);

                    }
                    else if ((Input.GetKey(KeyCode.DownArrow) || movimiento) && angulo <= 4.710)
                    {
                        movimiento = false;
                        angulo = angulo + (velocidadMira * Time.deltaTime);
                        transform.position = new Vector3(gusano.position.x + Convert.ToSingle((Math.Cos(angulo) * radio)), gusano.position.y + Convert.ToSingle((Math.Sin(angulo) * radio)), gusano.position.z);
                    }
                }
                if (gusano.rotation.y < 0)
                {
                    /*if (movimiento){
                        //transform.position = new Vector3(gusano.position.x + radio ,gusano.position.y,gusano.position.z);
                        transform.position = new Vector3(gusano.position.x + Convert.ToSingle((Math.Cos(angulo)*radio)),gusano.position.y + Convert.ToSingle((Math.Sin(angulo)*radio)),gusano.position.z);
                        movimiento = false;
                    }*/
                    if (angulo <= -1.571 || angulo >= 1.571)
                    {
                        angulo = 0;
                    }
                    else if ((Input.GetKey(KeyCode.UpArrow) || movimiento) && angulo <= 1.45)
                    {
                        movimiento = false;
                        angulo = angulo + (velocidadMira * Time.deltaTime);
                        transform.position = new Vector3(gusano.position.x + Convert.ToSingle((Math.Cos(angulo) * radio)), gusano.position.y + Convert.ToSingle((Math.Sin(angulo) * radio)), gusano.position.z);

                    }
                    else if ((Input.GetKey(KeyCode.DownArrow) || movimiento) && angulo >= -1.45)
                    {
                        movimiento = false;
                        angulo = angulo - (velocidadMira * Time.deltaTime);
                        transform.position = new Vector3(gusano.position.x + Convert.ToSingle((Math.Cos(angulo) * radio)), gusano.position.y + Convert.ToSingle((Math.Sin(angulo) * radio)), gusano.position.z);
                    }
                }
            }
        }
        
    }
    public void setMovimiento(Boolean movimiento){
        this.movimiento = movimiento;
    }

    public double getAngulo()
    {
        return this.angulo;
    }
}
