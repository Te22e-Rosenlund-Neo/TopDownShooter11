using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] BottomRooms;
    public GameObject[] TopRooms;
    public GameObject[] LeftRooms;
    public GameObject[] RightRooms;

    public GameObject[] EnemyTypes;

    public GameObject RoomBlockage;

    public List<GameObject> rooms;
    public float WaitTime = 270;
    private bool spawnedBoss;
    public GameObject boss;

    private bool HasSpawnedBossRoom = false;
    public GameObject BossEnterRoom;

    void Update() {
    
        if(WaitTime == 270 && HasSpawnedBossRoom == false){
            Vector2 LastRoom = new Vector2(rooms[rooms.Count-1].transform.position.x, rooms[rooms.Count-1].transform.position.y);
            Destroy(rooms[rooms.Count-1]);
            BossEnterRoom.transform.position = LastRoom;
        Instantiate(BossEnterRoom);
        HasSpawnedBossRoom = true;
        }else{
            WaitTime ++;
        }


    }




}
