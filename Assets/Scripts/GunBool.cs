using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunBool : MonoBehaviour
{
    public static bool _gun1, _gun2, _gun3, _gun4;
    [SerializeField] private GameObject _gun1Image, _gun2Image, _gun3Image, _gun4Image;
    [SerializeField] private GameObject _nextButton;


    private void Start()
    {
        SaveManager.instance.gunsUnlocked[0] = false;
        SaveManager.instance.gunsUnlocked[1] = false;
        SaveManager.instance.gunsUnlocked[2] = false;
        SaveManager.instance.gunsUnlocked[3] = false;
        SaveManager.instance.Save();
    }

    private void Update()
    {
        if (_gun1Image.activeInHierarchy)
        {
            SaveManager.instance.gunsUnlocked[0] = true;
            SaveManager.instance.Save();
            _nextButton.SetActive(true);
        }
        
        if (_gun2Image.activeInHierarchy)
        {
            SaveManager.instance.gunsUnlocked[1] = true;
            SaveManager.instance.Save();
            _nextButton.SetActive(true);
        }
        if (_gun3Image.activeInHierarchy)
        {
            SaveManager.instance.gunsUnlocked[2] = true;
            SaveManager.instance.Save();
            _nextButton.SetActive(true);
        }
        if (_gun4Image.activeInHierarchy)
        {
            SaveManager.instance.gunsUnlocked[3] = true;
            SaveManager.instance.Save();
            _nextButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveManager.instance.gunsUnlocked[0] = false;
            SaveManager.instance.gunsUnlocked[1] = false;
            SaveManager.instance.gunsUnlocked[2] = false;
            SaveManager.instance.gunsUnlocked[3] = false;
            SaveManager.instance.Save();
        }

    }

    
}
