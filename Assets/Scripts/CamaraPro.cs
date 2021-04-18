using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CamaraPro : MonoBehaviour
{
    public GameObject player;
    public Vector2 minCamPos, maxCampPos;
    public float smoothTime;
    private float contAux;

    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("s"))
        {
            contAux = contAux + Time.deltaTime;
            if (contAux >= 0.4f)
            {
                if (player.GetComponent<SpriteRenderer>().flipX)
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x - 10f, ref velocity.x, smoothTime);
                    float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y + 0f, ref velocity.y, smoothTime - .2f);

                    transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCampPos.x), Mathf.Clamp(posY, minCamPos.y, maxCampPos.y), transform.position.z);
                }
                else
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x + 10f, ref velocity.x, smoothTime);
                    float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y + 0f, ref velocity.y, smoothTime - .2f);

                    transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCampPos.x), Mathf.Clamp(posY, minCamPos.y, maxCampPos.y), transform.position.z);
                }
            }
            else
            {
                if (player.GetComponent<SpriteRenderer>().flipX)
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x - 10f, ref velocity.x, smoothTime);
                    float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y + 8f, ref velocity.y, smoothTime - .2f);

                    transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCampPos.x), Mathf.Clamp(posY, minCamPos.y, maxCampPos.y), transform.position.z);
                }
                else
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x + 10f, ref velocity.x, smoothTime);
                    float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y + 8f, ref velocity.y, smoothTime - .2f);

                    transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCampPos.x), Mathf.Clamp(posY, minCamPos.y, maxCampPos.y), transform.position.z);
                }
            }
        }

        else
        {
            contAux = 0;
            if (player.GetComponent<SpriteRenderer>().flipX)
            {
                float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x - 10f, ref velocity.x, smoothTime);
                float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y + 8f, ref velocity.y, smoothTime - .2f);

                transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCampPos.x), Mathf.Clamp(posY, minCamPos.y, maxCampPos.y), transform.position.z);
            }
            else
            {
                float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x + 10f, ref velocity.x, smoothTime);
                float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y + 8f, ref velocity.y, smoothTime - .2f);

                transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCampPos.x), Mathf.Clamp(posY, minCamPos.y, maxCampPos.y), transform.position.z);
            }
        }
        
        
    }
}
