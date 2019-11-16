using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPool : MonoBehaviour
{
    [SerializeField] public List<GameObject> chickens;
    [SerializeField] private GameObject chickenPrefab; 

    [SerializeField] private int chickenLimit;

    [Range(1, 2)]
    [SerializeField] private float frequency;

    [Range(1, 30)]
    [SerializeField] private float posFixValue;

    [Range(1, 100)]
    [SerializeField] private float heightFromPlatform;

    public IEnumerator CreateChickenPool(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        do
        {            
            GameObject temporaryChicken = Instantiate(chickenPrefab);
            //temporaryChicken.SetActive(false);
            temporaryChicken.transform.position = PlatformScaleTaker.ScaleFormule(frequency, posFixValue, heightFromPlatform); ;

            //StartCoroutine(ActivateChicken(temporaryChicken)); 

            chickens.Add(temporaryChicken);
        } while (chickens.Count < chickenLimit);
    }

   /* IEnumerator ActivateChicken(GameObject temporaryChicken)
    {
        yield return new WaitForSeconds(1f);

        temporaryChicken.SetActive(true);
    }*/
}
