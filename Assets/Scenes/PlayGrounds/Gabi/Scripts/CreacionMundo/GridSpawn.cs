using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawn : MonoBehaviour
{
    public GameObject node;

    [SerializeField]
    int xLength;
    [SerializeField]
    int zLength;
    [SerializeField]
    int _limitsHeight;

    private void Awake()
    {
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < zLength; y++)
            {
                Vector3 position = new Vector3(x, 0, y);
                GameManager.instance.allNodes.Add(Instantiate(node, position, Quaternion.identity).GetComponent<Nodes>());
            }
        }

        CreateLimits();
    }

    void CreateLimits()
    {
        float zlenghtLessOne = zLength - 1;
        float xLenghtLessOne = xLength - 1;
        float takeZPos = zlenghtLessOne / 2;
        float takeXPos = xLenghtLessOne / 2;

        GameObject zNegative = new GameObject();
        zNegative.transform.position = new Vector3(takeXPos, 0, -1);
        zNegative.transform.localScale = new Vector3(xLength + 2, _limitsHeight, zNegative.transform.localScale.z);
        zNegative.AddComponent<BoxCollider>();

        GameObject zPositive = new GameObject();
        zPositive.transform.position = new Vector3(takeXPos, 0, zLength);
        zPositive.transform.localScale = new Vector3(xLength + 2, _limitsHeight, zPositive.transform.localScale.z);
        zPositive.AddComponent<BoxCollider>();

        GameObject xNegative = new GameObject();
        xNegative.transform.position = new Vector3(-1, 0, takeZPos);
        xNegative.transform.localScale = new Vector3(xNegative.transform.localScale.x, _limitsHeight, zLength + 2);
        xNegative.AddComponent<BoxCollider>();

        GameObject xPositive = new GameObject();
        xPositive.transform.position = new Vector3(xLength, 0, takeZPos);
        xPositive.transform.localScale = new Vector3(xPositive.transform.localScale.x, _limitsHeight, zLength + 2);
        xPositive.AddComponent<BoxCollider>();
    }
}
