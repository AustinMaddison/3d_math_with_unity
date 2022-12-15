using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere_line_gizmo : MonoBehaviour
{
    public float radius_circle = 1;
    public float radius_gizmo = 1;

    public bool flag_normalize = false;
    public bool flag_detract = false;

    public int number_of_lines = 10;
    public float scalar_factor = 1.0f;
    
    public bool flag_angle_threshold = false;
    public float angle_threshold = 0.0f;

    private void OnDrawGizmosSelected()
    { 

        float increment_angle = (Mathf.PI * 2) / number_of_lines;
        for (int i = 0; i < number_of_lines; i++)
        {
            // Circlular Coords to Cartesian Coords
            // ------------------------------------
            Vector2 end_pt;
            end_pt.x = Mathf.Cos(increment_angle * i);
            end_pt.y = Mathf.Sin(increment_angle * i);

            // Compute dot product of gizmo_dir and line end_pt(s)
            // ---------------------------------------------------
            Vector2 gizmo_dir = transform.position;
            if (flag_normalize)
                gizmo_dir.Normalize();
            float dp = Vector2.Dot(gizmo_dir, end_pt);

            // invert angle dot procuct
            // -------------------------
            if (flag_detract)
                dp = -dp;

            // Check if a given enf_pt is within the threshold
            // -----------------------------------------------
            if (flag_angle_threshold) 
            {
               if (dp >= angle_threshold)
                end_pt = end_pt * (1.0f + dp * scalar_factor);
            }
            else
                end_pt = end_pt * (1.0f + dp * scalar_factor);

            // Draw Gizmos
            // -----------
            Gizmos.DrawLine(Vector2.zero, end_pt);
            Gizmos.DrawWireSphere(end_pt, radius_circle);
            Gizmos.DrawWireSphere(transform.position, radius_gizmo);
        }
    }
}
