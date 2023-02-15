using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private float _speed = 0.1f;
    private Coroutine _coroutine;

    private float NormalizedHealth => _player.CurrentHealth / _player.MaxHealth;

    private void OnEnable()
    {
        _player.HealthChanged +=UpdateValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= UpdateValue;
    }

    public void UpdateValue()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeValue(NormalizedHealth));
    }

    private IEnumerator ChangeValue(float target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, Time.deltaTime * _speed);
            yield return null;
        }
    }
}
