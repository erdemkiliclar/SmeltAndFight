using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deneme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.activeInHierarchy)
        {
            SaveManager.instance.gunsUnlocked[0] = true;
            SaveManager.instance.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1);
        }
    }
}
