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
    private bool spawnedBoss = false;
    public GameObject boss;

    void Update()
    {
        if (roomSpawns.Count > 0)
        {
            Invoke("Spawn", 0.1f);
        }
        if (waitTime <= 0 && roomSpawns.Count == 0 && !spawnedBoss)
        {
            foreach(RoomSpawner spawner in finalSpawns)
            {
                Instantiate(boss, finalSpawns[finalSpawns.Count - 1].transform.position, Quaternion.identity);
                spawnedBoss = true;
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
            spawnedBoss = true;
            waitTime = 1f;
        } else
        {
            waitTime -= Time.deltaTime;
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
