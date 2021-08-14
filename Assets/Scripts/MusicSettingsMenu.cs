using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    private float volumen_musica;
    private float volumen_efectos;
    private float vol_general;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

        volumen_musica = PlayerPrefs.GetFloat("volumenMusica");
        volumen_efectos = PlayerPrefs.GetFloat("volumenEfectos");
        vol_general = PlayerPrefs.GetFloat("volumenGeneral");


        mixer.SetFloat("Vol_musica", volumen_musica);
        mixer.SetFloat("Vol_efectos", volumen_efectos);
        mixer.SetFloat("Vol_master", vol_general);

    }
}
