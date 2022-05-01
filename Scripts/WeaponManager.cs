
using UnityEngine;
using Mirror;

public class WeaponManager : NetworkBehaviour
{
    [SerializeField]
    private WeaponData primaryWeapon;

    private WeaponData currentWeapon;
    private WeaponGraphics currentGraphics;

    [SerializeField]
    private Transform weaponHolder;

    [HideInInspector]
    public int currentMagazineSize;
    [HideInInspector]
    public int numGrenade = 4;

    void Start()
    {
        EquipWeapon(primaryWeapon);
    }

    public WeaponData GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public WeaponGraphics GetCurrentGraphics()
    {
        return currentGraphics;
    }

    public void EquipWeapon(WeaponData _weapon)
    {
        currentWeapon = _weapon;
        currentMagazineSize = _weapon.magazineSize;

        GameObject weaponInst = Instantiate(_weapon.graphic, weaponHolder.position, weaponHolder.rotation);
        weaponInst.transform.SetParent(weaponHolder);

        currentGraphics = weaponInst.GetComponent<WeaponGraphics>();

        if (currentGraphics == null)
        {
            Debug.LogError("Pas de script WeaponGraphics sur l'arme : " + weaponInst.name);
        }
    }
}
