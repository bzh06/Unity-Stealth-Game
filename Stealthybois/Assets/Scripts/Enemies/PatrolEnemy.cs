using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy {
    public float walkSpeed;
    private Animator anim;
    public List<Vector3> coordinates;
    public List<Vector2> directionals;
    private int index, noiseTimer, noiseDistance, trapTimer;
    public GameObject alert, nearView;
    private bool noiseDetected, trapDetected;
    public float viewDistance;
    public LayerMask layerMask;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        transform.position = coordinates[0];
        index = 0;
        alert.SetActive(false);
        nearView.SetActive(true);
        Time.timeScale = 1f;
        noiseTimer = 0;
        noiseDistance = -1;
        trapTimer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!noiseDetected && !trapDetected)
        {
            anim.SetFloat("MoveX", directionals[index].x);
            anim.SetFloat("MoveY", directionals[index].y);
        }
        if(GameInfo.PlayerDetected == true)
        {
            Time.timeScale = 0;
            alert.SetActive(true);
        } else if (GameInfo.PlayerDetected == false)
        {
            alert.SetActive(false);
        }
        if (index < coordinates.Count - 1 && !noiseDetected && !trapDetected)
        {
            transform.position = Vector3.MoveTowards(transform.position, coordinates[index + 1], walkSpeed);
            if (transform.position == coordinates[index + 1])
            {
                index++;
            }
        }
        else if (index >= coordinates.Count - 1 &&!noiseDetected && !trapDetected)
        {
            transform.position = Vector3.MoveTowards(transform.position, coordinates[0], walkSpeed);
            anim.SetFloat("MoveX", directionals[index].x);
            anim.SetFloat("MoveY", directionals[index].y);
            if (transform.position == coordinates[0])
            {
                index = 0;
            }

        }

    }

    private void Update()
    {
        if (noiseDetected && !trapDetected)
        {
            NoiseResponse();
        }
        if(trapDetected && !noiseDetected)
        {
            TrapResponse();
        }
        if(!noiseDetected && !trapDetected)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        RaycastHit2D hit = new RaycastHit2D();
        if (anim.GetFloat("MoveX") > 0)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, viewDistance, layerMask);
            Debug.DrawRay(transform.position, Vector2.right*viewDistance, Color.red);
        }
        if (anim.GetFloat("MoveX") < 0)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, viewDistance, layerMask);
            Debug.DrawRay(transform.position, Vector2.left*viewDistance, Color.red);
        }
        if (anim.GetFloat("MoveY") > 0)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, viewDistance, layerMask);
            Debug.DrawRay(transform.position, Vector2.up*viewDistance, Color.red);
        }
        if (anim.GetFloat("MoveY") < 0)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, viewDistance, layerMask);
            Debug.DrawRay(transform.position, Vector2.down*viewDistance, Color.red);
        }
        if (hit.collider)
        {
            if (hit.collider.CompareTag("Player"))
                GameInfo.PlayerDetected = true;
        }

    }

    void NoiseResponse()
    {
        noiseTimer++;
        nearView.SetActive(false);
        transform.position = transform.position;
        anim.SetFloat("MoveX", 0);
        anim.SetFloat("MoveY", 0);
        RaycastHit2D hit = new RaycastHit2D();
        if(noiseTimer >= 5)
            anim.SetInteger("IdleState", noiseDistance);
        if (noiseTimer > 15)
        {
            if (noiseDistance == 1)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.right, viewDistance, layerMask);
                Debug.DrawRay(transform.position, Vector2.right*viewDistance, Color.red);
            }
            if (noiseDistance == 2)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.left, viewDistance, layerMask);
                Debug.DrawRay(transform.position, Vector2.left*viewDistance, Color.red);
            }
            if (noiseDistance == 4)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.down, viewDistance, layerMask);
                Debug.DrawRay(transform.position, Vector2.down*viewDistance, Color.red);
            }
            if (noiseDistance == 3)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.up, viewDistance, layerMask);
                Debug.DrawRay(transform.position, Vector2.up*viewDistance, Color.red);
            }
            
            if (noiseTimer >= 120)
            {
                noiseTimer = 0;
                noiseDistance = -1;
                anim.SetInteger("IdleState", 5);
                noiseDetected = false;
                nearView.SetActive(true);
            }
            if (hit.collider)
            {
                if (hit.collider.CompareTag("Player"))
                    GameInfo.PlayerDetected = true;
                
            }
        }
    }

    void TrapResponse()
    {
        trapTimer++;
        if (trapTimer >= 1)
            nearView.SetActive(false);
        anim.SetFloat("MoveX", 0);
        anim.SetFloat("MoveY", 0);
        transform.position = transform.position;
        anim.SetInteger("IdleState", 4);
        if(trapTimer >= 240)
        {
            anim.SetInteger("IdleState", 5);
            trapTimer = 0;
            trapDetected = false;
            nearView.SetActive(true);
        }
    }

    public override void DetectNoise(int distance)
    {
        noiseDetected = true;
        noiseDistance = distance;
    }

    public override void DetectTrap()
    {
        trapDetected = true;
    }

    public void IgnoreNoise()
    {
        noiseDetected = false;
    }

}
