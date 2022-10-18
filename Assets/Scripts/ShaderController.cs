using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShaderController : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    float _hologramFloat;
    [SerializeField]
    [Range(0, 1)]
    float _disolveFloat;
    [SerializeField]
    [Range(0, 1)]
    float _colorToRed;
    [SerializeField]
    [Range(-1, 1)]
    float _disolveAlpha;

    [SerializeField]
    List<MeshRenderer> _materialList = new List<MeshRenderer>() ;

  
    [SerializeField]
    Material _hologram;
    [SerializeField]
    Material _spawn;
 
    float index;

    private void Start()
    {
        ChangeSpawnToHologram();
    }





    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            _colorToRed = 1;
            ChangeColorToRed(_colorToRed);
           
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            _colorToRed = 0;
            ChangeColorToRed(_colorToRed);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeHologramToSpawn();
        }
        
         if (Input.GetKeyDown(KeyCode.B))
        {
            _disolveFloat = 1;
            Disolve(_disolveFloat);
        }
         else if (Input.GetKeyDown(KeyCode.N))
        {
            _disolveFloat = -1f;
            Disolve(_disolveFloat);
        }


        
    }
    void ChangeColorToRed(float numcolor)
    {

        for (int i = 0; i < _materialList.Count; i++)
        {
            
            _materialList[i].material.SetFloat("Vector1_544d9339e06341aba5618e62b9eb356d", numcolor);
        }

    }

   

    void Disolve(float numdisolve)
    {
        for (int i = 0; i < _materialList.Count; i++)
        {
            _materialList[i].material.SetFloat("Vector1_381786ad0e0f446184bc3b2fac8ee6bf", numdisolve);
        }
    }

    void ChangeHologramToSpawn()
    {
       
        
            for (int i = 0; i < _materialList.Count; i++)
            {
                _materialList[i].material = _spawn;
            }
       
      
    }

    void ChangeSpawnToHologram()
    {
       
        
            for (int i = 0; i < _materialList.Count; i++)
            {
                _materialList[i].material = _hologram;
            }
        

    }

    void Upvalues(float upfloat,float min, float max)
    {

        StartCoroutine(AddValue (upfloat, min, max,1));
        Debug.Log("Subir");
    }

    void DownValues(float downfloat, float min, float max)
    {
        StartCoroutine(AddValue(downfloat, min, max, -1));
        Debug.Log("Abajo");
    }

    IEnumerator AddValue(float upfloat, float min, float max, float dir)
    {
        bool continuewhile = true;
        while (continuewhile)
        {
            upfloat += Time.deltaTime*dir;
            if(upfloat <= min || upfloat >= max)
            {
                continuewhile = false;
            }
            upfloat = Mathf.Clamp(min, max, upfloat);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
  
}
