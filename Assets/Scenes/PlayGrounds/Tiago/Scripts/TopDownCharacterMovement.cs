using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMovement : MonoBehaviour
{
    [SerializeField]
    private InputHandler _input;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
        _input = GetComponent<InputHandler>();
    }
    private void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        var movementVector = MoveTowardTarget(targetVector);
        RotateTowardVector(movementVector);
    }

    private void RotateTowardVector(Vector3 movementVector)
    {
        if(movementVector.magnitude == 0) 
        { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
       
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
        targetVector = Quaternion.Euler(0, _camera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }
}
