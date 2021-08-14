using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class intro_settings : MonoBehaviour
{
    private float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;

        if ((tiempo >= 18.5f) || Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
