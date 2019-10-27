using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z - distance);
    }
}
