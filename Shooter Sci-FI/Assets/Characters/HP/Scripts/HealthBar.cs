using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    public int Health 
    {
        get
        {
            return Health;
        }
        set 
        {
            Health = value;
            healthSlider.value = Health;
        }
    }

    private void Update()
    {
        var v = Camera.main.transform.position - transform.position;
        v.x = v.z = 0f;
        transform.LookAt(Camera.main.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}
