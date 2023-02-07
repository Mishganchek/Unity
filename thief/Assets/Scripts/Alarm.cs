using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _speed;
    [SerializeField] private Door _door;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;
    private Coroutine _coroutine;


    private void OnEnable()
    {
        _door.Entered += OnDoorEntered;
        _door.Exited += OnDoorExited;
    }

    private void OnDisable()
    {
        _door.Entered -= OnDoorEntered;
        _door.Exited -= OnDoorExited;
    }

    private void OnDoorExited()
    {
        StopChange();
        _coroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private void OnDoorEntered()
    {
        _alarm.Play();
        StopChange();
       _coroutine =  StartCoroutine(ChangeVolume(_maxVolume));
    }

    private void Start()
    {
        _alarm.volume = 0f;
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (Mathf.Abs(_alarm.volume - target) > float.Epsilon)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, target, _speed * Time.deltaTime);
            yield return null;
        }
    }
    private void StopChange()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
