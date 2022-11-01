using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractuableObjectImages : MonoBehaviour
{
    [SerializeField] private GameObject _iconoInteractuables;
    [SerializeField] private GameObject _objeto;
    [SerializeField] private float _radius;

    private void Start()
    {
        _iconoInteractuables.SetActive(false);
    }

    private void Update()
    {
        if (_objeto == null)
        {
            Destroy(this.gameObject);
        }
        PlayerIsNear();
    }

    private void PlayerIsNear()
    {
        Collider[] nearcolliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (var colliders in nearcolliders)
        {
            if (colliders.gameObject.tag==("Player"))
            {
                _iconoInteractuables.SetActive(true);
                
            }
            else
            {
                _iconoInteractuables.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
