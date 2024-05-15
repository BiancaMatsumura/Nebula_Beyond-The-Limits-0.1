using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossLazerPoint : MonoBehaviour
{
    private Transform playerTransform;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {            
            transform.LookAt(playerTransform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
