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
    float _floatCode;
    [SerializeField]
    [Range(-1, 1)]
    float _disolveAlpha;
    [SerializeField]
    List<MeshRenderer> _materialList = new List<MeshRenderer>() ;
    [SerializeField]
    [Range(0, 1)]
    float _ithere;
    [SerializeField]
     [Range(0,1)]
      float _disolveOn;
    private float _clampMaxGeneral=1;
    private float _clampMinGeneral=0;
    private float _ClamMaxDA=1;
    private float _ClamMinDA=-1;


    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            _floatCode = 1;
            ChangeColorToRed(_floatCode);
           
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            _floatCode = 0;
            ChangeColorToRed(_floatCode);
        }
        

        if (Input.GetKeyDown(KeyCode.C))
        {
            _hologramFloat = 1;
            Hologram(_hologramFloat);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            _hologramFloat = 0;
            Hologram(_hologramFloat);
        }
        
        
         if (Input.GetKeyDown(KeyCode.B))
        {
            _disolveFloat = 1;
            Disolve(_disolveFloat);
        }
         else if (Input.GetKeyDown(KeyCode.N))
        {
            _disolveFloat = 0;
            Disolve(_disolveFloat);
        }

         if (Input.GetKeyDown(KeyCode.F1))
        {
            Upvalues(_disolveAlpha, -1, 1);
            GeneralDisolve(_disolveAlpha);
        }
         else if (Input.GetKeyDown(KeyCode.F2))
        {
            DownValues(_disolveAlpha, -1, 1);
            NoGeneralDisolve(_disolveAlpha);
        }

        
    }
    void ChangeColorToRed(float numcolor)
    {

        for (int i = 0; i < _materialList.Count; i++)
        {
            _materialList[i].material.SetFloat("Vector1_a8ad615cdfaf4f61a4a93f08bd554ec4", numcolor);
        }

    }

    void Hologram(float numhologram)
    {
        for (int i = 0; i < _materialList.Count; i++)
        {
            _materialList[i].material.SetFloat("Vector1_c1fd91cad2db4f67bec31d66c66d7086", numhologram);
        }

    }

    void Disolve(float numdisolve)
    {
        for (int i = 0; i < _materialList.Count; i++)
        {
            _materialList[i].material.SetFloat("Vector1_631de6cd87c84f6d89d81b6703c01390", numdisolve);
        }
    }

   private void AnimationDisolve(float numani)
    {
        for (int i = 0; i < _materialList.Count; i++)
        {
            _materialList[i].material.SetFloat("Vector1_381786ad0e0f446184bc3b2fac8ee6bf", numani);
        }
    }
  
  private  void DisolveOn(float divo)
    {
        for (int i = 0; i < _materialList.Count; i++)
        {
            _materialList[i].material.SetFloat("Vector1_fe10557a87b54ac7974b87e0c2b00904", divo);
        }
    }

  private  void ItsHere(float its)
    {
        for (int i = 0; i < _materialList.Count; i++)
        {
            _materialList[i].material.SetFloat("Vector1_b1fbc3d1ae6f47c49ff5dddd8ab87207", its);
        }
    }

    void GeneralDisolve(float newvalue)
    {
        _disolveAlpha = newvalue;
        AnimationDisolve(_disolveAlpha);
        _disolveOn = 1;
        DisolveOn(_disolveOn);
        _ithere = 0;
        ItsHere(_ithere);
    }

    void NoGeneralDisolve(float newValue)
    {
        _disolveAlpha = 1;
        AnimationDisolve(_disolveAlpha);
        _disolveOn = 0;
        DisolveOn(_disolveOn);
        _ithere = 1;
        ItsHere(_ithere);
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
