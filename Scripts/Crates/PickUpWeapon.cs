using System.Collections;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField]
    WeaponData theWeapon;

    [SerializeField]
    private float respawndelay = 2f;

    private GameObject pickUpGraphic;
    private bool canPickUp; 

    void Start()
    {
        ResetWeapon();
    }

    void ResetWeapon()
    {
        pickUpGraphic = Instantiate(theWeapon.graphic, transform);
        pickUpGraphic.transform.position = transform.position;
        canPickUp = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canPickUp)
        {
            WeaponManager weaponManager = other.GetComponentInParent<WeaponManager>();
            EquipNewWeapon(weaponManager);
        }
    }

    void EquipNewWeapon(WeaponManager weaponManager)
    {
        Destroy(weaponManager.GetCurrentGraphics().gameObject);
        weaponManager.EquipWeapon(theWeapon);

        canPickUp = false;
        Destroy(pickUpGraphic);
        StartCoroutine(DelayResetWeapon());
    }

    IEnumerator DelayResetWeapon()
    {

        yield return new WaitForSeconds(respawndelay);
        ResetWeapon();
    }

}
