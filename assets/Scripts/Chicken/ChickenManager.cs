using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenManager : MonoBehaviour
{    
    [SerializeField] float timerLimit;
    [SerializeField] float timer;
    [SerializeField] float movementSpeed;


    private float previousTime;
    Rigidbody rb;

    //[SerializeField] private NavMeshAgent navMeshAgent;

    public Vector3[] corners = new Vector3[100];
 

    NavMeshPath meshPath;

    private void Start()
    {
        meshPath = new NavMeshPath();
        timer = timerLimit;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            CalculatePath();
        }
        else if (Input.GetMouseButtonUp(0) && timer <= 0)
        {            
           
        }       
    }

    void CalculatePath()
    {
        Vector3 mousePos = PositionTaker.PosSender();
        float distance = Vector3.Distance(mousePos, transform.position);

        if (distance < 30f)
        {
            Move(Time.timeSinceLevelLoad - previousTime);
            previousTime = Time.timeSinceLevelLoad; 
            NavMesh.CalculatePath(transform.position, mousePos, NavMesh.AllAreas, meshPath);
        }
    }


    void Move(float elapsed)
    {
        if (meshPath == null) return;

        float distanceToTravel = movementSpeed * elapsed;
        int cornersCount = meshPath.GetCornersNonAlloc(corners);

        int arrayLenght = corners.Length - 1;
        for (int i = 0; i < arrayLenght; i++)
        {
            float temporaryDistance = Vector3.Distance(corners[i], corners[i + 1]);
            if (temporaryDistance < distanceToTravel)
            {
                distanceToTravel -= temporaryDistance;
                continue;
            }
            else
            {
                transform.position = Vector3.Lerp(corners[i], corners[i + 1], distanceToTravel / temporaryDistance);
                break;
            }
        }
    }


    /*void GetAway()
    {
        //navMeshAgent.SetDestination(transform.position);
        timer = timerLimit;
    }*/
}
