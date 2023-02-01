using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPosition : MonoBehaviour
{
    public Transform root;
    public float footSpacing;
    public float stepDistance;
    public LayerMask terrainLayer;

    Vector3 currentPos;
    Vector3 newPos;

    private void Update()
    {
        transform.position = currentPos;

        Ray ray = new Ray(root.position + (root.right * footSpacing), Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer))
        {
            if (Vector3.Distance(newPos, info.normal) > stepDistance)
                newPos = info.point;
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(root.position + (root.right * footSpacing), Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(root.position + (root.right * footSpacing), info.point);
            Gizmos.DrawWireSphere(info.point, 0.3f);
        }
        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(root.position + (root.right * footSpacing), Vector3.down * 100);
        }
    }
}