using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    public GameObject _pj;
    [SerializeField]
    private LayerMask _corrup;
    [SerializeField]
    private GameObject _particles;
    void Start()
    {
        //StartCoroutine(LateStart());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.down;
        RaycastHit hit;
        if(Physics.Raycast(_pj.transform.position,dir,out hit,2 ,_corrup))
        {
            if (hit.collider.gameObject.tag=="Corrup")
            {
                _particles.SetActive(true);
            }
            else
            {
                _particles.SetActive(false);
            }
        }
    }
    //IEnumerator LateStart()
    //{
    //    _pj = GameManager.instance.spawnedPlayer;
    //    yield return new WaitForEndOfFrame();
    //}
}
