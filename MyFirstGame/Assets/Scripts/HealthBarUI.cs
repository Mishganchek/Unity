using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider slider;
    private float _speed= 0.1f;
    private float _currentValue;
    private float _targetValue;

    private void Start()
    {
        _currentValue = slider.value;
        _targetValue = slider.value;
    }

    private void Update()
    {
        if (_currentValue != _targetValue)
        {
            _currentValue = Mathf.MoveTowards(_currentValue, _targetValue, Time.deltaTime * _speed);
            slider.value = _currentValue;
        }
    }

    public void UpdateValue(float value)
    {
        _targetValue = value;
        
    }
}
