using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_detector : MonoBehaviour
{
    private AudioSource fuenteAudio;
    void Start()
    {
        fuenteAudio = gameObject.GetComponent<AudioSource>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "hoja" && collision.tag != "fuego")
        {
            fuenteAudio.Play();
        }
        
    }
}
