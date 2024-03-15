using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ItemRotater : MonoBehaviour
{
    // This code makes the Gameobject Rotate on Y axis , to use it just drag and drop it 
    private void Start()
    {
       RandomY(); 
    }
    void RandomY()
    {
        transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    }
}
