using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTaker : MonoBehaviour
{
   /* private static PositionTaker _instance;
    public static PositionTaker Instance { get { return _instance; } }*/

  // private void Awake() { if (Instance == null) { _instance = this; } }

    static Vector3 temporaryPos;

    public static Vector3 PosSender()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;       

        if (Physics.Raycast(ray, out hit))
        {
            temporaryPos = hit.point;            
        }
        return temporaryPos;
    }
}
