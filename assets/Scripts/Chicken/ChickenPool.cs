using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPool : MonoBehaviour
{
    public List<GameObject> chickens;

    [SerializeField] GameObject chickenPrefab;

    [SerializeField] private int chickenLimit;

    private void Awake()
    {
        do
        {
            float xPos = Random.Range (-20f,20f);
            float zPos = Random.Range(-20f, 20f);
            Vector3 spawnPoint = new Vector3(xPos, 1, zPos);

            GameObject temporaryObj = Instantiate(chickenPrefab, spawnPoint, transform.rotation);
            chickens.Add(temporaryObj);
        } while (chickens.Count < chickenLimit);
    }
}
