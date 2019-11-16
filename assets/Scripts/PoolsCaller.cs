using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsCaller : MonoBehaviour
{
    #region Pool Scripts
    // Tek sefer çalıştırılacaklar
    [SerializeField] EnvironmentPool environmentPool;
    [SerializeField] ObstaclePool obstaclePool;
    [SerializeField] ChickenPool chickenPool;

    // Oyun süresince çalıştırılacak olanlar
    [SerializeField] BaitPool baitPool;
    [SerializeField] FallingObjectPool fallingObjectPool;
    #endregion

    #region Pool's Creating Timers
    [SerializeField] private float environmentTime; 
    [SerializeField] private float obstacleTime; 
    [SerializeField] private float chickenTime;

    [SerializeField] private float baitTime; 
    [SerializeField] private float fallingObjectTime;
    #endregion

    #region Pool's Creating Bools
    [SerializeField] private bool environmentPoolActivate;
    [SerializeField] private bool obstaclePoolActivate;
    [SerializeField] private bool chickenPoolActivate;

    [SerializeField] private bool baitPoolActivate;
    [SerializeField] private bool fallingObjectPoolActivate;
    #endregion
    
    
    //[Header("Activate Scripts")]
    //public string className= "ObstaclePool";
    // public Pools pools;

    //public enum Pools { Nothing, Everything, ObstaclePool, EnvironmentPool, ChickenPool, BaitPool, FallingObjectPool }

    void Start()
    {
        if (environmentPoolActivate) { StartCoroutine(environmentPool.CreateEnvironmentPool(environmentTime)); }
        if (obstaclePoolActivate) { StartCoroutine(obstaclePool.CreateObstaclePool(obstacleTime)); }
        if (chickenPoolActivate) { StartCoroutine(chickenPool.CreateChickenPool(chickenTime)); }

        // if (baitPoolActivate) { StartCoroutine(obstaclePool.CreatePool(baitTime)); }
        // if (fallingObjectPoolActivate) { StartCoroutine(obstaclePool.CreatePool(fallingObjectTime)); 
    }
}
