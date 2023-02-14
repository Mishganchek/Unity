using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private HealthBar _healthBar;

    public UnityEvent OnHealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public float CalculateHealth()
    {
        return (float)_currentHealth / _maxHealth;
    }

    private void ChangeHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
        OnHealthChanged.Invoke();
    }

    public void Heal()
    {
        ChangeHealth(10);
    }

    public void Damage()
    {
        ChangeHealth(-10);
    }
}


