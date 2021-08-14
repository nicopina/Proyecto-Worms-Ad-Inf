using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public bool se_ve;
    public Vector3 pos;
    public GameObject worm;
    public int tiempo;
    public int viento;
    // Start is called before the first frame update
    private float escala_viento;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().Find("TiempoPartida").gameObject.GetComponent<Text>().text = tiempo.ToString();
        gameObject.GetComponent<Transform>().Find("Barra Viento").gameObject.transform.Find("Barra Verde").gameObject.transform.localScale  = new Vector3((98*viento)/7,14,0);

        if(viento < 0){
            gameObject.GetComponent<Transform>().Find("Barra Viento").gameObject.transform.Find("L").gameObject.SetActive(false);
            gameObject.GetComponent<Transform>().Find("Barra Viento").gameObject.transform.Find("R").gameObject.SetActive(true);
            gameObject.GetComponent<Transform>().Find("Barra Viento").gameObject.transform.Find("Barra Verde").gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if(viento == 0){
            gameObject.GetComponent<Transform>().Find("Barra Viento").gameObject.transform.Find("L").gameObject.SetActive(true);
            gameObject.GetComponent<Transform>().Find("Barra Viento").gameObject.transform.Find("R").gameObject.SetActive(true);
        }
        else{
            gameObject.GetComponent<Transform>().Find("Barra Viento").gameObject.transform.Find("L").gameObject.SetActive(true);
            gameObject.GetComponent<Transform>().Find("Barra Viento").gameObject.transform.Find("R").gameObject.SetActive(false);
            gameObject.GetComponent<Transform>().Find("Barra Viento").gameObject.transform.Find("Barra Verde").gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        pos = gameObject.GetComponent<Transform>().Find("armas").gameObject.GetComponent<Transform>().Find("Panel armas").gameObject.GetComponent<RectTransform>().localPosition;
        if (gameObject.GetComponent<Transform>().Find("armas").gameObject.GetComponent<Transform>().Find("Panel armas").gameObject.GetComponent<RectTransform>().localPosition.x == 359)
        {
            se_ve = true;
            gameObject.GetComponent<Transform>().Find("armas").gameObject.GetComponent<Transform>().Find("Panel armas").gameObject.GetComponent<Transform>().Find("Panel").gameObject.SetActive(true);
        }
        if (gameObject.GetComponent<Transform>().Find("armas").gameObject.GetComponent<Transform>().Find("Panel armas").gameObject.GetComponent<RectTransform>().localPosition.x == 490)
        {
            se_ve = false;
            gameObject.GetComponent<Transform>().Find("armas").gameObject.GetComponent<Transform>().Find("Panel armas").gameObject.GetComponent<Transform>().Find("Panel").gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.W) && gameObject.GetComponent<UI>().worm.GetComponent<Worm_weapons>().control_jetpack == -1 && gameObject.GetComponent<UI>().worm.GetComponent<Worm_weapons>().weapon_name != "Air_strike" && gameObject.GetComponent<UI>().worm.GetComponent<Worm_weapons>().weapon_name != "Napalm")
        {
            
            mover();
        } 
    }
    public void mover()
    {
        if (se_ve)
        {
            gameObject.GetComponent<Transform>().Find("armas").gameObject.GetComponent<Transform>().Find("Panel armas").gameObject.GetComponent<RectTransform>().localPosition = new Vector3(490, pos.y, 0);
        }
        if (!se_ve)
        {
            gameObject.GetComponent<Transform>().Find("armas").gameObject.GetComponent<Transform>().Find("Panel armas").gameObject.GetComponent<RectTransform>().localPosition = new Vector3(359, pos.y, 0);
        }
    }

    public void no_weapon()
    {
        worm.GetComponent<Worm_weapons>().weapon = 0;
    }

    public void bow()
    {
        worm.GetComponent<Worm_weapons>().weapon = 1;
    }

    public void rope()
    {
        worm.GetComponent<Worm_weapons>().weapon = 2;
    }

    public void grenade()
    {
        worm.GetComponent<Worm_weapons>().weapon = 3;
    }

    public void holy_grenade()
    {
        worm.GetComponent<Worm_weapons>().weapon = 4;
    }

    public void jetpack()
    {
        worm.GetComponent<Worm_weapons>().weapon = 5;
    }

    public void mine()
    {
        worm.GetComponent<Worm_weapons>().weapon = 6;
    }

    public void fire_strike()
    {
        worm.GetComponent<Worm_weapons>().weapon = 7;
    }

    public void sheep()
    {
        worm.GetComponent<Worm_weapons>().weapon = 8;
    }

    public void banana()
    {
        worm.GetComponent<Worm_weapons>().weapon = 9;
    }

    public void bazooka()
    {
        worm.GetComponent<Worm_weapons>().weapon = 10;
    }

    public void pistol()
    {
        worm.GetComponent<Worm_weapons>().weapon = 11;
    }

    public void shotgun()
    {
        worm.GetComponent<Worm_weapons>().weapon = 12;
    }

    public void bungee()
    {
        worm.GetComponent<Worm_weapons>().weapon = 13;
    }

    public void uzi()
    {
        worm.GetComponent<Worm_weapons>().weapon = 14;
    }

    public void awp()
    {
        worm.GetComponent<Worm_weapons>().weapon = 15;
    }

    public void select()
    {
        worm.GetComponent<Worm_weapons>().weapon = 16;
    }

    public void surender()
    {
        worm.GetComponent<Worm_weapons>().weapon = 17;
    }

    public void air_strike()
    {
        worm.GetComponent<Worm_weapons>().weapon = 18;
    }    

    
}
