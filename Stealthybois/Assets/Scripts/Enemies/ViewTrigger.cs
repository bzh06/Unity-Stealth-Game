using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTrigger : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameInfo.PlayerDetected = true;
        }
    }
}
