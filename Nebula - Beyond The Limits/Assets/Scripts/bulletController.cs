using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
