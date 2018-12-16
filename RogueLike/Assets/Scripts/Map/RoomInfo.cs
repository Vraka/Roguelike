using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour {

    private RoomTemplates templates;

    public bool cleared = false;
    public SpawnEnemy spawner;
    public GameObject doors;
    public int type;
    public bool[] openings;

	// Use this for initialization
	void Start () {
        spawner = gameObject.GetComponent<SpawnEnemy>();
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this);
    }
	
	public void Enter()
    {
        spawner.Spawn(this);
    }

    public void Clear()
    {
        cleared = true;
        doors.SetActive(false);
    }
}
