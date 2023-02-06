using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _speed;
    private float _maxVolume = 1.0f;
    private Coroutine _coroutine;


    private void Start()
    {
        _alarm.volume = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        _alarm.Play();

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(IncreaseVolum());
    }

    private void OnTriggerExit(Collider other)
    {
        if (_coroutine != null)
        {

            StopCoroutine(_coroutine);
        }

        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(DecreaseVolum());
    }

    private IEnumerator IncreaseVolum()
    {
        while (_alarm.volume < 1)
        {

            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _maxVolume, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DecreaseVolum()
    {
        while (_alarm.volume > 0)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, 0, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
