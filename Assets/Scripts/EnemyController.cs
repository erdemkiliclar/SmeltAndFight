using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    
    private void FixedUpdate()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
    }
}
