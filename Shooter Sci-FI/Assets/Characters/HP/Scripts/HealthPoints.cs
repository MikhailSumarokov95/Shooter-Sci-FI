using System;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public Action OnDead;
    [SerializeField] private int maxHealth;
    private HealthBar _healthBar;

    [SerializeField] private int currentHealth;
    public int CurrentHealth 
    { 
        get 
        { 
            return currentHealth; 
        } 
        set 
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            _healthBar.Health = currentHealth;
        } 
    }

    private void Start()
    {
        _healthBar = transform.GetComponentInChildren<HealthBar>();
        _healthBar.SetMaxHealth(maxHealth);
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        var remainingHealth = CurrentHealth - damage;
        if (remainingHealth <= 0) ToDead();
        CurrentHealth = remainingHealth;
    }

    public void TakeHealth(int health)
    {
        var remainingHealth = CurrentHealth + health;
        if (remainingHealth >= maxHealth) CurrentHealth = maxHealth;
        else CurrentHealth = remainingHealth;
    }

    private void ToDead()
    {
        OnDead?.Invoke();
    }
}
