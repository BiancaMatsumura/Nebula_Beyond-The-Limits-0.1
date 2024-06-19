using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBalance : MonoBehaviour
{   
   
    public int nebulaBalaDano;
    public int nebulaLazerDano;
  
    

    void Start()
    {   
        PlayerPrefs.SetInt("bulletDamage",nebulaBalaDano);
        PlayerPrefs.SetInt("laserDamage",nebulaLazerDano);
        PlayerPrefs.Save();
        PlayerPrefs.DeleteKey("bossmorto");
    }

    void Update()
    {
        
    }
}
