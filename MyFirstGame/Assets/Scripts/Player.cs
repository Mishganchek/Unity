using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private HealthBar _healthBar;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public event UnityAction HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void ChangeHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
        HealthChanged.Invoke();
    }

    public void Heal(int count)
    {
        ChangeHealth(count);
    }

    public void Damage(int count)
    {
        ChangeHealth(count);
    }
}


