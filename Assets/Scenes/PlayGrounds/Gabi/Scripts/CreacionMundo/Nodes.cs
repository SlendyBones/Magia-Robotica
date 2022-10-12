using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public List<Nodes> myNeighbours = new List<Nodes>();

    public bool spawned = false;
    public float maxRayDistance;
    int layerMask;
    public bool endStart;

    // Start is called before the first frame update
    void Start()
    {
        if (endStart == true) return;

        layerMask = LayerMask.GetMask("Nodes");

        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit forwardHit, maxRayDistance, layerMask))
        {
            myNeighbours.Add(forwardHit.transform.GetComponent<Nodes>());
        }

        if (Physics.Raycast(transform.position, -Vector3.forward, out RaycastHit backwardHit, maxRayDistance, layerMask))
        {
            myNeighbours.Add(backwardHit.transform.GetComponent<Nodes>());
        }

        if (Physics.Raycast(transform.position, Vector3.right, out RaycastHit rightHit, maxRayDistance, layerMask))
        {
            myNeighbours.Add(rightHit.transform.GetComponent<Nodes>());
        }

        if (Physics.Raycast(transform.position, -Vector3.right, out RaycastHit leftHit, maxRayDistance, layerMask))
        {
            myNeighbours.Add(leftHit.transform.GetComponent<Nodes>());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.forward * maxRayDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -Vector3.forward * maxRayDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.right * maxRayDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -Vector3.right * maxRayDistance);
    }
}
