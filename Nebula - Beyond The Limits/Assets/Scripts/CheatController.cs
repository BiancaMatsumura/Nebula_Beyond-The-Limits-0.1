using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
           
        if (Input.GetKeyDown(KeyCode.F1))
        {

            SceneManager.LoadScene("fase1");

        }

        if (Input.GetKeyDown(KeyCode.F2))
        {

            SceneManager.LoadScene("fase2");

        }

    }
}
