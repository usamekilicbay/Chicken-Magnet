using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{    

    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private int obstacleLimit;

    [Range(1, 2)]
    [SerializeField] private float frequency;

    [Range(1, 30)]
    [SerializeField] private float posFixValue;

    [Range(1, 100)]
    [SerializeField] private float heightFromPlatform;

    public IEnumerator CreateObstaclePool(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        do
        {
            GameObject temporaryObstacle = Instantiate(obstaclePrefab);

            int scale = Random.Range(5, 20);
            temporaryObstacle.transform.localScale = new Vector3(scale, scale, scale);

            temporaryObstacle.GetComponent<Renderer>().material.SetColor("_BaseColor", Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f));
            temporaryObstacle.transform.position = PlatformScaleTaker.ScaleFormule(frequency, posFixValue, heightFromPlatform);
           
            obstacles.Add(temporaryObstacle);
        } while (obstacles.Count < obstacleLimit);
    }
}
