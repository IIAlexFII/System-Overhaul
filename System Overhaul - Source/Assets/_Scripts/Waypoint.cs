using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint[] edges;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (edges != null)
        {
            foreach (Waypoint wp in edges)
            {
                if (wp)
                {
                    Gizmos.DrawLine(transform.position, wp.transform.position);
                }
            }
        }
    }
}
