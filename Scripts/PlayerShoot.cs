
using UnityEngine;
using Mirror;

[RequireComponent(typeof(WeaponManager))]
public class PlayerShoot : NetworkBehaviour
{
    private WeaponManager weaponManager;
    private WeaponData currentWeapon;

    [SerializeField]
    private GameObject startShot;

    void Start()
    {
        weaponManager = GetComponent<WeaponManager>();
    }


    void Update()
    {
        currentWeapon = weaponManager.GetCurrentWeapon();

        if (weaponManager.currentMagazineSize > 0)
        {
            if (currentWeapon.fireRate <= 0f)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    InvokeRepeating("Shoot", 0f, 1f / currentWeapon.fireRate);
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    CancelInvoke("Shoot");
                }
            }
        }
    }

    [Client]
    void Shoot()
    {
        if (!isLocalPlayer || weaponManager.currentMagazineSize == 0)
        {
            return;
        }

        Debug.Log("shoot");
        weaponManager.currentMagazineSize--;

        RaycastHit hit;
        if (Physics.Raycast(startShot.transform.position, startShot.transform.forward, out hit, currentWeapon.range))
        {
            if (hit.collider.tag == "Player")
            {
                CmdPlayerShot(hit.collider.name, currentWeapon.damage, transform.name);
            }

            DestroyableObjects destroyable = hit.transform.GetComponent<DestroyableObjects>();
            if (destroyable != null)
            {
                destroyable.TakeDamage(currentWeapon.damage);
            }

            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            {
                if (enemy != null)
                {
                    enemy.TakeDamage(currentWeapon.damage);
                }
            }

        }
    }

    [Command]
    private void CmdPlayerShot(string playerId, float damage, string sourceId)
    {
        Debug.Log(playerId + "was shot");

        Player player = GameManager.GetPlayer(playerId);
        player.RpcTakeDamage(damage, sourceId);
    }
}
