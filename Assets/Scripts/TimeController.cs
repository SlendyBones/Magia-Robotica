using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float _timeMultiplier;
    [SerializeField] private float _startHour;
    [SerializeField] private Light _sunLight;
    [SerializeField] private float _sunriseHour;
    [SerializeField] private float _sunsetHour;
    [SerializeField] private Color _dayAmbientLight;
    [SerializeField] private Color _nightAmbientLight;
    [SerializeField] private AnimationCurve _lightChangeCurve;
    [SerializeField] private float _maxSunLightIntensity;
    [SerializeField] private Light _moonLight;
    [SerializeField] private float _maxMoonLightIntensity;

    private DateTime _currentTime;
    private TimeSpan _sunriseTime;
    private TimeSpan _sunsetTime;

    void Start()
    {
        _currentTime = DateTime.Now.Date + TimeSpan.FromHours(_startHour);

        _sunriseTime = TimeSpan.FromHours(_sunriseHour);

        _sunsetTime = TimeSpan.FromHours(_sunsetHour);
    }

   
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }

     private void UpdateTimeOfDay()
    {
        _currentTime = _currentTime.AddSeconds(Time.deltaTime * _timeMultiplier);

        
    }

    private void RotateSun()
    {
        float sunLightRotation;

        if (_currentTime.TimeOfDay>_sunriseTime && _currentTime.TimeOfDay < _sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(_sunriseTime, _sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(_sunriseTime, _currentTime.TimeOfDay);

            Double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180,(float)percentage);
        }
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(_sunsetTime, _sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(_sunsetTime, _currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }


        _sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(_sunLight.transform.forward, Vector3.down);
        _sunLight.intensity = Mathf.Lerp(0, _maxSunLightIntensity, _lightChangeCurve.Evaluate(dotProduct));
        _moonLight.intensity = Mathf.Lerp(_maxMoonLightIntensity, 0, _lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(_nightAmbientLight, _dayAmbientLight, _lightChangeCurve.Evaluate(dotProduct));
    }


    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;
        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
}
