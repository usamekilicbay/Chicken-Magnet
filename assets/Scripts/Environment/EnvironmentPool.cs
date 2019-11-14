using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> environments;
    [SerializeField] private GameObject grassPrefab;

    [SerializeField] private int environmentLimit;

    [SerializeField] private float frequency;
    [SerializeField] private float posFixValue;
    [SerializeField] private float heightFromPlatform;

    public IEnumerator CreateEnvironmentPool(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        do
        {
            GameObject temporaryGrass = Instantiate(grassPrefab);

            temporaryGrass.transform.position = PlatformScaleTaker.Instance.ScaleFormule(frequency, posFixValue, heightFromPlatform);

            environments.Add(temporaryGrass);
        } while (environments.Count < environmentLimit);
    }
}
