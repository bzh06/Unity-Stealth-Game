using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy;
        if(collision.CompareTag("Enemy") && collision.GetComponent<Enemy>() != null)
        {
            enemy = collision.GetComponent<Enemy>();
            enemy.DetectTrap();
            Destroy(gameObject);
        }
    }
}
