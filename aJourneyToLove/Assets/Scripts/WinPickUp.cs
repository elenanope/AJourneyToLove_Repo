using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPickUp : MonoBehaviour
{



    //poner que si matas x enemigos te salga elpickUp
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.memories >= 8)
        {
            Debug.Log("Has conseguido todos los recuerdos!");
        }
    }
}
