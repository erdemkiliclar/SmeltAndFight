using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BulletInstantiate : MonoBehaviour
{


    [SerializeField] private GameObject _bullet1, _bullet2, _bullet3, _bullet4;
    [SerializeField] private float speed = 10;

    
    
    public void Bullet1()
    {
        var bullet1 = Instantiate(_bullet1, transform.position, _bullet1.transform.rotation);
        bullet1.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    
    public void Bullet2()
    {
        var bullet2 = Instantiate(_bullet2, transform.position, _bullet2.transform.rotation);
        bullet2.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    public void Bullet3()
    {
        var bullet3 = Instantiate(_bullet3, transform.position, _bullet3.transform.rotation);
        bullet3.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    public void Bullet4()
    {
        var bullet4 = Instantiate(_bullet4, transform.position, _bullet4.transform.rotation);
        bullet4.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    
}
