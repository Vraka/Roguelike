using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    public bool[] doors;
    // 0 --> bottom door
    // 1 --> top door
    // 2 --> left door
    // 3 --> right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

	// Use this for initialization
	void Start () {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        //Invoke("Spawn", 0.2f);
        templates.roomSpawns.Add(this);
	}

    public void InvokeSpawn()
    {
        Invoke("Spawn", 0.1f);
    }
	
	void Spawn () {
		if(!spawned)
        {
            if (templates.finalSpawns.Count < 15)
            {
                if (doors[0])
                {
                    rand = Random.Range(0, templates.downSpawns.Length);
                    Instantiate(templates.downSpawns[rand], transform.position, Quaternion.identity);
                }
                if (doors[1])
                {
                    rand = Random.Range(0, templates.upSpawns.Length);
                    Instantiate(templates.upSpawns[rand], transform.position, Quaternion.identity);
                }
                if (doors[2])
                {
                    rand = Random.Range(0, templates.rightSpawns.Length);
                    Instantiate(templates.rightSpawns[rand], transform.position, Quaternion.identity);
                }
                if (doors[3])
                {
                    rand = Random.Range(0, templates.leftSpawns.Length);
                    Instantiate(templates.leftSpawns[rand], transform.position, Quaternion.identity);
                }
                
            } else
            {
                for(int i = 0; i < doors.Length; i++)
                {
                    if(doors[i])
                    {
                        Instantiate(getEndRoom(i), transform.position, Quaternion.identity);
                    }
                }
            }
            templates.finalSpawns.Add(this);
            spawned = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true) || other.CompareTag("EntrySpawn"))
        {
            if(templates == null)
            {
                templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
            }
            if(templates.roomSpawns.Contains(this))
            {
                templates.roomSpawns.Remove(this);
            }
            if (templates.finalSpawns.Contains(this))
            {
                templates.finalSpawns.Remove(this);
            }
            if (other.CompareTag("SpawnPoint"))
            {
                RoomSpawner otherspawner = other.GetComponent<RoomSpawner>();
                for(int i = 0; i < doors.Length; i++)
                {
                    if(doors[i] && !otherspawner.doors[i])
                    {
                        otherspawner.doors[i] = true;
                        Instantiate(getEndRoom(i), otherspawner.transform.position, Quaternion.identity);
                    }
                }
            }
            Debug.Log("Enter " + transform.position.x + ", " + transform.position.y + ": " + doors[0] + "," + doors[1] + "," + doors[2] + "," + doors[3]);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true) || other.CompareTag("EntrySpawn"))
        {
            if (templates == null)
            {
                templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
            }
            if (templates.roomSpawns.Contains(this))
            {
                templates.roomSpawns.Remove(this);
            }
            if (templates.finalSpawns.Contains(this))
            {
                templates.finalSpawns.Remove(this);
            }
            if (other.CompareTag("SpawnPoint"))
            {
                RoomSpawner otherspawner = other.GetComponent<RoomSpawner>();
                for (int i = 0; i < doors.Length; i++)
                {
                    if (doors[i] && !otherspawner.doors[i])
                    {
                        otherspawner.doors[i] = true;
                        Instantiate(getEndRoom(i), otherspawner.transform.position, Quaternion.identity);
                    }
                }
            }
            Debug.Log(transform.position.x + ", " + transform.position.y + ": " + doors[0] + "," + doors[1] + "," + doors[2] + "," + doors[3]);
            Destroy(gameObject);
        }
    }

    private GameObject getEndRoom(int i)
    {
        switch(i)
        {
            case 0:
                return templates.downEnd;
            case 1:
                return templates.upEnd;
            case 2:
                return templates.rightEnd;
            default:
                return templates.leftEnd;
        }
    }
}
