using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TryPathfinding : MonoBehaviour
{
    public Vector3 target;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    Rigidbody rb;
    public  float movementSpeed;

    bool isReady;

    Vector3[] corners = new Vector3[10];
    public GameObject flag;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        path = new NavMeshPath();
        elapsed = 0.0f;
    }

    void Update()
    {


        target = PositionTaker.PosSender();
        elapsed += Time.deltaTime;
        //if (elapsed > 1.0f)
       // {
         //   elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);
        // }

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            Debug.Log("Gonya Yolundayım GONYAAAA");
            for (int i = 0; i < path.corners.Length -1; i++)
            {
                Debug.DrawLine(path.corners[i], path.corners[i+1], Color.red);

                if (transform.position == path.corners[i])
                {
                    Move(path.corners[i + 1]);
                }
                //corners[i] = path.corners[i];
                
            }
            isReady = true;
            
        }
        else if (path.status == NavMeshPathStatus.PathInvalid)
        {
            isReady = false;
            //rb.position = transform.position;
            //NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);
            Debug.Log("Yol mu var orda Kör!");
        }


    }
    void Move(Vector3 pos)
    {
       // if (isReady)
        {
            //rb.MovePosition(path.corners[++i] * movementSpeed);
            // }
            rb.position = Vector3.Lerp(transform.position, pos, movementSpeed);
            //Instantiate(flag, path.corners[i], Quaternion.identity);
            for (int i = 0; i < corners.Length; i++)
            {
                if (Vector3.Distance(transform.position, corners[i]) < 5f)
                {
                    rb.position = Vector3.Lerp(transform.position, corners[i], movementSpeed);
                }
            }

        }
    }
}
