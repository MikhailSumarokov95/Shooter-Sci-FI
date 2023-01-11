using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Gun _gun;

    private void Start()
    {
        _gun = transform.GetComponentInChildren<Gun>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Fire();
    }

    private void Fire()
    {
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 50f);
        Vector3 direction;
        if (hit.collider != null) direction = hit.point;
        else direction = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 50f));
        _gun.Fire(direction);
    }
}
