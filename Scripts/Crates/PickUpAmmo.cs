
using UnityEngine;

public class PickUpAmmo : MonoBehaviour
{
    [SerializeField]
    private GameObject ammoGraphic;

    [SerializeField] private bool isGrenade = false;
    [SerializeField]
    private float respawndelay = 2f;

    private GameObject pickUpGraphic;
    private bool canPickUp;

    void Start()
    {
        canPickUp = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canPickUp)
        {
            WeaponManager weaponManager = other.GetComponentInParent<WeaponManager>();
            if (isGrenade)
            {
                weaponManager.numGrenade += 1;
            }
            else
            {
                weaponManager.currentMagazineSize += 5;
            }
            PickAmmos();
        }
    }

    void PickAmmos()
    {
        canPickUp = false;
        Destroy(ammoGraphic);
    }
}
