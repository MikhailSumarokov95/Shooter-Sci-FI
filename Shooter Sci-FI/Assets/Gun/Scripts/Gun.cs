using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrel;
    [SerializeField] private float postShotDelay;
    [SerializeField] private bool isPostShotDelay;

    public void Fire(Vector3 direction)
    {
        if (isPostShotDelay) return;
        Instantiate(bullet, barrel.position, Quaternion.LookRotation(direction - transform.position));
        StartCoroutine(WaitPostShotDelay());
    }

    private IEnumerator WaitPostShotDelay()
    {
        isPostShotDelay = true;
        yield return new WaitForSecondsRealtime(postShotDelay);
        isPostShotDelay = false;
    }
}