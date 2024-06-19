using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Vingança : MonoBehaviour
{   
    public GameObject spawn1;
    public GameObject spawn2;
    private int Bossmorte;
    // Start is called before the first frame update
    void Start()
    {   
        int cenaAtiva = SceneManager.GetActiveScene().buildIndex;
         if (cenaAtiva == 4)
        {

        if(PlayerPrefs.HasKey("bossmorto"))
        {   
            Bossmorte=PlayerPrefs.GetInt("bossmorto");
            if(Bossmorte==1)
            {
               spawn1.gameObject.SetActive(true);  
            }
            
                      
        }

        }
         
        if (cenaAtiva == 5)
        {   
             if(PlayerPrefs.HasKey("bossmorto"))
        {   
            Bossmorte=PlayerPrefs.GetInt("bossmorto");
            if(Bossmorte==1)
            {
               spawn1.gameObject.SetActive(true);  
            }
            if(Bossmorte==2)
            {
                spawn2.gameObject.SetActive(true);

            }
                      
        }

        }
         
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
