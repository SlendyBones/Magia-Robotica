using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFunctionsCamera : MonoBehaviour
{
    [SerializeField] ChangeCamera _change;

    public void CallToBuildCamera()
    {
        _change.BuildingCamera();
    }

    public void CallToNormalCamera()
    {
        _change.NormalCamera();
    }
}
