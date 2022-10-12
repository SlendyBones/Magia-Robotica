using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building")]
public class BaseBuilding : ScriptableObject
{
    public GameObject prefab;
    public int[] materialsTipe;
    public int[] materialsAmount;



}
