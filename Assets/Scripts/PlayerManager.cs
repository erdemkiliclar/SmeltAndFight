using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Vector3 direction;
    private Camera Cam;
    [SerializeField] private float playerSpeed;
    private Animator _animator;
    public List<Transform> scraps = new List<Transform>();
    public List<Transform> metals = new List<Transform>();
    [SerializeField] private Transform scrapPlace,metalPlace;
    private float YAxis,delay;
    private GameObject _dropArea;
    private Spawner _spawner;
   
    
    private void Awake()
    {
        _dropArea=GameObject.FindGameObjectWithTag("DropArea");
    }


    private void Start()
    
    {
        Cam = Camera.main;
        _animator = GetComponent<Animator>();
        scraps.Add(scrapPlace);
        metals.Add(scrapPlace);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);

        }

        
        if (scraps.Count>1)
        {
            for (int i = 1; i < scraps.Count; i++)
            {
                var firstScrap = scraps.ElementAt(i - 1);
                var secondScrap = scraps.ElementAt(i);

                secondScrap.position =
                    new Vector3(Mathf.Lerp(secondScrap.position.x, firstScrap.position.x, Time.deltaTime * 15f),
                        Mathf.Lerp(secondScrap.position.y, firstScrap.position.y + 0.12f, Time.deltaTime * 15f),
                        firstScrap.position.z);
 
            }
            
            
        }

        if (metals.Count>1)
        {
            for (int i = 1; i < metals.Count; i++)
            {
                var firstMetal = metals.ElementAt(i - 1);
                var secondMetal = metals.ElementAt(i);

                secondMetal.position =
                    new Vector3(Mathf.Lerp(secondMetal.position.x, firstMetal.position.x, Time.deltaTime * 15f),
                        Mathf.Lerp(secondMetal.position.y, firstMetal.position.y + 0.12f, Time.deltaTime * 15f),
                        firstMetal.position.z);
 
            }
        }
        
        
        
        
        
        if (Physics.Raycast(transform.position, transform.forward,out var hit, 1f))
        {
            
            Debug.DrawRay(transform.position,transform.forward*1f,Color.green);
            
            if (hit.collider.CompareTag("CollectArea")&&scraps.Count<21)
            {
                Arrows.arrow1a = 1;
                PlayerPrefs.SetInt("Arrow1",Arrows.arrow1a);
                _spawner = hit.collider.transform.parent.GetComponent<Spawner>();
                if (hit.collider.transform.childCount>=0)
                {

                    var scrap = hit.collider.transform.GetChild(_spawner.CountScraps-2);
                    scrap.parent = scrapPlace;
                    scrap.rotation = scrapPlace.rotation;
                    scraps.Add(scrap);
                    

                   if (_spawner.CountScraps>1)
                    {
                        _spawner.CountScraps--;

                    }

                    if (_spawner.YAxis>0f)
                    {
                       _spawner.YAxis -= 0.1f;
                    }
                    
                }
                
            }
            
            
            if (hit.collider.CompareTag("CollectMetal")&&metals.Count<21)
            {
                Arrows.arrow3a = 1;
                PlayerPrefs.SetInt("Arrow3",Arrows.arrow3a);
                if (hit.collider.transform.childCount>0)
                {

                    var metal = hit.collider.transform.GetChild(0).GetChild(0);
                    metal.parent = scrapPlace;
                    metal.rotation = metalPlace.rotation;
                    metals.Add(metal);
                    

                    if (_dropArea.GetComponent<Smelter>().counter>1)
                    {
                        _dropArea.GetComponent<Smelter>().counter--;
                    }

                    if (_dropArea.GetComponent<Smelter>().YAxis>0f)
                    {
                        _dropArea.GetComponent<Smelter>().YAxis -= 0.17f;
                    }
                   
                }
                
            }
            

            if (hit.collider.CompareTag("DropArea")&& scraps.Count>1)
            {
                Arrows.arrow2a = 1;
                PlayerPrefs.SetInt("Arrow2",Arrows.arrow2a);
                var Drop = hit.collider.transform;
                if (Drop.childCount>0)
                {
                    YAxis = Drop.GetChild(Drop.childCount - 1).position.y;
                }
                else
                {
                    YAxis = Drop.position.y;
                }

                for (int i = scraps.Count-1; i >= 1; i--)
                {
                    scraps[i].DOJump(new Vector3(Drop.position.x, YAxis, Drop.position.z), 2f, 1, 0.5f).SetDelay(delay)
                        .SetEase(Ease.Flash);
                    
                    scraps.ElementAt(i).parent = Drop;
                    scraps[i].rotation = Drop.rotation;
                    scraps.RemoveAt(i);
                    
                    
                    YAxis += 0.12f;
                    delay += 0.02f;
                }

                if (scraps.Count<=1)
                {
                    
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward*1f,Color.red);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DropArea"))
        {
            other.GetComponent<Smelter>().Run();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DropArea"))
        {
            
            delay = 0f;
        }
        
       
        
    }

    
}
