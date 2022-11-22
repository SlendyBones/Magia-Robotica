using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraForTheGame : MonoBehaviour
{
 
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _buildCamera;
    [SerializeField] GameObject _particleCamera;
    [SerializeField] GameObject _mapCamera;
    [SerializeField] Animator _mainAnimator;
    [SerializeField] Animator _buildAnimator;
    [SerializeField] Animator _mapAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _mapCamera.SetActive(false);
        _mainCamera.SetActive(true);
        _buildCamera.SetActive(false);
        _particleCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(_buildCamera==true)
            _mainAnimator.SetTrigger("ToBuild");
            else
                _buildAnimator.SetTrigger("ToCamera");


        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (_mapCamera == false)
                _mainAnimator.SetTrigger("ToMap");
            else
                _mapAnimator.SetTrigger("ToCamera");
        }
       
    }

   public void NormalCamera()
    {
        ParticleCamera();
        StartCoroutine(MiddleOfChange(_mainCamera, _buildCamera, _mapCamera, 1));
    }

    public void BuildingCamera() 
    {
        ParticleCamera();
        StartCoroutine(MiddleOfChange(_buildCamera, _mainCamera,_mapCamera, 2));
    
    }

    public void MapCamera()
    {
        ParticleCamera();
        StartCoroutine(MiddleOfChange(_mapCamera, _mainCamera, _buildCamera, 3));
    }
    void ParticleCamera()
    {
        _particleCamera.SetActive(true);
        _mainCamera.SetActive(false);
        _buildCamera.SetActive(false);
        _mapCamera.SetActive(false);
    }
    IEnumerator MiddleOfChange(GameObject cameraOn , GameObject cameraOff, GameObject secondCameraOff, int number)
    {
        yield return new WaitForSeconds(2f);
        _particleCamera.SetActive(false);
        cameraOff.SetActive(false);
        secondCameraOff.SetActive(false);
        cameraOn.SetActive(true);
       
        if (number == 1)
        {
            _mainAnimator.SetTrigger("ToCamera");
        }
        else if (number == 2)
        {
            _buildAnimator.SetTrigger("ToBuild");
        }
        else if (number == 3)
        {
            _mapAnimator.SetTrigger("ToMap");
        }
    }

    //1 = MainCamera To BuildCamera
    //2= BuildCamera To MainCamera
    //3= MainCamera To MapCamera
}
