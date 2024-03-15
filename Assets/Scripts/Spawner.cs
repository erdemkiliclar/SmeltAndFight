using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] scrapsPlace = new Transform[9];
    [SerializeField] private GameObject scrap;
    public float scrapDeliveryTime, YAxis;
    public int CountScraps;
    public void Start()
    {
        for (int i = 0; i < scrapsPlace.Length; i++)
        {
            scrapsPlace[i] = transform.GetChild(0).GetChild(i);
        }

        StartCoroutine(Scrap(scrapDeliveryTime));
    }


   

    
    public IEnumerator Scrap(float Time)
    {
        if (CountScraps<100)
        {
            var SP_index = 0;
            while (CountScraps<100)
            {
                GameObject NewScrap = Instantiate(scrap, new Vector3(transform.position.x, -3f, transform.position.z),
                    Quaternion.identity, transform.GetChild(1));
            

                NewScrap.transform
                    .DOJump(
                        new Vector3(scrapsPlace[SP_index].position.x, scrapsPlace[SP_index].position.y + YAxis,
                            scrapsPlace[SP_index].position.z), 2f, 1, 0.5f).SetEase(Ease.OutQuad);
                CountScraps++;

                if (SP_index<8)
                {
                    SP_index++;
                }
                else
                {
                    SP_index = 0;
                    YAxis += 0.1f;
                }

                yield return new WaitForSecondsRealtime(Time);
            }
        
        }
    }
}
