using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public int type;
    public float time;
    private PlayerMovement pm;
    private float speed;

    void Start()
    {
        time = 2f;
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            pm = col.gameObject.GetComponent<PlayerMovement>();
            switch(type)
            {
                case 0:
                    paralyze();
                    break;
                case 1:
                    slow();
                    break;
                default:
                    paralyze();
                    break;
            }
        }
    }

    private IEnumerator paralyze()
    {
        pm.canMove = false;
        yield return new WaitForSeconds(time);
        pm.canMove = true;
        Destroy(gameObject);
    }

    private IEnumerator slow()
    {
        speed = pm.speed;
        pm.speed = speed/2f;
        yield return new WaitForSeconds(time);
        pm.speed = speed;
        Destroy(gameObject);
    }
}
