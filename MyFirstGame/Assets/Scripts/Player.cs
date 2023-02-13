using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private HealthBarUI _healthBarUI;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private float CalculateHealth()
    {
        return (float)_currentHealth / _maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        _healthBarUI.UpdateValue(CalculateHealth());
    }

    public void AddHealth()
    {
        ChangeHealth(10);
    }

    public void RemoveHealth()
    {
        ChangeHealth(-10);
    }
}


