using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    
    int TimeToStayAlive;
    [SerializeField] string EnemyChasetag;
    [SerializeField] string EnemyRangetag;
    [SerializeField] string EnemySpawnertag;
    [SerializeField] string Playertag;
  private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag != EnemyChasetag && other.tag != EnemyRangetag && other.tag != EnemySpawnertag && other.tag != Playertag){
        Destroy(other.gameObject);
    }
    }
  

    void Update(){

        if(TimeToStayAlive >= 270){
            Destroy(gameObject);
        }
        TimeToStayAlive++;
    }










}
