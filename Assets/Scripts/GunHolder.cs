using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;

public class GunHolder : MonoBehaviour
{
    public int gunCount;
    private GameObject _player;
    [SerializeField] private GameObject _gun;
    private PlayerManager _playerManager;
    public Transform _gunHoldTransform;
    float delay;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Material _mat;
    [SerializeField] private GameObject _change;
    [SerializeField] GameObject _gunImage;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerManager = _player.GetComponent<PlayerManager>();
    }

    private void Update()
    {
        _countText.text = gunCount + "";

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&& _playerManager.metals.Count>1)
        {
            Arrows.arrow4a = 1;
            PlayerPrefs.SetInt("Arrow4",Arrows.arrow4a);
            if (gunCount>=_playerManager.metals.Count-1)
            {
                for (int i = _playerManager.metals.Count-1 ; i >= 1; i--)
                {
                    
                        _playerManager.metals[i].DOJump(_gunHoldTransform.position, 2f, 1, 0.5f).SetDelay(delay).SetEase(Ease.Flash).OnComplete((() =>
                        {
                            _playerManager.metals.ElementAt(i+1).parent = _gunHoldTransform;
                            _playerManager.metals.RemoveAt(i+1);
                            gunCount--;
                        

                            if (gunCount<=0)
                            {
                                _gun.transform.DOJump(_player.transform.position, 2, 1, 0.5f).SetDelay(delay).SetEase(Ease.Flash).OnComplete((
                                    () =>
                                    {
                                        Destroy(_gun);
                                        _change.GetComponent<Renderer>().materials[1].color = _mat.color;
                                        _gunImage.SetActive(true);
                                        //Destroy(this.gameObject.transform.parent.gameObject);

                                    }));
                            }
                        
                        
                        }));

                }
                    
                  
                delay += 0.02f;
                
                
            }

            if (gunCount<=_playerManager.metals.Count-1)
            {
                for (int i = gunCount ; i >= 1; i--)
                {
                    
                    _playerManager.metals[i].DOJump(_gunHoldTransform.position, 2f, 1, 0.5f).SetDelay(delay).SetEase(Ease.Flash).OnComplete((() =>
                    {
                        _playerManager.metals.ElementAt(i+1).parent = _gunHoldTransform;
                        _playerManager.metals.RemoveAt(i+1);
                        gunCount--;
                        

                        if (gunCount<=0)
                        {
                            _gun.transform.DOJump(_player.transform.position, 2, 1, 0.5f).SetDelay(delay).SetEase(Ease.Flash).OnComplete((
                                () =>
                                {
                                    Destroy(_gun);
                                    _change.GetComponent<Renderer>().materials[1].color = _mat.color;
                                    _gunImage.SetActive(true);
                                    //Destroy(this.gameObject.transform.parent.gameObject);

                                }));
                        }
                        
                        
                    }));

                }
                    
                  
                delay += 0.02f;

            }
            
            
        }
    }

}
      
