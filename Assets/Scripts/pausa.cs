using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausa : MonoBehaviour
{
    public GameObject imagenPausa;
    // Start is called before the first frame update
    void Start()
    {
        imagenPausa.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                imagenPausa.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                imagenPausa.SetActive(false);
            }

        }
    }

    public void volverPartida()
    {
        Time.timeScale = 1;
        imagenPausa.SetActive(false);
    }

    public void volverMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}   
