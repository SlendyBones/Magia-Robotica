using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractuableObjectImages : MonoBehaviour
{
    [SerializeField] private GameObject _iconoInteractuables;
    [SerializeField] private GameObject _objeto;
    [SerializeField] private float _radius;
    [SerializeField] private Camera _sceneCamera;

    private void Start()
    {
        _iconoInteractuables.SetActive(true);
        StartCoroutine(LateStart());
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
                _iconoInteractuables.transform.LookAt(_sceneCamera.transform);
               
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

    IEnumerator LateStart()
    {
        _sceneCamera = Camera.main;
        yield return new WaitForSeconds(1f);
    }
}
