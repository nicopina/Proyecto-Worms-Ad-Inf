using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Worm_weapons : MonoBehaviour
{
    public Boolean canShoot;
    public GameObject[] ammo;
    public GameObject actual_ammo;
    public Sprite[] weapons;
    private Sprite actual_weapon;
    public string weapon_name;
    public int weapon;
    public float largo_arma;
    public float angulo;
    public float fuerza;
    public float danoBase;
    public float time;
    public Boolean uzi = false;
    public Boolean pistol = false;
    public int contadorBalas;
    public AudioClip awpA;
    public AudioClip pistolA;
    public AudioClip shotgunA;
    public AudioClip uziA;
    private AudioSource sonidoD;
    public int control_jetpack;
    public bool disparo = false;
    public int disparo_tiempo = 0;
    public GameObject avion;

    //[SerializeField] private Transform[] ammo;
    //[SerializeField] private Transform actual_ammo;
    // 0. stand
    // 1. bow
    // 2. rope
    // 3. grenade
    // 4. holy_grenade
    // 5. jetpack
    // 6. proximiy_mine
    // 7. napalm
    // 8. sheep
    // 9. banana
    // 10. bazooka
    // 11. pistol
    // 12. shotgun
    // 13. bunjee
    // 14. uzi
    // 15. awp
    // 16. swap
    // 17. surrender
    // 18. air_strike


    // Start is called before the first frame update
    void Start()
    {
        control_jetpack = -1;
        sonidoD = gameObject.GetComponent<Transform>().Find("weapon").gameObject.GetComponent<AudioSource>();
        contadorBalas = 0;
        gameObject.GetComponent<Transform>().Find("weapon").gameObject.GetComponent<Transform>().Find("Throw Indicator").gameObject.GetComponent<Transform>().localScale = new Vector3(0.25f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (weapon == 0) //stand
        {
            weapon_name = "None";
            actual_weapon = weapons[0];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[0];
            danoBase = 0;
            disparo_tiempo = 3;
        }

        else if (weapon == 1) //bow
        {
            weapon_name = "Bow";
            actual_weapon = weapons[1];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[1];
            danoBase = 0;
            disparo_tiempo = 3;
        }

        else if (weapon == 2) //rope
        {
            weapon_name = "Rope";
            actual_weapon = weapons[2];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[2];
            danoBase = 0;
            disparo_tiempo = 3;
        }

        else if (weapon == 3) //grenade
        {
            weapon_name = "Grenade";
            actual_weapon = weapons[3];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[3];
            danoBase = 15;
            disparo_tiempo = 7;
        }

        else if (weapon == 4) //Holy_grenade
        {
            weapon_name = "Holy_grenade";
            actual_weapon = weapons[4];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[4];
            danoBase = 50;
            disparo_tiempo = 10;
        }

        else if (weapon == 5) //jetpack
        {
            weapon_name = "Jetpack";
            actual_weapon = weapons[5];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[5];
            danoBase = 0;
            disparo_tiempo = 3;
        }

        else if (weapon == 6) //prox_mine
        {
            weapon_name = "Proximity_mine";
            actual_weapon = weapons[6];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[6];
            danoBase = 20;
            disparo_tiempo = 6;
        }

        else if (weapon == 7) //napalm
        {
            weapon_name = "Napalm";
            actual_weapon = weapons[7];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[7];
            danoBase = 5;
            disparo_tiempo = 10;
            if (Input.GetMouseButton(0) && canShoot)
            {
                Vector3 ubicacion_misil = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PlayerPrefs.SetFloat("pos_misil", ubicacion_misil.x);
                PlayerPrefs.SetString("tipo_ataque", "napalm");

                GameObject av = Instantiate(avion) as GameObject;
                disparo = true;
                canShoot = false;

                GameObject ex = Instantiate(ammo[18]) as GameObject; //Es la 18 porque es la X.
                ex.transform.position = new Vector3(ubicacion_misil.x, ubicacion_misil.y, 0);

            }
        }

        else if (weapon == 8) //sheep
        {
            weapon_name = "Sheep";
            actual_weapon = weapons[8];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[8];
            danoBase = 40;
            disparo_tiempo = 10;
        }

        else if (weapon == 9) //banana
        {
            weapon_name = "Banana";
            actual_weapon = weapons[9];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[9];
            danoBase = 15;
            disparo_tiempo = 12;
        }

        else if (weapon == 10) //bazooka
        {
            weapon_name = "Bazooka";
            actual_weapon = weapons[10];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[10];
            danoBase = 15;
            disparo_tiempo = 5;
        }

        else if (weapon == 11) //pistol
        {
            weapon_name = "Pistol";
            actual_weapon = weapons[11];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[11];
            danoBase = 7;
            sonidoD.clip = pistolA;
            disparo_tiempo = 7;
        }

        else if (weapon == 12) //shotgun
        {
            weapon_name = "Shotgun";
            actual_weapon = weapons[12];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[12];
            danoBase = 20;
            sonidoD.clip = shotgunA;
            disparo_tiempo = 5;
        }

        else if (weapon == 13) //bunjee
        {
            weapon_name = "Bunjee";
            actual_weapon = weapons[13];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[13];
            danoBase = 0;
            disparo_tiempo = 3;
        }

        else if (weapon == 14) //uzi
        {
            weapon_name = "Uzi";
            actual_weapon = weapons[14];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[14];
            danoBase = 5;
            sonidoD.clip = uziA;
            disparo_tiempo = 12;
        }

        else if (weapon == 15) //awp
        {
            weapon_name = "Awp";
            actual_weapon = weapons[15];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[15];
            danoBase = 55;
            sonidoD.clip = awpA;
            disparo_tiempo = 5;
        }

        else if (weapon == 16) //swap
        {
            weapon_name = "Swap";
            actual_weapon = weapons[17];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[17];
            danoBase = 0;
            disparo_tiempo = 5;
        }

        else if (weapon == 17) //surrender
        {
            weapon_name = "Surrender";
            actual_weapon = weapons[17];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[17];
            danoBase = 0;
            disparo_tiempo = 3;
        }

        else if (weapon == 18) //air_strike
        {
            weapon_name = "Air_strike";
            actual_weapon = weapons[18];
            gameObject.transform.Find("weapon").gameObject.GetComponent<SpriteRenderer>().sprite = actual_weapon;
            actual_ammo = ammo[18];
            danoBase = 15;
            disparo_tiempo = 10;
            if (Input.GetMouseButton(0) && canShoot)
            {
                Vector3 ubicacion_misil = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PlayerPrefs.SetFloat("pos_misil", ubicacion_misil.x);
                PlayerPrefs.SetString("tipo_ataque", "air_strike");

                GameObject av = Instantiate(avion) as GameObject;
                disparo = true;
                canShoot = false;

                GameObject ex = Instantiate(ammo[18]) as GameObject;
                ex.transform.position = new Vector3(ubicacion_misil.x, ubicacion_misil.y, 0);

            }
        }


        //disparar
        time = time + Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && fuerza < 10 && canShoot)
        {
            if (weapon_name != "Jetpack")
            {
                time = 0f;
                fuerza += 5f * Time.deltaTime;
                gameObject.GetComponent<Transform>().Find("weapon").gameObject.GetComponent<Transform>().Find("Throw Indicator").gameObject.GetComponent<Transform>().localScale = new Vector3(0.25f, (fuerza * 0.25f) / 10, 0);
            }
        }
        if ((Input.GetKeyUp(KeyCode.Space) && canShoot) || uzi || pistol)
        {
            

            //segun arma
            if (weapon_name == "Jetpack")
            {
                control_jetpack = control_jetpack * -1;
                if (control_jetpack == 1)
                {
                    gameObject.GetComponent<Animator>().SetBool("Jetpack", true);  
                }
                if (control_jetpack == -1)
                {
                    gameObject.GetComponent<Animator>().SetBool("Jetpack", false);
                }

            }
            else
            {
                disparo = true;
            }

            if (weapon_name == "Proximity_mine")
            {
                disparo_mina();
                canShoot = false;
                
            }

            if (weapon_name == "Bazooka")
            {
                disparoBazooka();
                canShoot = false;
                
            }

            if (weapon_name == "Grenade")
            {
                disparoGranada();
                canShoot = false;
                
            }
            if (weapon_name == "Holy_grenade")
            {
                disparohGranada();
                canShoot = false;
                
            }
            if (weapon_name == "Banana")
            {
                disparoBanana();
                canShoot = false;
                
            }
            if (weapon_name == "Sheep")
            {
                disparoSheep();
                canShoot = false;
                
            }
            if (weapon_name == "Uzi" || weapon_name == "Pistol" || weapon_name == "Shotgun" || weapon_name == "Awp")
            {
                if (weapon_name == "Awp" || weapon_name == "Shotgun")
                {
                    sonidoD.Play();
                    disparoBalas();
                    canShoot = false;
                    
                }
            
                if (weapon_name == "Uzi")
                {
                    uzi = true;
                    if (time > 0f && time < 0.5f && contadorBalas == 0)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 1;
                    }
                    if (time > 0.5f && time < 1f && contadorBalas == 1)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 2;
                    }
                    if (time > 1f && time < 1.5f && contadorBalas == 2)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 3;
                    }
                    if (time > 1.5f && time < 2f && contadorBalas == 3)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 4;
                    }
                    if (time > 2f && time < 2.5f && contadorBalas == 4)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 5;
                    }
                    if (time > 2.5f && time < 3f && contadorBalas == 5)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 6;
                    }
                    if (time > 3f && time < 3.5f && contadorBalas == 6)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 7;
                    }
                    if (time > 3.5f && time < 4f && contadorBalas == 7)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 8;
                    }
                    if (time > 4f && time < 4.5f && contadorBalas == 8)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 9;
                    }
                    if (time > 4.5f && time < 5f && contadorBalas == 9)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        uzi = false;
                        contadorBalas = 0;
                        canShoot = false;
                        
                    }
                }
                if (weapon_name == "Pistol")
                {
                    pistol = true;
                    if (time > 0f && time < 0.5f && contadorBalas == 0)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 1;
                    }
                    if (time > 1f && time < 1.5f && contadorBalas == 1)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 2;
                    }
                    if (time > 2f && time < 2.5f && contadorBalas == 2)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 3;
                    }
                    if (time > 3f && time < 3.5f && contadorBalas == 3)
                    {
                        sonidoD.Play();
                        disparoBalas();
                        contadorBalas = 0;
                        pistol = false;
                        canShoot = false;
                        
                    }
                }
            }
            //-------------------------------------------------------
            fuerza = 0;
            gameObject.GetComponent<Transform>().Find("weapon").gameObject.GetComponent<Transform>().Find("Throw Indicator").gameObject.GetComponent<Transform>().localScale = new Vector3(0.25f, 0, 0);
            
        }
    }

    private void disparo_mina() 
    {
        angulo = Convert.ToSingle(gameObject.GetComponent<Worm_Controller>().mira.GetComponent<Apuntar>().getAngulo());
        Vector3 ShootDir = new Vector3(Mathf.Cos(angulo), Mathf.Sin(angulo), 0);
        GameObject amm = Instantiate(actual_ammo, (this.gameObject.GetComponent<Transform>().position + (ShootDir * largo_arma)), this.gameObject.GetComponent<Transform>().rotation);
        ShootDir = new Vector3(ShootDir.x, ShootDir.y, 0);
        amm.GetComponent<Mine_controller>().Setup(ShootDir, 0, danoBase);

    }
    private void disparoBalas()
    {
        angulo = Convert.ToSingle(gameObject.GetComponent<Worm_Controller>().mira.GetComponent<Apuntar>().getAngulo());
        Vector3 ShootDir = new Vector3(Mathf.Cos(angulo), Mathf.Sin(angulo), 0);
        GameObject amm = Instantiate(actual_ammo, (this.gameObject.GetComponent<Transform>().position + (ShootDir * largo_arma)), this.gameObject.GetComponent<Transform>().rotation);
        ShootDir = new Vector3(ShootDir.x, ShootDir.y, 0);
        amm.GetComponent<Bullet_controller>().Setup(ShootDir, 10, danoBase);
    }

    private void disparoBazooka()
    {
        angulo = Convert.ToSingle(gameObject.GetComponent<Worm_Controller>().mira.GetComponent<Apuntar>().getAngulo());
        Vector3 ShootDir = new Vector3(Mathf.Cos(angulo), Mathf.Sin(angulo), 0);
        GameObject amm = Instantiate(actual_ammo, (this.gameObject.GetComponent<Transform>().position + (ShootDir * largo_arma)), this.gameObject.GetComponent<Transform>().rotation);
        ShootDir = new Vector3(ShootDir.x, ShootDir.y, 0);
        amm.GetComponent<Misil_controller>().Setup(ShootDir, fuerza, danoBase);
    }
    private void disparohGranada()
    {
        angulo = Convert.ToSingle(gameObject.GetComponent<Worm_Controller>().mira.GetComponent<Apuntar>().getAngulo());
        Vector3 ShootDir = new Vector3(Mathf.Cos(angulo), Mathf.Sin(angulo), 0);
        GameObject amm = Instantiate(actual_ammo, (this.gameObject.GetComponent<Transform>().position + (ShootDir * largo_arma)), this.gameObject.GetComponent<Transform>().rotation);
        ShootDir = new Vector3(ShootDir.x, ShootDir.y, 0);
        amm.GetComponent<hgrenade_controller>().Setup(ShootDir, fuerza, danoBase);
    }
    private void disparoGranada()
    {
        angulo = Convert.ToSingle(gameObject.GetComponent<Worm_Controller>().mira.GetComponent<Apuntar>().getAngulo());
        Vector3 ShootDir = new Vector3(Mathf.Cos(angulo), Mathf.Sin(angulo), 0);
        GameObject amm = Instantiate(actual_ammo, (this.gameObject.GetComponent<Transform>().position + (ShootDir * largo_arma)), this.gameObject.GetComponent<Transform>().rotation);
        ShootDir = new Vector3(ShootDir.x, ShootDir.y, 0);
        amm.GetComponent<Grenade_controller>().Setup(ShootDir, fuerza, danoBase);
    }
    private void disparoSheep()
    {
        angulo = Convert.ToSingle(gameObject.GetComponent<Worm_Controller>().mira.GetComponent<Apuntar>().getAngulo());
        Vector3 ShootDir = new Vector3(Mathf.Cos(angulo), Mathf.Sin(angulo), 0);
        GameObject amm = Instantiate(actual_ammo, (this.gameObject.GetComponent<Transform>().position + (ShootDir * largo_arma)), this.gameObject.GetComponent<Transform>().rotation);
        ShootDir = new Vector3(ShootDir.x, ShootDir.y, 0);
        amm.GetComponent<sheep_controller>().Setup(ShootDir, 1, danoBase);
    }
    private void disparoBanana()
    {
        angulo = Convert.ToSingle(gameObject.GetComponent<Worm_Controller>().mira.GetComponent<Apuntar>().getAngulo());
        Vector3 ShootDir = new Vector3(Mathf.Cos(angulo), Mathf.Sin(angulo), 0);
        GameObject amm = Instantiate(actual_ammo, (this.gameObject.GetComponent<Transform>().position + (ShootDir * largo_arma)), this.gameObject.GetComponent<Transform>().rotation);
        ShootDir = new Vector3(ShootDir.x, ShootDir.y, 0);
        amm.GetComponent<Banana_controller>().Setup(ShootDir, fuerza, danoBase);
    }

}
