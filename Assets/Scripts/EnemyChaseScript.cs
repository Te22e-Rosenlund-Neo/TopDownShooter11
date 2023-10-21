using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyChaseScript : MonoBehaviour
{
    [SerializeField] string playertag;
    GameObject Player;
    public int MoveSpeed = 8;
   public int Ehealth = 5;
    float timeBetweenAttacks = 0f;
     public Slider healthbar;
    void Start(){
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
//if the player is closer than 10 units to the enemy, the enemy looks towards the player ( vector2 direction) and starts to walk towards the player (Vector2  movetowards)
        if(Vector2.Distance(transform.position, Player.transform.position) < 10){ 
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, MoveSpeed*Time.deltaTime);

        Vector2 Direction = new Vector2(transform.position.x - Player.transform.position.x, transform.position.y - Player.transform.position.y);
        transform.up = Direction;
        }
    
        if(Ehealth <= 0){
            transform.parent.GetComponent<EnemyExisting>().EnemyAmount --;
            Destroy(gameObject);
        }


        timeBetweenAttacks -= Time.deltaTime;
        
        healthbar.value = Ehealth;
    }



  private void OnCollisionStay2D(Collision2D other) {
    if(timeBetweenAttacks <= 0 && other.gameObject.tag == playertag){
            other.gameObject.GetComponent<PlayerMove>().PlayerHealth --;
            timeBetweenAttacks = 0.8f;
        }
  }



}
