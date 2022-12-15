using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_segment : MonoBehaviour
{

    public Transform Ta;
    public Transform Tb;

    public float distance;

    private void OnDrawGizmos()
    {

        distance = Vector2.Distance(Ta.position, Tb.position);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(Ta.position, Tb.position);   
    }
}

