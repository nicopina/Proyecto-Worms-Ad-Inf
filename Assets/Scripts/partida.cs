using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;
using UnityEngine.UI;


public class partida : MonoBehaviour
{

    public float tiempo_continuo;
    public int tiempo;
    public int tope_tiempo = 10;
    public GameObject worm_active = null;
    public GameObject[] worms_list;
    public GameObject[] team1;
    public GameObject[] team2;
    public int player1_pointer = 0;
    public int player2_pointer = 0;
    public int team_active;
    private bool comenzo_partida = false;
    public GameObject viento;
    public int fuerza_viento; //-10 y 10 es el valor maximo.

    public GameObject cerebro_camara;
    private int vida_team1;
    private int vida_team2;
    public bool fin_partida = false;
    public bool pausa_ahogado = false;
    public bool pausa_disparo = false;
    public float tiempo_pausa_ahogado;
    public float tiempo_pausa_disparo = 0;
    public GameObject mira;

    public GameObject ui;

    public GameObject fin;


    public int target = 60;

    void Start()
    {
        PlayerPrefs.SetInt("fin_partida", 0);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;

        PlayerPrefs.SetInt("win", 0);
        tope_tiempo = PlayerPrefs.GetInt("tiempoRonda");
        //Comenzamos la partida desactivando todas las bazookas que traen los worms.
        Time.timeScale = 1;
        for (int i = 0; i < team1.Length; i++)
        {
            GameObject worm_i = team1[i];
            worm_i.transform.Find("weapon").gameObject.SetActive(false);
            team1[i].GetComponent<Worm_health>().nombre = PlayerPrefs.GetString("nombreJugador"+(i+1).ToString()+"Equipo1"); 
            team1[i].GetComponent<Worm_health>().equipo = 1; 
        }

        for (int i = 0; i < team2.Length; i++)
        {
            GameObject worm_i = team2[i];
            worm_i.transform.Find("weapon").gameObject.SetActive(false);
            team2[i].GetComponent<Worm_health>().nombre = PlayerPrefs.GetString("nombreJugador"+(i+1).ToString()+"Equipo2"); 
            team2[i].GetComponent<Worm_health>().equipo = 2; 
        }
    }

