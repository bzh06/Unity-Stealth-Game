using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private Animator anim;
    private int j = 0;
    private PlayerController pc;
    private Vector3 playerSpawn;
    private float TimeMultiplier;
    private float score, timeToComplete;
    public GameObject LevelEnd;
    private LevelInfo levelInfo;
	// Use this for initialization
	void Start () {
        pc = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
        score = 100;
        levelInfo = FindObjectOfType<LevelInfo>();
        GameInfo.PlayerDetected = false;
        GameInfo.AbilityCharges = levelInfo.AbilityCharges;
        GameInfo.PlayerWon = false;
        GameInfo.PlayerDeaths = 0;
        LevelEnd.SetActive(false);
        Time.timeScale = 1f;
        timeToComplete = 0;
        TimeMultiplier = levelInfo.TimePenalty;
        playerSpawn = levelInfo.PlayerSpawn;
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameInfo.PlayerDetected && !GameInfo.PlayerWon)
        {
            score -= TimeMultiplier;
            timeToComplete += Time.unscaledDeltaTime;
        }
        if(GameInfo.PlayerWon)
        {
            LevelEnd.SetActive(true);
            Time.timeScale = 0;
        }
        if (score <= 0)
            score = 0;
        if (GameInfo.PlayerDetected)
        {
            j++;
            score -= 10;
            pc.canMove = false;
            GameInfo.AbilityCharges = 3;
        }
        if (j == 20)
            anim.Play("FadeOut");
        if (j == 48)
        {
            anim.Play("FadeIn");
            pc.transform.position = playerSpawn;
            GameInfo.PlayerDeaths++;
        }
        if(j >= 76)
        {
            GameInfo.PlayerDetected = false;
            pc.canMove = true;
            Time.timeScale = 1f;
            j = 0;
        }
        if (j == 0)
            anim.Play("FadeIdle");
	}

    public float GetScore()
    {
        return score;
    }

    public float GetTime()
    {
        return timeToComplete;
    }
}
