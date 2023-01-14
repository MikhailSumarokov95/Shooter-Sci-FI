using UnityEngine;
using System;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private WeaponIcon[] weaponsIcon;
    [SerializeField] private Progress.Weapon[] startWeapon;

    private void Start()
    {
        SaveStartWeaponInStorage();
    }

    public void BuyWeapon(int weaponNumberIcon)
    {
        Progress.SaveWeapon(weaponsIcon[weaponNumberIcon].Weapon);
    }

    private void SaveStartWeaponInStorage()
    {
        foreach (var weapon in startWeapon)
            Progress.SaveWeapon(weapon);
    }

    [ContextMenu("ClearProgressAllWeapons")]
    private void ClearProgressAllWeapons()
    {
        foreach (Progress.Weapon weapon in Enum.GetValues(typeof(Progress.Weapon)))
            Progress.DeleteWeapon(weapon);
    }
}
