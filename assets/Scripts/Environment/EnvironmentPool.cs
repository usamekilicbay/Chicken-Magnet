using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPool : MonoBehaviour
{
    public List<GameObject> environments;
    public GameObject grassPrefab;

    public int environmentLimit;

    void Start()
    {
        do
        {
            GameObject temporaryObj = Instantiate(grassPrefab);
            environments.Add(temporaryObj);
        } while (environments.Count < environmentLimit); 
    }
}
