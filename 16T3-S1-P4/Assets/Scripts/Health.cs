using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    int health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetHealth() {
        return health;
    }

    void SetHealth() {

    }

    void TakeDamage(int dmg) {
        health -= dmg;
    }
}
