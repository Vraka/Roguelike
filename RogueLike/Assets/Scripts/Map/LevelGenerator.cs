using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject[] rooms;

    private int direction;
    public float moveAmount = 10f;

	void Start () {
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 5);
	}
	
    private void Move()
    {
        if(direction == 1) // RIGHT
        {
            Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
            transform.position = newPos;
        } else if (direction == 2) // LEFT
        {
            Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
            transform.position = newPos;
        }
    }
}
