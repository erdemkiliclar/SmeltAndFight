using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject _enemy,mainCamera;
    private Animator _animator;
    [SerializeField] private GameObject _failPanel;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        _enemy=GameObject.FindGameObjectWithTag("Enemy");
        _animator = _enemy.GetComponent<Animator>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _animator.Play("EnemyAttack");
            _enemy.GetComponent<EnemyController>().enabled = false;
            StartCoroutine(Cam());
        }
    }


    IEnumerator Cam()
    {
        yield return new WaitForSeconds(1.5f);
        mainCamera.GetComponent<Shake>().StartCoroutine(mainCamera.GetComponent<Shake>().Shaking());
        yield return new WaitForSeconds(.5f);
        _failPanel.SetActive(true);
    }
}
