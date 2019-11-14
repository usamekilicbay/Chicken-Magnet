using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectManager : MonoBehaviour
{
    private FallingObjectPool fallingObjectPool;

    [SerializeField] private float timeLimit;
    [SerializeField] private float fallTimer;

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

        /*Vector3 fallPosition = Random.Range
        temporaryFallingObject.transform.position = ;*/
        temporaryFallingObject.SetActive(true);
    }
}
