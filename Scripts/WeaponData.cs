
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponData", menuName ="Desafio/Weapon Data")]
public class WeaponData: ScriptableObject
{
    public string name = "rifle";
    public float damage = 10f;
    public float range = 100f;

    public float fireRate = 10f;

    public int magazineSize = 10;

    public GameObject graphic;
}
