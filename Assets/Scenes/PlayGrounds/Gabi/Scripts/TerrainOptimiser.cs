using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainOptimiser : MonoBehaviour
{
    public float maxViewRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TerrainCheck();
    }

    public void TerrainCheck()
    {
        foreach (var node in GameManager.instance.allPastitos)
        {
            if (Vector3.Distance(node.transform.position, transform.position) > maxViewRadius)
            {
                node.SetActive(false);
            }
            else
            {
                node.SetActive(true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxViewRadius);
    }
}
