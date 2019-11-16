using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectTrigger : MonoBehaviour
{
    ChickenPool chickenPool;
    private void Start()
    {
        chickenPool = GameObject.Find("Chicken Pool").GetComponent<ChickenPool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chicken"))
        {
            chickenPool.chickens.Remove(other.gameObject);        
            Destroy(other.gameObject);
        }
        FallingObjectManager.ObjectLoader(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        FallingObjectManager.ObjectLoader(gameObject);
    }
}
