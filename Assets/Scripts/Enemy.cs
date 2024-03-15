using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health = 100;
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private GameObject _particle;
    [SerializeField] private GameObject bigpart;


    private void Start()
    {
        health = health / 100;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet1"))
        {
            health -= 0.5f/100f;
            _particle.transform.position = collision.gameObject.transform.position;
            _particle.GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject);
            HealthBar();
            Death();
        }

        if (collision.gameObject.CompareTag("bullet2"))
        {
            health -= 1.5f/100f;
            _particle.transform.position = collision.gameObject.transform.position;
            _particle.GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject);
            HealthBar();
            Death();
        }

        if (collision.gameObject.CompareTag("bullet3"))
        {
            health -= 2f/100f;
            bigpart.transform.position = collision.gameObject.transform.position;
            bigpart.GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject);
            HealthBar();
            Death();
        }

        if (collision.gameObject.CompareTag("bullet4"))
        {
            health -= 3f/100f;
            bigpart.transform.position = collision.gameObject.transform.position;
            bigpart.GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject);
            HealthBar();
            Death();
        }
         
    }



    public void HealthBar()
    {
        _healthBar.fillAmount = health;
        
    }

    public void Death()
    {
        if (health<=0)
        {
            _victoryPanel.SetActive(true);
            GetComponent<EnemyController>().enabled = false;
            GetComponent<Animator>().Play("Death");
        }
    }
}
