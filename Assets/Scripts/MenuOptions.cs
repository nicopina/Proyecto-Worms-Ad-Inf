using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] mapas;
    public Slider sliderVolumenGeneral;
    public Slider sliderVolumenMusica;
    public Slider sliderVolumenEfectos;
    public float volumen;
    //public gameObject musica;

    private int auxMapa;
    private float tiempoAux;

    void Start(){
        gameObject.transform.Find("MenuInicio").gameObject.SetActive(true);
        gameObject.transform.Find("MenuOpciones").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.SetActive(false);
        PlayerPrefs.SetInt("tiempoRonda",15);
        PlayerPrefs.GetInt("mute",0);
        PlayerPrefs.GetInt("vidaInicial",100);
        sliderVolumenGeneral.value = PlayerPrefs.GetFloat("volumenGeneral",-10f);
        sliderVolumenMusica.value = PlayerPrefs.GetFloat("volumenMusica",-10f);
        sliderVolumenEfectos.value = PlayerPrefs.GetFloat("volumenEfectos",-10f);
        auxMapa  = 0;
    }
    void Update()
    {   
        PlayerPrefs.SetFloat("volumenGeneral",sliderVolumenGeneral.value);
        PlayerPrefs.SetFloat("volumenMusica",sliderVolumenMusica.value);
        PlayerPrefs.SetFloat("volumenEfectos",sliderVolumenEfectos.value);

        cantidadWorms();


    }
        
    public void Jugar()
    {
        setNombres();
        PlayerPrefs.GetInt("vidaInicial",100);
        switch(auxMapa){
            case 0:
                SceneManager.LoadScene("bosque");
                break;
            case 1:
                SceneManager.LoadScene("nieve");
                break;
            case 2:
                SceneManager.LoadScene("desierto");
                break;
            case 3:
                SceneManager.LoadScene("ciudad");
                break;
            case 4:
                SceneManager.LoadScene("cubo");
                break;
            default:
                SceneManager.LoadScene("Menu");
                break;
        }
        
    }

    public void Opciones()
    {
        gameObject.transform.Find("MenuInicio").gameObject.SetActive(false);
        gameObject.transform.Find("MenuOpciones").gameObject.SetActive(true);
        

        if(PlayerPrefs.GetInt("mute") == 0){

            gameObject.transform.Find("MenuOpciones").gameObject.transform.Find("VolumeOn").gameObject.SetActive(false);
            gameObject.transform.Find("MenuOpciones").gameObject.transform.Find("VolumeOf").gameObject.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("mute") == 1) {
            gameObject.transform.Find("MenuOpciones").gameObject.transform.Find("VolumeOn").gameObject.SetActive(true);
            gameObject.transform.Find("MenuOpciones").gameObject.transform.Find("VolumeOf").gameObject.SetActive(false);
        }
    }
    public void VolverDeOpciones()
    {
        gameObject.transform.Find("MenuInicio").gameObject.SetActive(true);
        gameObject.transform.Find("MenuOpciones").gameObject.SetActive(false);

    }
    public void VolverDePartida()
    {
        gameObject.transform.Find("MenuInicio").gameObject.SetActive(true);
        setNombres();
        gameObject.transform.Find("Partida").gameObject.SetActive(false);
        

    }

    public void partida()
    {

        gameObject.transform.Find("MenuInicio").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.SetActive(true);

        setTextosNombres();
        if (PlayerPrefs.GetInt("tiempoRonda") == 5){
            gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("5").gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("tiempoRonda") == 10){
            gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("10").gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("tiempoRonda") == 15){
            gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("15").gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("tiempoRonda") == 20){
            gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("20").gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("tiempoRonda") == 25){
            gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("25").gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("tiempoRonda") == 30){
            gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("30").gameObject.SetActive(true);
        }
        setTextosNombres();

        setVida();

    }
    
    public void Salir()
    {
        Application.Quit();
    }
    public void SetVolume(float volume)
    {
        /*GameObject volumen = gameObject.transform.Find("MenuOpciones").gameObject.transform.Find("Volumen").gameObject;
        if(volume <= 0){
            volumen.transform.Find("Sonido 0").gameObject.SetActive(true);
            volumen.transform.Find("Sonido 1").gameObject.SetActive(false);
        }
        if(volume > 0){
            volumen.transform.Find("Sonido 1").gameObject.SetActive(true);
            volumen.transform.Find("Sonido 0").gameObject.SetActive(false);
        }*/
    }
    public void cambioMapa(){

        if(auxMapa < mapas.Length-1){
            mapas[auxMapa].gameObject.SetActive(false);
            auxMapa++;
            mapas[auxMapa].gameObject.SetActive(true);
        }
        else{
            mapas[auxMapa].gameObject.SetActive(false);
            auxMapa = 0;
            mapas[auxMapa].gameObject.SetActive(true);

        }
            
        
        

    }
    public void volumeOf(){

        PlayerPrefs.SetInt("mute",0);
        gameObject.transform.Find("Musica").gameObject.GetComponent<AudioSource>().mute = true;
        gameObject.transform.Find("MenuOpciones").gameObject.transform.Find("VolumeOn").gameObject.SetActive(false);
        gameObject.transform.Find("MenuOpciones").gameObject.transform.Find("VolumeOf").gameObject.SetActive(true);

    }
    public void volumeOn(){

        PlayerPrefs.SetInt("mute",1);
        gameObject.transform.Find("Musica").gameObject.GetComponent<AudioSource>().mute = false;
        gameObject.transform.Find("MenuOpciones").gameObject.transform.Find("VolumeOn").gameObject.SetActive(true);
        gameObject.transform.Find("MenuOpciones").gameObject.transform.Find("VolumeOf").gameObject.SetActive(false);
        
        
    }

    public void vida100_150(){
        gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("100").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("150").gameObject.SetActive(true);
        PlayerPrefs.SetInt("vidaInicial",150);
    }
    public void vida150_200(){
        gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("150").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("200").gameObject.SetActive(true);
        PlayerPrefs.SetInt("vidaInicial",200);
    }
    public void vida200_infi(){
        gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("200").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("infinito").gameObject.SetActive(true);
        PlayerPrefs.SetInt("vidaInicial",100000000);
    }
    public void infi_100(){
        gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("infinito").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("100").gameObject.SetActive(true);
        PlayerPrefs.SetInt("vidaInicial",100);
    }

    void setVida(){
        
        if(PlayerPrefs.GetInt("vidaInicial",100) == 99999999999999){
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("infinito").gameObject.SetActive(true);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("200").gameObject.SetActive(false);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("150").gameObject.SetActive(false);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("100").gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt("vidaInicial",100) == 200){
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("infinito").gameObject.SetActive(false);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("200").gameObject.SetActive(true);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("150").gameObject.SetActive(false);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("100").gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt("vidaInicial",100) == 150){
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("infinito").gameObject.SetActive(false);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("200").gameObject.SetActive(false);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("150").gameObject.SetActive(true);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("100").gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt("vidaInicial",100) == 100){
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("infinito").gameObject.SetActive(false);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("200").gameObject.SetActive(false);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("150").gameObject.SetActive(false);
            gameObject.transform.Find("Partida").gameObject.transform.Find("vida").gameObject.transform.Find("100").gameObject.SetActive(true);
        }


    }
    public void turno510(){
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("5").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("10").gameObject.SetActive(true);
        PlayerPrefs.SetInt("tiempoRonda",10);
    }
    public void turno1015(){
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("10").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("15").gameObject.SetActive(true);
        PlayerPrefs.SetInt("tiempoRonda",15);
    }
    public void turno1520(){
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("15").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("20").gameObject.SetActive(true);
        PlayerPrefs.SetInt("tiempoRonda",20);
    }
    public void turno2025(){
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("20").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("25").gameObject.SetActive(true);
        PlayerPrefs.SetInt("tiempoRonda",25);
    }
    public void turno2530(){
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("25").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("30").gameObject.SetActive(true);
        PlayerPrefs.SetInt("tiempoRonda",30);
    }
        public void turno305(){
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("30").gameObject.SetActive(false);
        gameObject.transform.Find("Partida").gameObject.transform.Find("turno").gameObject.transform.Find("5").gameObject.SetActive(true);
        PlayerPrefs.SetInt("tiempoRonda",5);
    }
    void cantidadWorms(){
        if(auxMapa == 0 || auxMapa == 1 || auxMapa == 4){
            PlayerPrefs.SetInt("cantidadWorms",4);
            gameObject.transform.Find("Partida").gameObject.transform.Find("Equipo1").gameObject.transform.Find("inputJugador5").gameObject.SetActive(false);
            gameObject.transform.Find("Partida").gameObject.transform.Find("Equipo2").gameObject.transform.Find("inputJugador5").gameObject.SetActive(false);
        }
        else if(auxMapa == 5 || auxMapa == 3 || auxMapa ==2){
            PlayerPrefs.SetInt("cantidadWorms",5);
            gameObject.transform.Find("Partida").gameObject.transform.Find("Equipo1").gameObject.transform.Find("inputJugador5").gameObject.SetActive(true);
            gameObject.transform.Find("Partida").gameObject.transform.Find("Equipo2").gameObject.transform.Find("inputJugador5").gameObject.SetActive(true);
        }



        //gameObject.transform.Find("Partida").gameObject.transform.Find("Equipo2").gameObject.transform.Find("inputNomEquipo").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreEquipo1");
    }
    void setTextosNombres(){

        GameObject equipo1 = gameObject.transform.Find("Partida").gameObject.transform.Find("Equipo1").gameObject;
        equipo1.transform.Find("inputNomEquipo").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreEquipo1","Equipo 1");
        equipo1.transform.Find("inputJugador1").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreJugador1Equipo1","Jugador 1.1");
        equipo1.transform.Find("inputJugador2").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreJugador2Equipo1","Jugador 1.2");
        equipo1.transform.Find("inputJugador3").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreJugador3Equipo1","Jugador 1.3");
        equipo1.transform.Find("inputJugador4").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreJugador4Equipo1","Jugador 1.4");
        equipo1.transform.Find("inputJugador5").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreJugador5Equipo1","Jugador 1.5");
        GameObject equipo2 = gameObject.transform.Find("Partida").gameObject.transform.Find("Equipo2").gameObject;
        equipo2.transform.Find("inputNomEquipo").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreEquipo2","Equipo 2");
        equipo2.transform.Find("inputJugador1").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreJugador1Equipo2","Jugador 2.1");
        equipo2.transform.Find("inputJugador2").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreJugador2Equipo2","Jugador 2.2");
        equipo2.transform.Find("inputJugador3").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreJugador3Equipo2","Jugador 2.3");
        equipo2.transform.Find("inputJugador4").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreJugador4Equipo2","Jugador 2.4");
        equipo2.transform.Find("inputJugador5").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("nombreJugador5Equipo2","Jugador 2.5");
    }
    void setNombres(){
        GameObject equipo1 = gameObject.transform.Find("Partida").gameObject.transform.Find("Equipo1").gameObject;
        if(equipo1.transform.Find("inputNomEquipo").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreEquipo1",equipo1.transform.Find("inputNomEquipo").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreEquipo1",equipo1.transform.Find("inputNomEquipo").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo1.transform.Find("inputJugador1").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador1Equipo1",equipo1.transform.Find("inputJugador1").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador1Equipo1",equipo1.transform.Find("inputJugador1").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo1.transform.Find("inputJugador2").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador2Equipo1",equipo1.transform.Find("inputJugador2").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador2Equipo1",equipo1.transform.Find("inputJugador2").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo1.transform.Find("inputJugador2").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador2Equipo1",equipo1.transform.Find("inputJugador2").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador2Equipo1",equipo1.transform.Find("inputJugador2").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo1.transform.Find("inputJugador3").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador3Equipo1",equipo1.transform.Find("inputJugador3").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador3Equipo1",equipo1.transform.Find("inputJugador3").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo1.transform.Find("inputJugador4").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador4Equipo1",equipo1.transform.Find("inputJugador4").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador4Equipo1",equipo1.transform.Find("inputJugador4").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo1.transform.Find("inputJugador5").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador5Equipo1",equipo1.transform.Find("inputJugador5").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador5Equipo1",equipo1.transform.Find("inputJugador5").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }

        
        GameObject equipo2 = gameObject.transform.Find("Partida").gameObject.transform.Find("Equipo2").gameObject;


        if(equipo2.transform.Find("inputNomEquipo").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreEquipo2",equipo2.transform.Find("inputNomEquipo").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreEquipo2",equipo2.transform.Find("inputNomEquipo").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo2.transform.Find("inputJugador1").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador1Equipo2",equipo2.transform.Find("inputJugador1").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador1Equipo2",equipo2.transform.Find("inputJugador1").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo2.transform.Find("inputJugador2").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador2Equipo2",equipo2.transform.Find("inputJugador2").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador2Equipo2",equipo2.transform.Find("inputJugador2").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo2.transform.Find("inputJugador2").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador2Equipo2",equipo2.transform.Find("inputJugador2").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador2Equipo2",equipo2.transform.Find("inputJugador2").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo2.transform.Find("inputJugador3").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador3Equipo2",equipo2.transform.Find("inputJugador3").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador3Equipo2",equipo2.transform.Find("inputJugador3").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo2.transform.Find("inputJugador4").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador4Equipo2",equipo2.transform.Find("inputJugador4").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador4Equipo2",equipo2.transform.Find("inputJugador4").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }
        if(equipo2.transform.Find("inputJugador5").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text.Equals("")){
            PlayerPrefs.SetString("nombreJugador5Equipo2",equipo2.transform.Find("inputJugador5").gameObject.transform.Find("Placeholder").gameObject.GetComponent<Text>().text);
        }
        else{
            PlayerPrefs.SetString("nombreJugador5Equipo2",equipo2.transform.Find("inputJugador5").gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text);
        }

    }

    public void creditos()
    {
        SceneManager.LoadScene("creditos");
    }
}
