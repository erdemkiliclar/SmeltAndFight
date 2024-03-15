using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField] private GameObject arrow1, arrow2, arrow3,arrow4;
    public static int arrow1a, arrow2a, arrow3a,arrow4a;


    private void Awake()
    {
        arrow1a = PlayerPrefs.GetInt("Arrow1", arrow1a);
        arrow2a = PlayerPrefs.GetInt("Arrow2", arrow2a);
        arrow3a = PlayerPrefs.GetInt("Arrow3", arrow3a);
        arrow3a = PlayerPrefs.GetInt("Arrow4", arrow4a);
    }

    private void Update()
    {
        Debug.Log(arrow1a);
        if (PlayerPrefs.GetInt("Arrow1",arrow1a)<1)
        {
            arrow1.SetActive(true);
        }
        else
        {
            arrow1.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Arrow2",arrow2a)<1 && PlayerPrefs.GetInt("Arrow1",arrow1a)>0)
        {
            arrow2.SetActive(true);
        }
        else
        {
            arrow2.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Arrow3",arrow3a)<1 && PlayerPrefs.GetInt("Arrow2",arrow2a)>0)
        {
            arrow3.SetActive(true);
        }
        else
        {
            arrow3.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Arrow4",arrow4a)<1 && PlayerPrefs.GetInt("Arrow3",arrow3a)>0)
        {
            arrow4.SetActive(true);
            
        }
        else
        {
            arrow4.SetActive(false);
        }
    }
}
