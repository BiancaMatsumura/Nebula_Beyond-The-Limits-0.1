using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float destructionDelay = 1.0f;
    private Animator laserAnimation;
    private Transform laserpoint;

    public void SetFirePoint(Transform firePoint)
    {
        laserpoint = firePoint;
    }
    private void Start()
    {


        laserAnimation = GetComponent<Animator>();
        laserAnimation.SetBool("startLaser", true);

    }

    private void Update()
    {
        if (laserpoint != null)
        {
            transform.position = laserpoint.position;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

          Destroy(gameObject, destructionDelay);

        }

    }

    public void StartLaser()
    {
        laserAnimation.SetBool("startLaser", true);
    }


}
