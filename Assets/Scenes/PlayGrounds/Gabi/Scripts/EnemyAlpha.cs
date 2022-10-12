using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlpha : MonoBehaviour
{
    public GameObject target;
    public float viewRadius;
    Vector3 _velocity;
    public float maxSpeed;
    public float maxForce;

    private void Start()
    {
        target = GameManager.instance.spawnedPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) > viewRadius) return;

        Pursuit();

        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }

    public void Pursuit()
    {
        Vector3 desired = new Vector3();

        //ector3 futurePosition = target.transform.position + boidTarget.GetVelocity();
        desired = (target.transform.position - transform.position);

        desired.y = 0;
        desired = desired.normalized * maxSpeed;

        Vector3 steering = Vector3.ClampMagnitude(desired - _velocity, maxForce / 10);
        AddForce(steering);
    }

    void AddForce(Vector3 force)
    {
        _velocity += force;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
