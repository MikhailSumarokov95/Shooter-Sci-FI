using System;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public Action OnDead;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;

    public int CurrentHealth 
    { 
        get 
        { 
            return currentHealth; 
        } 
        set 
        { 
            currentHealth = value;
            healthBar.Health = currentHealth;
        } 
    }

    public void TakeDamage(int damage)
    {
        var remainingHealth = CurrentHealth - damage;
        if (remainingHealth <= 0) OnDead();
        else CurrentHealth = remainingHealth;
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
