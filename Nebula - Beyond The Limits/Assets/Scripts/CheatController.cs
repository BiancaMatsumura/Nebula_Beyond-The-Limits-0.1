using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatController : MonoBehaviour
{
    public LevelLoader levelLoader;
    void Start()
    {
        
    }

    
    void Update()
    {
           
        if (Input.GetKeyDown(KeyCode.F1))
        {

            levelLoader.Transition("fase1");

        }

        if (Input.GetKeyDown(KeyCode.F2))
        {

            levelLoader.Transition("fase2");

        }
        if (Input.GetKeyDown(KeyCode.F3))
        {

            levelLoader.Transition("fase3");

        }
    }
}
