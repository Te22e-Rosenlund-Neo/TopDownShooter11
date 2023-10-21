using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class NormalProjScript : MonoBehaviour
{
[SerializeField] string Playertag;
[SerializeField] string Bordertag;
GameObject boss;
int Projspeed;

    // Update is called once per frame
    void Awake(){
        boss = GameObject.FindWithTag("Boss");
        Projspeed = boss.GetComponent<BossScript>().Attack1ProjSpeed;
    }


    void Update()
    {
        Vector2 ShotMove = new Vector2(0, Projspeed) * Time.deltaTime;
        transform.Translate(ShotMove);        



    }


 void OnTriggerEnter2D(Collider2D other) {
    
    if(other.tag == Playertag){
        other.GetComponent<PlayerMove>().PlayerHealth --;
        Destroy(this.gameObject);
    }
    if(other.tag == Bordertag){
        Destroy(this.gameObject);
    }

}



}
