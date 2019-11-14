using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> chickens;
    [SerializeField] private GameObject chickenPrefab; 

    [SerializeField] private int chickenLimit;

    [SerializeField] private float frequency;
    [SerializeField] private float posFixValue;
    [SerializeField] private float heightFromPlatform;

    public IEnumerator CreateChickenPool(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        do
        {
            GameObject temporaryChicken = Instantiate(chickenPrefab);
            temporaryChicken.transform.position = PlatformScaleTaker.Instance.ScaleFormule(frequency, posFixValue, heightFromPlatform);

            chickens.Add(temporaryChicken);
        } while (chickens.Count < chickenLimit);
    }
}
