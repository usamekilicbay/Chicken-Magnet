using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenManager : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    Vector3 temporaryPosition;
    Vector3 temporaryRotation;

    private void Update()
    {
        if (transform.position.x < temporaryPosition.x + Random.Range(0f, 5f) 
            || transform.position.x > temporaryPosition.x + Random.Range(0f, 5f) 
            && transform.position.z < temporaryPosition.z + Random.Range(0f, 5f)
            || transform.position.z > temporaryPosition.z + Random.Range(0f, 5f))
        {
            temporaryRotation.x = BaitCreator.Instance.posTaker.transform.position.x;
            temporaryRotation.y = transform.rotation.y;
            temporaryRotation.z = BaitCreator.Instance.posTaker.transform.position.z;
            transform.LookAt(temporaryRotation);


            temporaryPosition = BaitCreator.Instance.posTaker.transform.position;//+ new Vector3(Random.Range(-5f,5f),0, Random.Range(-5f, 5f));
            temporaryPosition.y = transform.position.y;
            gameObject.transform.position = Vector3.MoveTowards(transform.position,
            temporaryPosition, movementSpeed * Time.deltaTime);
        }
    }  
}
