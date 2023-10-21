using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineProjScript : MonoBehaviour
{

    [SerializeField] GameObject Deathzone;
    [SerializeField] string playertag;
    float TimeDelayUntilDeath = 4f;
    bool takeDamage = false;
    void Awake(){
        Instantiate(Deathzone,transform.position,Quaternion.identity, transform);
    }

    void Update()
    {
        TimeDelayUntilDeath -= Time.deltaTime;
        if(TimeDelayUntilDeath <= 0.3){
            takeDamage = true;
        }
        if(TimeDelayUntilDeath <= 0){
            Destroy(gameObject);
        }




    }

 private void OnTriggerStay2D(Collider2D other) {
    if(other.tag == playertag && takeDamage == true){
        other.GetComponent<PlayerMove>().PlayerHealth -= 100;
    }

}




}
