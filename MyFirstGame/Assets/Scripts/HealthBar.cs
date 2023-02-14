using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private float _speed= 0.1f;
    private float _currentValue;
    private float _targetValue;

    private void Start()
    {
        _currentValue = _slider.value;
        _targetValue = _slider.value;
        _player.OnHealthChanged.AddListener(UpdateValue);
    }

    public void Update()
    {
        if (_currentValue != _targetValue)
        {
            _currentValue = Mathf.MoveTowards(_currentValue, _targetValue, Time.deltaTime * _speed);
            _slider.value = _currentValue;
        }
    }

    public void UpdateValue()
    {
        _targetValue = _player.CalculateHealth();
        
    }
}
