using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoise : MonoBehaviour {
    private int existence;
    private Animator anim;
    private bool canMove, makeNoise;
	// Use this for initialization
	void Start () {
        existence = 0;
        anim = GetComponent<Animator>();
        makeNoise = false;
        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        MakeNoise();
	}

    void MakeNoise()
    {
        existence++;
        if (existence >= 35)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy patrolEnemy;
        int distance = 0;
        if (collision.CompareTag("Enemy") && collision.GetComponent<Enemy>() != null)
        {
            patrolEnemy = collision.GetComponent<Enemy>();
            if (transform.position.x > patrolEnemy.transform.position.x)
                distance = 1;
            if (transform.position.x < patrolEnemy.transform.position.x)
                distance = 2;
            if (transform.position.y > patrolEnemy.transform.position.y)
                distance = 3;
            if (transform.position.y < patrolEnemy.transform.position.y)
                distance = 4;
            patrolEnemy.DetectNoise(distance);
        }
    }
}
