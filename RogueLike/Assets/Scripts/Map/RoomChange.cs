using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour {

    public RoomInfo room;
    public GameObject doors;
    public int xMove;
    public int yMove;
    public int playerSpeed = 2;
    public int cameraSpeed;
    private Vector2 playerMoveTo;
    private Vector3 camMoveTo;
    private bool moving;
    private GameObject player;
    private GameObject cam;
    private PlayerMovement playerMove;

	// Use this for initialization
	void Start () {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(moving)
        {
            float step = playerSpeed * Time.deltaTime;
            float camstep = cameraSpeed * Time.deltaTime;
            Vector2 newPos = Vector2.MoveTowards(player.transform.position, playerMoveTo, step);
            if(Vector2.Distance(player.transform.position, playerMoveTo) == 0 && Vector3.Distance(cam.transform.position, camMoveTo) == 0)
            {
                moving = false;
                playerMove.canMove = true;
            } else
            {
                player.transform.position = newPos;
                cam.transform.position = Vector3.MoveTowards(cam.transform.position, camMoveTo, camstep);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = col.gameObject;
            playerMove = (PlayerMovement)col.gameObject.GetComponent<PlayerMovement>();
            if (room.cleared && playerMove.canMove)
            {
                playerMove.canMove = false;
                playerMoveTo = (Vector2)transform.position + new Vector2(xMove * 1.25f, yMove * 1.25f);
                cam = GameObject.FindGameObjectWithTag("MainCamera");
                if (xMove > 0)
                {
                    camMoveTo = (Vector3)cam.transform.position + new Vector3(15, 0, 0);
                }
                else if (xMove < 0)
                {
                    camMoveTo = (Vector3)cam.transform.position + new Vector3(-15, 0, 0);
                }
                else if (yMove > 0)
                {
                    camMoveTo = (Vector3)cam.transform.position + new Vector3(0, 10.5f, 0);
                }
                else if (yMove < 0)
                {
                    camMoveTo = (Vector3)cam.transform.position + new Vector3(0, -10.5f, 0);
                }
                moving = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !room.cleared)
        {
            room.Enter();
            doors.SetActive(true);
        }
    }
}
