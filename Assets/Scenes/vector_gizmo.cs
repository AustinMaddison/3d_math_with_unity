using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vector_gizmo : MonoBehaviour
{
 
    public bool fix_vector_length = false;
    public float vector_length = 1;

    public float gizmo_sphere_radias = 0.1f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;

        Vector2 end_pt = transform.position;

        if (fix_vector_length)
            end_pt = end_pt.normalized * vector_length;


        Gizmos.DrawLine(Vector2.zero, end_pt);       
        Gizmos.DrawWireSphere(end_pt, gizmo_sphere_radias);

        Gizmos.DrawWireSphere(transform.position, gizmo_sphere_radias);

    }


}

