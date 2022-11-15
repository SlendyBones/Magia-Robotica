using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _buildCamera;
    [SerializeField] GameObject _particleCamera;
    [SerializeField] GameObject _sceneCamera;
    [SerializeField] Animator _mainAnimator;
    [SerializeField] Animator _buildAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _sceneCamera.SetActive(true);
        _mainCamera.SetActive(false);
        _buildCamera.SetActive(false);
        _particleCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _mainAnimator.SetTrigger("ToBuild");
          
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _buildAnimator.SetTrigger("ToCamera");
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            _sceneCamera.SetActive(true);
            _mainCamera.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            _sceneCamera.SetActive(false);
            _mainCamera.SetActive(true);

        }
    }

   public void NormalCamera()
    {
        ParticleCamera();
        StartCoroutine(MiddleOfChange(_mainCamera, _buildCamera,1));
    }

    public void BuildingCamera() 
    {
        ParticleCamera();
        StartCoroutine(MiddleOfChange(_buildCamera, _mainCamera,2));
    
    }
    void ParticleCamera()
    {
        _particleCamera.SetActive(true);
        _mainCamera.SetActive(false);
        _buildCamera.SetActive(false);
    }
    IEnumerator MiddleOfChange(GameObject cameraOn , GameObject cameraOff, int number)
    {
        yield return new WaitForSeconds(2f);
        _particleCamera.SetActive(false);
        cameraOff.SetActive(false);
        cameraOn.SetActive(true);
       
        if (number == 1)
        {
            _mainAnimator.SetTrigger("ToCamera");
        }
        else if (number == 2)
        {
            _buildAnimator.SetTrigger("ToBuild");
        }

    }

    //1 = MainCamera To BuildCamera
    //2= BuildCamera To MainCamera
   
}
