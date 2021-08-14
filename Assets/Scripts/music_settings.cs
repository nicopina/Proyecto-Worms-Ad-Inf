using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class music_settings : MonoBehaviour
{
    public AudioMixer mixer;
    private float volumen_musica;
    private float volumen_efectos;
    private float vol_general;
    public AudioClip[] musica_cube;
    public AudioSource fuente_sonido;
    private int indice;
    void Start()
    {


        volumen_musica = PlayerPrefs.GetFloat("volumenMusica");
        volumen_efectos = PlayerPrefs.GetFloat("volumenEfectos");
        vol_general = PlayerPrefs.GetFloat("volumenGeneral");

        mixer.SetFloat("Vol_musica", volumen_musica);
        mixer.SetFloat("Vol_efectos", volumen_efectos);
        mixer.SetFloat("Vol_master", vol_general);


        if (SceneManager.GetActiveScene().name == "cubo")
        {
            indice = (int) Random.Range(0,2);
            fuente_sonido.clip = musica_cube[indice];
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "cubo" && !fuente_sonido.isPlaying)
        {

            indice = (int)Random.Range(0, 2);
            fuente_sonido.clip = musica_cube[indice];
            fuente_sonido.Play();

        }

        if (PlayerPrefs.GetInt("fin_partida") == 1)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }

        volumen_musica = PlayerPrefs.GetFloat("volumenMusica");
        volumen_efectos = PlayerPrefs.GetFloat("volumenEfectos");
        vol_general = PlayerPrefs.GetFloat("volumenGeneral");

        mixer.SetFloat("Vol_musica", volumen_musica);
        mixer.SetFloat("Vol_efectos", volumen_efectos);
        mixer.SetFloat("Vol_master", vol_general);
    }
}
