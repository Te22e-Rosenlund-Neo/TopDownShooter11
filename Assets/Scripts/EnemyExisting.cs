using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyExisting : MonoBehaviour
{
        RoomTemplate templates;
        public int EnemyAmount;
        [SerializeField] bool CanSpawnEnemies;
        [SerializeField] string Doortag;
    void Start(){
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();  

if(CanSpawnEnemies == true){
        for(int i = 0; i<UnityEngine.Random.Range(1,5); i++){
            SpawnEnemies();
            EnemyAmount++;
        }
  }
}
void SpawnEnemies(){
    Vector2 Eposition = new Vector2(transform.position.x - UnityEngine.Random.Range(-5, 5), transform.position.y - UnityEngine.Random.Range(-5,5));
    Instantiate(templates.EnemyTypes[UnityEngine.Random.Range(0,templates.EnemyTypes.Length)], Eposition, Quaternion.identity, transform);
    


}


    private void OnTriggerStay2D(Collider2D other){
        if(EnemyAmount <= 0 && other.tag == Doortag){
            Destroy(other.gameObject);

        }
        


    }

}