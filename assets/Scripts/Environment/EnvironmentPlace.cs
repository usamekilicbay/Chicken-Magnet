using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPlace : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(Random.Range(-20f, 20f), 0.2f, Random.Range(-20f, 20f));
    }   
}
