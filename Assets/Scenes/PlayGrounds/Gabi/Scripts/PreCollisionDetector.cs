using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreCollisionDetector : MonoBehaviour
{
    public bool onCollision;

    private void OnTriggerStay(Collider other)
    {
        onCollision = true;
    }

    private void OnTriggerExit(Collider other)
    {
        onCollision = false;
    }
}
