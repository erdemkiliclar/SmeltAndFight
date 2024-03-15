using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{

    [SerializeField] GameObject _gun1Image, _gun2Image, _gun3Image, _gun4Image;
    

    // Start is called before the first frame update
    void Start()
    {
        if (SaveManager.instance.gunsUnlocked[0]==true)
        {
            
            _gun1Image.SetActive(true);

        }
        if (SaveManager.instance.gunsUnlocked[1] == true)
        {
            _gun2Image.SetActive(true);

        }
        if (SaveManager.instance.gunsUnlocked[2] == true)
        {
            _gun3Image.SetActive(true);

        }
        if (SaveManager.instance.gunsUnlocked[3] == true)
        {
            _gun4Image.SetActive(true);

        }

        
    }
    
    

}
