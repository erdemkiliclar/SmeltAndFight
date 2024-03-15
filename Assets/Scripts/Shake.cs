using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shake : MonoBehaviour
{

    [SerializeField] private bool start = false;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float duration = 1f;


    private void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }



    public IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime<duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere*strength;
            yield return null;
        }

        transform.position = startPosition;
    }

}
