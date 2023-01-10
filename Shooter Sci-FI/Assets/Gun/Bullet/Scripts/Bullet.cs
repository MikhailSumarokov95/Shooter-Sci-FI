using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Rigidbody bulletRb;

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        bulletRb.AddForce(transform.forward * speed, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
