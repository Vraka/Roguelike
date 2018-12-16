using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string name;
    public string desc;
    private PickupItemUI ui;
    public int type;

	// Use this for initialization
	void Start () {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<PickupItemUI>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ui.pickupItem(name, desc);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>().passive(type);
            Destroy(gameObject);
        }
    }
}
