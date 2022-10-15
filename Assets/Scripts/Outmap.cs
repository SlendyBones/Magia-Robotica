using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outmap : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    private GameObject _player;

    private void Start()
    {
        _player = GameManager.instance.playerPrefab;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "Player" )
        {
            
            collision.transform.position = spawnPoint.position;
            Debug.Log("Choque con algo");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            other.transform.position = spawnPoint.position;
        }
    }



}
