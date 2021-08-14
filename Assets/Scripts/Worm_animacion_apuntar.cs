using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_animacion_apuntar : MonoBehaviour
{
    public GameObject mira;
    public double angulo;
    public Sprite[] frames;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!gameObject.GetComponent<Animator>().isActiveAndEnabled)
        {
            
            angulo = mira.GetComponent<Apuntar>().getAngulo();
            angulo = angulo * 360/ (2*Mathf.PI);

            if (angulo <= 45 && angulo >= -45 || angulo >= 135 && angulo <= 225)
            {//Si mira hacia el frente

                gameObject.GetComponent<SpriteRenderer>().sprite = frames[1];
            }

            if (angulo > 45 && angulo < 135)
            {//Si mira hacia arriba

                gameObject.GetComponent<SpriteRenderer>().sprite = frames[0];
            }

            if (angulo < -45 && angulo >= -83.1 || angulo > 225 && angulo < 269.9)
            {//Si mira hacia abajo

                gameObject.GetComponent<SpriteRenderer>().sprite = frames[2];
            }
        }


    }
}
