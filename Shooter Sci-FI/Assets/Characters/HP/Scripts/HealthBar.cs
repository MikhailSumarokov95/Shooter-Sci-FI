using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    private float _health;
    public float Health 
    {
        get
        {
            return _health;
        }
        set 
        {
            _health = value;
            healthSlider.value = _health;
        }
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
    }

    private void Update()
    {
        LookAtCamera();
    }

    private void LookAtCamera()
    {
        var v = transform.position - Camera.main.transform.position;
        v.x = v.z = 0f;
        transform.LookAt(Camera.main.transform.position - v);
    }
}
