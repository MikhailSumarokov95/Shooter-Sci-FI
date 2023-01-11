using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrel;
    [SerializeField] private float postShotDelay;
    [SerializeField] private int magazineSize;
    [SerializeField] private float timeReloading;
    private bool _isPostShotDelay;
    private bool _isReloading;
    private int _restOfBulletinMagazine;

    private void Start()
    {
        _restOfBulletinMagazine = magazineSize;
    }

    public void Fire(Vector3 direction)
    {
        if (_isReloading) return;
        if (_restOfBulletinMagazine == 0) StartCoroutine(Reloading());
        if (_isPostShotDelay) return;
        Instantiate(bullet, barrel.position, Quaternion.LookRotation(direction - transform.position));
        _restOfBulletinMagazine--;
        StartCoroutine(WaitPostShotDelay());
    }

    private IEnumerator WaitPostShotDelay()
    {
        _isPostShotDelay = true;
        yield return new WaitForSecondsRealtime(postShotDelay);
        _isPostShotDelay = false;
    }

    private IEnumerator Reloading()
    {
        _isReloading = true;
        yield return new WaitForSecondsRealtime(timeReloading);
        _isReloading = false;
        _restOfBulletinMagazine = magazineSize;
    }
}