
using UnityEngine;


public class GrenadeLauncher : MonoBehaviour
{
    WeaponManager weaponManager;
    public float throwForce = 40f;
    public GameObject grenadePrefab;

    private void Awake()
    {
        weaponManager = GetComponentInParent<WeaponManager>();
    }
    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && weaponManager.numGrenade > 0)
        {
            ThrowGrenade();
        }
    }//Update

    void ThrowGrenade()
    {
        weaponManager.numGrenade--;
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

}
