using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectManager : MonoBehaviour
{
    private static FallingObjectPool fallingObjectPool;

    [Range(0,10)]
    [SerializeField] private float timeLimit;

    [SerializeField] private float fallTimer;


    [Range(1, 2)]
    [SerializeField] private float frequency;

    [Range(1, 30)]
    [SerializeField] private float posFixValue;

    [Range(1, 100)]
    [SerializeField] private float heightFromPlatform;

    void Start()
    {
        fallingObjectPool = FallingObjectPool.Instance;

        fallTimer = Random.Range(1, timeLimit);
    }

    private void Update()
    {
        fallTimer -= Time.deltaTime;

        if (fallTimer <= 0 && fallingObjectPool.fallingObjects.Count > 0)
        {
            ObjectFaller();
            fallTimer = Random.Range(1, timeLimit);
        }        
    }

    void ObjectFaller()
    {
        int randomIndex = Random.Range(0, fallingObjectPool.fallingObjects.Count);

        GameObject temporaryFallingObject = fallingObjectPool.fallingObjects[randomIndex];

        fallingObjectPool.fallingObjects.Remove(temporaryFallingObject);

        temporaryFallingObject.transform.position = PlatformScaleTaker.ScaleFormule(frequency, posFixValue, heightFromPlatform);

        temporaryFallingObject.SetActive(true);
    }

    public static void ObjectLoader(GameObject temporaryFalledObject)
    {
        temporaryFalledObject.SetActive(false);
        fallingObjectPool.fallingObjects.Add(temporaryFalledObject);
    }
}
