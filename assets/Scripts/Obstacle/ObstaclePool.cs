using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{    

    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private int obstacleLimit;

    [SerializeField] private float frequency;
    [SerializeField] private float posFixValue;
    [SerializeField] private float heightFromPlatform;

    public IEnumerator CreateObstaclePool(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        do
        {
            GameObject temporaryObstacle = Instantiate(obstaclePrefab);

            int scale = Random.Range(4, 15);
            temporaryObstacle.transform.localScale = new Vector3(scale, scale, scale);

            temporaryObstacle.GetComponent<Renderer>().material.SetColor("_BaseColor", Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f));
            temporaryObstacle.transform.position = PlatformScaleTaker.Instance.ScaleFormule(frequency, posFixValue, heightFromPlatform);

            obstacles.Add(temporaryObstacle);
        } while (obstacles.Count < obstacleLimit);
    }
}
