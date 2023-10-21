using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] Sprite spawn;
    [SerializeField] Sprite spawn2;
    [SerializeField] Sprite spawn3;


    float Delay = 4;
    
    // Update is called once per frame
    void Update()
    {
        Delay -= Time.deltaTime;
        if(Delay > 2 && Delay <= 3){
            GetComponent<SpriteRenderer>().sprite = spawn;
        }else if(Delay > 1 && Delay <= 2){
            GetComponent<SpriteRenderer>().sprite = spawn2;
        }else if(Delay <= 1){
            GetComponent<SpriteRenderer>().sprite = spawn3;
        }




    }
}
