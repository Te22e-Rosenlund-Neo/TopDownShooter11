using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    [SerializeField] string Doortag;
    [SerializeField] string Bordertag;
    [SerializeField] string Playertag;
    GameObject Player;

    public float ShotSpeed = 9;
    void Awake(){
        Player = GameObject.FindWithTag("Player");
        Vector2 Direction = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
        transform.up = Direction;


    }
    void Update()
    {
        Vector2 ShotMove = new Vector2(0, ShotSpeed) * Time.deltaTime;
        transform.Translate(ShotMove);

    }

 private void OnTriggerEnter2D(Collider2D collider) {

        if(Bordertag == collider.tag || Doortag == collider.tag){
            Destroy(this.gameObject);
        }
        if(Playertag == collider.tag){
            Player.GetComponent<PlayerMove>().PlayerHealth --;
            Destroy(this.gameObject);
        }
    }





}
