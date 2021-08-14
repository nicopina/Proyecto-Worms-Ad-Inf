using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    public bool active = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "worm")
        {
            if (transform.parent.gameObject.GetComponent<Mine_controller>().t_ini >= 5)
            {
                active = true;
            }

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "worm")
        {
            if (transform.parent.gameObject.GetComponent<Mine_controller>().t_ini >= 5f)
            { 
                active = true; 
            }
        }
    }
}
