using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectPool : MonoBehaviour
{
     private static FallingObjectPool _instance;
     public static FallingObjectPool Instance { get { return _instance; } }

    public List<GameObject> fallingObjects;
    public GameObject meteor;

    [SerializeField] private int fallingObjectLimit;

    private void Awake() { if (Instance == null) { _instance = this; } }

    private void Start()
    {   
        do
        {
            GameObject temporaryFallingObject = Instantiate(meteor);
           // temporaryFallingObject.transform.position = PlatformScaleTaker.ScaleFormule(frequency, posFixValue, heightFromPlatform);
            temporaryFallingObject.SetActive(false);

            fallingObjects.Add(temporaryFallingObject);
        } while (fallingObjects.Count < fallingObjectLimit);    
    }
}
