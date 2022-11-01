using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItsGeneratorNear : MonoBehaviour
{
    [SerializeField] private GameObject _activado;
    [SerializeField] private GameObject _generador;
    
    [SerializeField] private int _radius;
    void Start()
    {
        
        _activado.SetActive(false);
    }

    
    void Update()
    {
        
    }

    private void GeneratorIsNear()
    {
        Collider[] nearColliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (var collider in nearColliders)
        {
            if (collider.gameObject == _generador)
            {
                _activado.SetActive(true);
                Debug.Log("Esta el generador");
            }
            else
            {
                _activado.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