        // Update is called once per frame
        void Update()
    {
         
        int cont_players1 = team1.Length;
        int cont_players2 = team2.Length;

        ui.GetComponent<UI>().viento = fuerza_viento;

        if (GameObject.FindGameObjectsWithTag("Sheep").Length != 0){
            cerebro_camara.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectsWithTag("Sheep")[0].transform;
            GameObject.FindGameObjectsWithTag("Sheep")[0].GetComponent<sheep_controller>().tiempo_explosion = tiempo;
        }

        if (!comenzo_partida) //Inicio partida
        {

            fuerza_viento = Random.Range(-7, 7);
            viento.GetComponent<AreaEffector2D>().forceMagnitude = fuerza_viento;

            worm_active = team1[0];
            ui.GetComponent<UI>().worm = worm_active;

            worm_active.GetComponent<Worm_Controller>().tiene_tiempo = true;
            worm_active.GetComponent<Worm_Controller>().mira = mira;
            worm_active.GetComponent<Worm_animacion_apuntar>().mira = mira;
            mira.GetComponent<Apuntar>().gusano = worm_active.transform;

            worm_active.GetComponent<Worm_Controller>().Uso = true;
            worm_active.GetComponent<Worm_animacion_apuntar>().enabled = true;
            worm_active.transform.Find("weapon").gameObject.SetActive(true);
            worm_active.GetComponent<Worm_weapons>().enabled = true;
            worm_active.GetComponent<Worm_weapons>().canShoot = true;
            //worm_active.GetComponent<Animator>().enabled = false;

            player1_pointer = 0;
            
            team_active = 1;
            comenzo_partida = true;
        }

        if (tiempo >= tope_tiempo && !fin_partida) //Se acaba el tiempo (se acaba la ronda)
        {

            if (team_active == 1) //Se le acaba el tiempo al worm del team1
            {
                //Deshabilitar el worm activo del team 1
                //worm_active.GetComponent<Animator>().enabled = true; //Para que se vaya Stand
                if (worm_active != null)
                {
                    worm_active.GetComponent<Worm_Controller>().tiene_tiempo = false;
                    worm_active.GetComponent<Worm_Controller>().Uso = false;
                    worm_active.GetComponent<Worm_animacion_apuntar>().enabled = false;
                    worm_active.GetComponent<Worm_weapons>().enabled = false;
                    worm_active.transform.Find("weapon").gameObject.SetActive(false);
                    worm_active.GetComponent<Worm_weapons>().canShoot = false;
                    worm_active.GetComponent<Worm_Controller>().mira = null;
                    worm_active.GetComponent<Worm_animacion_apuntar>().mira = null;
                    worm_active.GetComponent<Animator>().SetBool("Walking", false);
                    worm_active.GetComponent<Animator>().SetBool("Jump", false);
                }
                player2_pointer++;

                if (player2_pointer >= team2.Length)
                {
                    player2_pointer = 0;
                }

                team_active = 2; //Cambio de team al 2
                worm_active = team2[player2_pointer]; //Worm activo del team2
                worm_active.GetComponent<Worm_weapons>().weapon = 0;

                //Habilitar el worm activo del team 2
                //worm_active.GetComponent<Animator>().enabled = false; //Para que siga las animaciones de apuntar.
                worm_active.GetComponent<Worm_Controller>().tiene_tiempo = true;
                worm_active.GetComponent<Worm_Controller>().Uso = true;
                worm_active.GetComponent<Worm_animacion_apuntar>().enabled = true;
                worm_active.GetComponent<Worm_weapons>().enabled = true;
                worm_active.transform.Find("weapon").gameObject.SetActive(true);
                mira.GetComponent<Apuntar>().gusano = worm_active.transform;
                worm_active.GetComponent<Worm_weapons>().canShoot = true;
                worm_active.GetComponent<Worm_Controller>().mira = mira;
                worm_active.GetComponent<Worm_animacion_apuntar>().mira = mira;

               

            }

            else //Se le acaba el tiempo al worm del team2
            {
                //Deshabilitar el worm activo del team 2
                //worm_active.GetComponent<Animator>().enabled = true; //Para que se vaya al stand
                if (worm_active != null)
                {
                    worm_active.GetComponent<Worm_Controller>().tiene_tiempo = false;
                    worm_active.GetComponent<Worm_Controller>().Uso = false;
                    worm_active.GetComponent<Worm_animacion_apuntar>().enabled = false;
                    worm_active.GetComponent<Worm_weapons>().enabled = false;
                    worm_active.transform.Find("weapon").gameObject.SetActive(false);
                    worm_active.GetComponent<Worm_weapons>().canShoot = false;
                    worm_active.GetComponent<Worm_Controller>().mira = null;
                    worm_active.GetComponent<Worm_animacion_apuntar>().mira = null;
                    worm_active.GetComponent<Animator>().SetBool("Walking", false);
                    worm_active.GetComponent<Animator>().SetBool("Jump", false);
                }

                player1_pointer++;

                if (player1_pointer >= team1.Length)
                {
                    player1_pointer = 0;
                }

                team_active = 1; //Team activo -> 1
                worm_active = team1[player1_pointer]; //cambio de Worm activo al del team 1
                worm_active.GetComponent<Worm_weapons>().weapon = 0;

                //Habilitar el worm activo del team 1
                //worm_active.GetComponent<Animator>().enabled = false; //Para que siga las animaciones de apuntar
                worm_active.GetComponent<Worm_Controller>().tiene_tiempo = true;
                worm_active.GetComponent<Worm_Controller>().Uso = true;
                worm_active.GetComponent<Worm_animacion_apuntar>().enabled = true;
                worm_active.GetComponent<Worm_weapons>().enabled = true;
                worm_active.GetComponent<Worm_weapons>().canShoot = true;
                worm_active.transform.Find("weapon").gameObject.SetActive(true);
                mira.GetComponent<Apuntar>().gusano = worm_active.transform;

                worm_active.GetComponent<Worm_Controller>().mira = mira;
                worm_active.GetComponent<Worm_animacion_apuntar>().mira = mira;

                
            }

            //Seteo de los valores del viento.
            fuerza_viento = Random.Range(-7, 7);
            viento.GetComponent<AreaEffector2D>().forceMagnitude = fuerza_viento;
            tiempo_continuo = 0;
            tiempo = 0;

            ui.GetComponent<UI>().worm = worm_active;
            cerebro_camara.GetComponent<CinemachineVirtualCamera>().Follow = worm_active.transform;
        }


        if (!pausa_ahogado && !pausa_disparo && !fin_partida)
        {
            tiempo_continuo = tiempo_continuo + Time.deltaTime;
            tiempo = (int)tiempo_continuo;
            ui.GetComponent<UI>().tiempo = tope_tiempo - tiempo;
        }

        if (pausa_ahogado && tiempo_pausa_ahogado < 3f)
        {
            tiempo_pausa_ahogado = tiempo_pausa_ahogado + Time.deltaTime;
            ui.GetComponent<UI>().tiempo = 3 - (int)tiempo_pausa_ahogado;
        }

        if (pausa_ahogado && tiempo_pausa_ahogado >= 3f)
        {
            pausa_ahogado = false;
            tiempo = tope_tiempo + 1;
            tiempo_pausa_ahogado = 0;
        }

        if (!fin_partida)
        {
            if (worm_active != null)
            {
                if (worm_active.GetComponent<Worm_weapons>().disparo && !pausa_disparo)
                {
                    pausa_disparo = true;
                }

                if (pausa_disparo && tiempo_pausa_disparo <= worm_active.GetComponent<Worm_weapons>().disparo_tiempo)
                {
                    tiempo_pausa_disparo = tiempo_pausa_disparo + Time.deltaTime;
                    ui.GetComponent<UI>().tiempo = worm_active.GetComponent<Worm_weapons>().disparo_tiempo - (int)tiempo_pausa_disparo;
                }

                if (pausa_disparo && tiempo_pausa_disparo >= worm_active.GetComponent<Worm_weapons>().disparo_tiempo)
                {
                    worm_active.GetComponent<Worm_weapons>().disparo = false;
                    pausa_disparo = false;
                    tiempo = tope_tiempo + 1;
                    tiempo_pausa_disparo = 0;
                }
            }
            if (worm_active == null)
            {
                pausa_disparo = false;
                tiempo = tope_tiempo + 1;
            }
        }

        //Checkeo de vidas team 1
        for (int i = 0; i < team1.Length; i++)
        {
            GameObject worm_i = team1[i];
            
            if (worm_i.GetComponent<Worm_health>().vida <= 0)
            {

                //Cuando termine la animación-explosion tiene que eliminarse de la lista.
                //DESCOMENTAR CUANDO ESTE LISTA ANIMACION
                mira.GetComponent<Apuntar>().gusano = null;
                int indexToRemove = i;
                team1 = team1.Where((source, index) => index != indexToRemove).ToArray();
                i = i - 1;
            }

            //Muerte por ahogamiento -> 2 Casos.
            //Caso 1 Se ahoga y No es su turno
            
            if (worm_i.GetComponent<Worm_health>().ahogado && worm_i != worm_active)
            { //Se borra de la lista.
                int indexToRemove = i;
                team1 = team1.Where((source, index) => index != indexToRemove).ToArray();
                i = i - 1;
            }

            //Caso 2 Se ahoga y es su turno.

            if (worm_i.GetComponent<Worm_health>().ahogado && worm_i == worm_active)
            { //Se borra de la lista.

                pausa_ahogado = true;

                mira.GetComponent<Apuntar>().gusano = null;

                int indexToRemove = i;
                team1 = team1.Where((source, index) => index != indexToRemove).ToArray();
                i = i - 1;
            }
            

        }

        //Checkeo de vidas team 2
        for (int i = 0; i < team2.Length; i++)
        {
            GameObject worm_i = team2[i];

            if (worm_i.GetComponent<Worm_health>().vida <= 0)
            {
                //Acá tiene que correr la animación-explosion de muerte


                //Cuando termine la animación-explosion tiene que eliminarse de la lista.
                //DESCOMENTAR CUANDO ESTE LISTA ANIMACION
                mira.GetComponent<Apuntar>().gusano = null;
                int indexToRemove = i;
                team2 = team2.Where((source, index) => index != indexToRemove).ToArray();
                i = i - 1;
            }

            //Muerte por ahogamiento -> 2 Casos.
            //Caso 1 Se ahoga y No es su turno
            
            if (worm_i.GetComponent<Worm_health>().ahogado && worm_i != worm_active)
            { //Se borra de la lista.
                int indexToRemove = i;
                team2 = team2.Where((source, index) => index != indexToRemove).ToArray();
                i = i - 1;
            }


            //Caso 2 Se ahoga y es su turno.

            if (worm_i.GetComponent<Worm_health>().ahogado && worm_i == worm_active)
            { //Se borra de la lista.

                pausa_ahogado = true;
                mira.GetComponent<Apuntar>().gusano = null;
                int indexToRemove = i;
                team2 = team2.Where((source, index) => index != indexToRemove).ToArray();
                i = i - 1;
            }

        }

        

        if (team1.Length != 0 && team2.Length == 0 && !fin_partida) //Gana el team1
        {
            PlayerPrefs.SetInt("ganador", 1);
            worm_active.GetComponent<Worm_Controller>().mira.SetActive(false);
            worm_active.GetComponent<Worm_Controller>().arma.SetActive(false);
            cerebro_camara.GetComponent<CinemachineVirtualCamera>().Follow = fin.transform;
            PlayerPrefs.SetInt("win", 1);
            fin_partida = true;
            PlayerPrefs.SetInt("fin_partida", 1);
            ui.GetComponent<AudioSource>().Play();
            for (int i = 0; i < team1.Length; i++)
            {
                GameObject worm_i = team1[i];
                worm_i.GetComponent<Animator>().SetBool("win",true);
            }
        }

        if (team2.Length != 0 && team1.Length == 0 && !fin_partida) //Gana el team2
        {
            PlayerPrefs.SetInt("ganador", 2);
            worm_active.GetComponent<Worm_Controller>().mira.SetActive(false);
            worm_active.GetComponent<Worm_Controller>().arma.SetActive(false);
            cerebro_camara.GetComponent<CinemachineVirtualCamera>().Follow = fin.transform;
            PlayerPrefs.SetInt("win", 1);
            fin_partida = true;
            PlayerPrefs.SetInt("fin_partida", 1);
            ui.GetComponent<AudioSource>().Play();
            for (int i = 0; i < team2.Length; i++)
            {
                GameObject worm_i = team2[i];
                worm_i.GetComponent<Animator>().SetBool("win", true);
            }
        }
        if (team1.Length == 0 && team2.Length == 0 && !fin_partida) //Empate
        {
            PlayerPrefs.SetInt("ganador", 3);
            cerebro_camara.GetComponent<CinemachineVirtualCamera>().Follow = fin.transform;
            fin_partida = true;
            PlayerPrefs.SetInt("fin_partida", 1);
        }


    }
}
