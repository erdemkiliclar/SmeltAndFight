using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Smelter : MonoBehaviour
{
    [SerializeField] private Transform _metalPlace;
    [SerializeField] private GameObject _metal;
    public float YAxis,metalDeliveryTime;
    private IEnumerator makeMetalIE;
    public int counter;

    private void Start()
    {
        makeMetalIE = MakeMetal();
    }

    public void Run()
    {
        InvokeRepeating("DOSubmitScraps",1f,1f);
        StartCoroutine(makeMetalIE);
    }



    IEnumerator MakeMetal()
    {

       
        var _metalPlaceIndex = 0;

        yield return new WaitForSecondsRealtime(2);

        while (counter<100)
        {
            //GameObject newMetal = Instantiate(_metal, new Vector3(transform.position.x, -3f, transform.position.z),
              //  Quaternion.identity, _metalPlace.transform.GetChild(0));
            
            GameObject newMetal = Instantiate(_metal, new Vector3(_metalPlace.GetChild(_metalPlaceIndex).position.x,
                    YAxis, _metalPlace.GetChild(_metalPlaceIndex).position.z),
                _metalPlace.GetChild(_metalPlaceIndex).rotation,_metalPlace.transform.GetChild(0));
            
            newMetal.transform
                .DOJump(
                    new Vector3(_metalPlace.position.x, _metalPlace.position.y + YAxis,
                        _metalPlace.position.z), 2f, 1, 0.5f).SetEase(Ease.OutQuad);
            
            //newMetal.transform.DOScale(new Vector3(30,45,30), 0.5f).SetEase(Ease.OutElastic);
            
            if (_metalPlaceIndex<_metalPlace.childCount-1)
            {
                _metalPlaceIndex++;
            }
            else
            {
                _metalPlaceIndex = 0;
                YAxis += 0.15f;
            }

            yield return new WaitForSecondsRealtime(3f);

        }
    }

    void DOSubmitScraps()
    {
        if (transform.childCount>0)
        {
            Destroy(transform.GetChild(transform.childCount-1).gameObject,1f);
        }
        else
        {
            
            StopCoroutine(makeMetalIE);
        }
    }
}
