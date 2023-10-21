using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowProjScript : MonoBehaviour
{
    GameObject Player;
    [SerializeField] string Playertag;
    [SerializeField] string Bolttag;
    [SerializeField] string Bordertag;
    public int Projspeed = 2;
    [SerializeField] Sprite Follow;
    float Delay = 2.5f;

    void Start()
    {


        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Delay > 0)
        {
            Vector2 ShotMove = new Vector2(0, Projspeed) * Time.deltaTime;
            transform.Translate(ShotMove);
            Delay -= Time.deltaTime;
        }
        else 
        {
            GetComponent<SpriteRenderer>().sprite = Follow;

            Vector2 Direction = new Vector2(transform.position.x - Player.transform.position.x, transform.position.y - Player.transform.position.y);
            transform.up = Direction;

            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Projspeed * Time.deltaTime);
        }





    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == Playertag)
        {
            other.GetComponent<PlayerMove>().PlayerHealth -= 2;
            Destroy(this.gameObject);
        }
        if (other.tag == Bordertag)
        {
            Destroy(this.gameObject);
        }

        if (other.tag == Bolttag)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }

}
