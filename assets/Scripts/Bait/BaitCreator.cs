using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitCreator : MonoBehaviour
{
    private static BaitCreator _instance;
    public static BaitCreator Instance { get { return _instance; } }

    BaitPool baitPool;
    ChickenPool chickenPool;

    [SerializeField] private float timerActive;
    [SerializeField] private float timerActiveLimit;

    [SerializeField] private float timerPassive;
    [SerializeField] private float timerPassiveLimit;


    public GameObject posTaker;

    [SerializeField] LayerMask layerMask;

    [SerializeField] private int chickenCreatingLimit;

    private void Awake() { if (Instance == null) { _instance = this; } }

    private void Start()
    {
        baitPool = BaitPool.Instance;

        timerActive = timerActiveLimit;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timerActive -= Time.deltaTime;
            if (timerActive <= 0) { ActiveBait(); }
        }
        else { timerActive = timerActiveLimit; }
    }



    void ActiveBait()
    {
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {*/
        timerActive = timerActiveLimit;

        //posTaker.transform.position = hit.point;

        for (int i = 0; i < chickenCreatingLimit; i++)
        {
            GameObject temporaryBait = baitPool.passivebaits[0];
            temporaryBait.transform.position = PositionTaker.Instance.PosSender() + new Vector3(Random.Range(-2f, 2f), 3, Random.Range(-2f, 2f));
            temporaryBait.SetActive(true);
            baitPool.activebaits.Add(temporaryBait);
            baitPool.passivebaits.Remove(temporaryBait);
            StartCoroutine(PassiveBait());
        }
    }

    IEnumerator PassiveBait()
    {
        yield return new WaitForSeconds(timerPassiveLimit);
        GameObject temporaryBait = baitPool.activebaits[0];
        temporaryBait.SetActive(false);
        baitPool.passivebaits.Add(temporaryBait);
        baitPool.activebaits.Remove(temporaryBait);
    }
}