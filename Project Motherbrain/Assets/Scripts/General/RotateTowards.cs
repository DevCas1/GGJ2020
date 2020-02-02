using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    [SerializeField] 
    private Vector3 LookPosition;

    [Header("Lock Axis"), SerializeField, InspectorName("X")] 
    private bool LockX;
    [SerializeField, InspectorName("Y")] 
    private bool LockY;
    [SerializeField, InspectorName("Z")] 
    private bool LockZ;

    private void Update()
    {
        Vector3 position = transform.position;
        Vector3 lookOrigin = new Vector3(LockX ? position.x : LookPosition.x,
                                         LockY ? position.y : LookPosition.y,
                                         LockZ ? position.z : LookPosition.z);

        Vector3 lookVector = lookOrigin - position;

        transform.rotation = Quaternion.LookRotation(lookVector, Vector3.up);
    }
}