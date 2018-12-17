using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

    public GameObject[] upSpawns;
    public GameObject[] downSpawns;
    public GameObject[] leftSpawns;
    public GameObject[] rightSpawns;

    public GameObject[] upRooms;
    public GameObject[] downRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject upEnd;
    public GameObject downEnd;
    public GameObject leftEnd;
    public GameObject rightEnd;

    public GameObject closed;

    public List<RoomInfo> rooms;
    public List<RoomSpawner> roomSpawns;
    public List<RoomSpawner> finalSpawns;

    public float waitTime = 2;
    private bool spawnedRooms = false;
    private bool spawnedBoss = false;
    public GameObject boss;

    void Update()
    {
        if (roomSpawns.Count > 0)
        {
            Invoke("Spawn", 0.1f);
        }
        if (waitTime <= 0 && roomSpawns.Count == 0 && !spawnedRooms)
        {
            foreach(RoomSpawner spawner in finalSpawns)
            {
                
                string prefabname = "";
                if(spawner.doors[1])
                {
                    prefabname += "U";
                }
                if (spawner.doors[0])
                {
                    prefabname += "D";
                }
                if (spawner.doors[3])
                {
                    prefabname += "L";
                }
                if (spawner.doors[2])
                {
                    prefabname += "R";
                }

                Instantiate(Resources.Load("Rooms/" + prefabname), spawner.gameObject.transform.position, Quaternion.identity);
            }
            spawnedRooms = true;
        } else
        {
            waitTime -= Time.deltaTime;
        }

        if (spawnedRooms && !spawnedBoss && rooms.Count == finalSpawns.Count + 1) 
        {
            for(int i = rooms.Count - 1; i >= 0; i--)
            {
                if(rooms[i].gameObject.transform.parent.name.Length == 8)
                {
                    //Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
                    rooms[rooms.Count - 1].type = "boss";
                    spawnedBoss = true;
                    break;
                }
            }
        }

    }

    void Spawn()
    {
        if(roomSpawns.Count == 0)
        {
            return;
        }
        roomSpawns[0].InvokeSpawn();
        roomSpawns.Remove(roomSpawns[0]);
    }

}
