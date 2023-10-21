using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RangeEnemyScript : MonoBehaviour
{
    public Slider healthbar;
    public int Ehealth = 5;
     [SerializeField] GameObject Player;
     [SerializeField] GameObject enemyProjectile;
    public float TimeBetweenShots = 0.6f;
    public float TimeSinceLastShot;
    void Start(){
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
         if(Vector2.Distance(transform.position, Player.transform.position) < 15){ 
        Vector2 Direction = new Vector2(transform.position.x - Player.transform.position.x, transform.position.y - Player.transform.position.y);
        transform.up = Direction;
        }
        
        if(Ehealth <= 0){
            transform.parent.GetComponent<EnemyExisting>().EnemyAmount --;
            Destroy(gameObject);
        }


    if(TimeBetweenShots<TimeSinceLastShot && Vector2.Distance(transform.position, Player.transform.position) < 10){
        Instantiate(enemyProjectile,transform.position, Quaternion.identity);
        TimeSinceLastShot = 0;
    }else{
        TimeSinceLastShot += Time.deltaTime;
    } 







    healthbar.value = Ehealth;
    }
}
