using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrel;

    public void Fire(Vector3 direction)
    {
        Instantiate(bullet, barrel.position, Quaternion.LookRotation(direction));
    }
}
