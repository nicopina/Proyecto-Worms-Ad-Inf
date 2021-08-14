using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busca_fuego : MonoBehaviour
{
    AudioSource fuenteAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("fuego").Length != 0)
        {
            if (!fuenteAudio.loop)
            {
                fuenteAudio.loop = true;
                fuenteAudio.Play();
            }
        }
        else
        {
            fuenteAudio.loop = false;
            fuenteAudio.Stop();
        }
    }
}
