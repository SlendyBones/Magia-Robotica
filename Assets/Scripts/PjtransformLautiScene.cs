using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjtransformLautiScene : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_post");
    public static int SizeID = Shader.PropertyToID("_size");

    public Material ObjectMaterial;
    public Camera Camera;
    public LayerMask Mask;

    void Update()
    {
        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, Mask))
            ObjectMaterial.SetFloat(SizeID, 1.5f);
        else
            ObjectMaterial.SetFloat(SizeID, 0);

        var view = Camera.WorldToViewportPoint(transform.position);
        ObjectMaterial.SetVector(PosID, view);
    }
}
