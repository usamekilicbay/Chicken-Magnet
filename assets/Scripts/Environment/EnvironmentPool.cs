using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> environments;
    [SerializeField] private GameObject grassPrefab;

    [SerializeField] private int environmentLimit;

    [Range(1, 2)]
    [SerializeField] private float frequency;

    [Range(1, 30)]
    [SerializeField] private float posFixValue;

    [Range(1, 100)]
    [SerializeField] private float heightFromPlatform;

    public IEnumerator CreateEnvironmentPool(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        do
        {
            GameObject temporaryGrass = Instantiate(grassPrefab);

            temporaryGrass.transform.position = PlatformScaleTaker.ScaleFormule(frequency, posFixValue, heightFromPlatform);

            environments.Add(temporaryGrass);
        } while (environments.Count < environmentLimit);
    }
}
