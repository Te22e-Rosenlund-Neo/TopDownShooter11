using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class BulletScripts : MonoBehaviour
{
   [SerializeField] string Doortag;
    [SerializeField] string BorderTag;
    [SerializeField]  float ShotSpeed = 9;
    [SerializeField] string EnemyChasetag;
    [SerializeField] string EnemyRangetag;
    [SerializeField] string Bosstag;
    void Awake(){

        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Direction = new Vector2( MousePosition.x - transform.position.x, MousePosition.y - transform.position.y);
        transform.up = Direction;
        


    }

    void Update(){
        

        Vector2 ShotMove = new Vector2(0, ShotSpeed) * Time.deltaTime;
        transform.Translate(ShotMove);

    }





    private void OnTriggerEnter2D(Collider2D collider) {

        if(BorderTag == collider.tag || Doortag == collider.tag){
            Destroy(this.gameObject);
        }
        if(collider.tag == EnemyChasetag){
            collider.GetComponent<EnemyChaseScript>().Ehealth --;
            Destroy(this.gameObject);
        }
        if(collider.tag == EnemyRangetag){
            collider.GetComponent<RangeEnemyScript>().Ehealth --;
            Destroy(this.gameObject);
        }
        if(collider.tag == Bosstag){
            collider.GetComponent<BossScript>().Health --;
            Destroy(this.gameObject);
        }
    }


}
