using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomSpawner : MonoBehaviour
{
    
    public int OpeningDirection;      // every spawn point has a value to where they can have another room
// 1 = bottom door
// 2 = top door
// 3 = left door
// 4 = right door

    RoomTemplate templates;
    [SerializeField] string SpawnPointtag;
    bool HasSpawned = false;
    int random;
    void Awake() {
       
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();    
        Invoke("Spawn", 0.1f);
    }



    void Spawn(){
if(HasSpawned == false){
        if(OpeningDirection == 1){
            //needs bottom door room
            random = Random.Range(0, templates.BottomRooms.Length);
            Instantiate(templates.BottomRooms[random], transform.position, Quaternion.identity);
        }
        else if(OpeningDirection == 2){
            random = Random.Range(0, templates.TopRooms.Length);
            Instantiate(templates.TopRooms[random], transform.position, Quaternion.identity);
            //needs top door room
        }
        else if(OpeningDirection == 3){
            random = Random.Range(0, templates.LeftRooms.Length);
            Instantiate(templates.LeftRooms[random], transform.position, Quaternion.identity);
            //needs left door room
        }
        else if(OpeningDirection == 4){
            random = Random.Range(0, templates.RightRooms.Length);
            Instantiate(templates.RightRooms[random], transform.position, Quaternion.identity);
            //needs right door room
        }
        HasSpawned = true;
}




    }



void OnTriggerEnter2D(Collider2D other){
if(other.tag == SpawnPointtag){
if(other.GetComponent<RoomSpawner>() == true    &&      other.GetComponent<RoomSpawner>().OpeningDirection == 0){
    Destroy(gameObject);
}else{
    if(other.GetComponent<RoomSpawner>() == true && other.GetComponent<RoomSpawner>().HasSpawned == false && HasSpawned == false && transform.position.x != 0 && transform.position.y != 0){
        Instantiate(templates.RoomBlockage, transform.position, Quaternion.identity);
    }
    if(OpeningDirection!=0){
    Destroy(gameObject);
    }
}

}





}
}

