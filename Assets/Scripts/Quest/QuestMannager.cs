using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestMannager : MonoBehaviour
{
    [SerializeField] List<string> _questStrings;
    [SerializeField] private int _missionToCheck;
    [SerializeField] private GameObject _quest;
    [SerializeField] private TextMeshProUGUI _questText;
    [SerializeField] private Animator _ani;
    
    [SerializeField] private Image _imageQuest;
   
    
    [SerializeField] private int _contructionOfEnsambladora;
    [SerializeField] private int _contructionOfHouse;
    [SerializeField] private int _contructionOfBoat;
    [SerializeField] private int _contructionOfGenerator;
    [SerializeField] private int _contrutionOfPortal;
    [SerializeField] private GameObject _ensanbladora;
    [SerializeField] private GameObject _house;
    [SerializeField] private GameObject _boat;
    [SerializeField] private GameObject _generator;
    [SerializeField] private GameObject _portal;
    [SerializeField] private Transform _apeearPoint;
  

    private void Start()
    {

        _questText.text = _questStrings[_missionToCheck];
    }

    public void CheckConstructions(GameObject building)
    {
        if(building== _ensanbladora)
        {
            Debug.Log("Cree una" + building);
            _contructionOfEnsambladora++;
            CheckMissionComplete();
        }
        else if (building == _house)
        {
            _contructionOfHouse++;
            CheckMissionComplete();
        }
     
        else if(building== _generator)
        {
            _contructionOfGenerator++;
            CheckMissionComplete();
        }
        else if (building == _boat)
        {
            _contructionOfBoat++;
            CheckMissionComplete();
        }
        else if (building == _portal)
        {
            _contrutionOfPortal++;
            CheckMissionComplete();
        }
        else
        {
            //Nada pasa
        }

    }

   

 

    void CheckMissionComplete( )
    {
        switch (_missionToCheck)
        {
            case 0:
                if (_contructionOfEnsambladora == 1)
                {
                    _missionToCheck++;
                    StartCoroutine(MissionComplete());
                  
                }
                break;
            //case 5:
            //    if (_contructionOfBoat == 1)
            //    {
            //        _missionToCheck++;
            //        StartCoroutine(MissionComplete());
            //    }
            //    break;
            case 1:
                if (_contructionOfHouse == 1)
                {
                    _missionToCheck++;
                    StartCoroutine(MissionComplete());
                }
                break;
            case 2:
                if (_contructionOfGenerator == 1)
                {
                    _missionToCheck++;
                    StartCoroutine(MissionComplete());
                }
                break;
            case 3:
                if (_contrutionOfPortal == 1)
                {
                    _missionToCheck++;
                    StartCoroutine(MissionComplete());
                }
                break;
            default:
                break;
        }
      
    }

    IEnumerator MissionComplete()
    {
        _imageQuest.color = Color.green;
        _ani.SetTrigger("Fade Out");
        //Animacion de movimiento;
        yield return new WaitForSeconds(0.5f);
        _imageQuest.color = Color.black;
        _questText.text = _questStrings[_missionToCheck];
        //_quest.transform.position = _apeearPoint.position;
        _ani.SetTrigger("Fade In");
        //animacion de entrada;

    }
}
