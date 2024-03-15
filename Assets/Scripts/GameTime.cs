using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTime : MonoBehaviour
{
    
    public float timeDuration;
    private float timer;
    
   

    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI seperator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;
    [SerializeField] private GameObject _failPanel;

    private void Start()
    {

        ResetTimer();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
            if (timer<=6)
            {
                firstMinute.color = Color.red;
                secondMinute.color=Color.red;
                firstSecond.color=Color.red;
                secondSecond.color=Color.red;
                seperator.color=Color.red;
                
            }
        }
        else
        {
            timer = 0;
            UpdateTimerDisplay(timer);
            if (timer==0)
            {
                for (int i = 0; i < SaveManager.instance.gunsUnlocked.Length; i++)
                {
                    if (SaveManager.instance.gunsUnlocked[i]==false)
                    {
                        _failPanel.SetActive(true);
                        
                    }

                    if (SaveManager.instance.gunsUnlocked[i]==true)
                    {
                        SceneManager.LoadScene(1);
                    }

                }
            }
        }
        
    }

    void ResetTimer()
    {
        timer = timeDuration;
    }
    void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();

    }
    
    
    
}
