using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitPool : MonoBehaviour
{
    private static BaitPool _instance;
    public static BaitPool Instance { get { return _instance; } }

    private void Awake() { if (Instance == null) { _instance = this; } }

    public int objectCount;

    public List<GameObject> passivebaits;
    public List<GameObject> activebaits;

    public GameObject baitPrefab;


    private void Start()
    {
        do
        {
            GameObject temporaryBait = Instantiate(baitPrefab, gameObject.transform);
            temporaryBait.SetActive(false);
            passivebaits.Add(temporaryBait);

        }
        while (passivebaits.Count < objectCount);
    }  
}
