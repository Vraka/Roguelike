using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour {

    private TestSpell spell;
    public GameObject[] projectiles;

	// Use this for initialization
	void Start () {
        spell = gameObject.GetComponent<TestSpell>();
	}
	
	public void passive(int type)
    {
        spell.projectile = projectiles[type];
    }
}
