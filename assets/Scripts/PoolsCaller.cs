using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsCaller : MonoBehaviour
{
    // Tek sefer çalıştırılacaklar
    [SerializeField] ObstaclePool obstaclePool;
    [SerializeField] EnvironmentPool environmentPool;
    [SerializeField] ChickenPool chickenPool;

    // Oyun süresince çalıştırılacak olanlar
    [SerializeField] BaitPool baitPool;
    [SerializeField] FallingObjectPool fallingObjectPool;


    [SerializeField] private float obstacleTime; 
    [SerializeField] private float environmentTime; 
    [SerializeField] private float chickenTime;

    [SerializeField] private float baitTime; 
    [SerializeField] private float fallingObjectTime; 

    void Start()
    {
        StartCoroutine(environmentPool.CreateEnvironmentPool(environmentTime));
        StartCoroutine(obstaclePool.CreateObstaclePool(obstacleTime));
        StartCoroutine(chickenPool.CreateChickenPool(chickenTime));

       // StartCoroutine(obstaclePool.CreatePool(baitTime));
       // StartCoroutine(obstaclePool.CreatePool(fallingObjectTime));
    }
}
