
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private Player player;
    private WeaponManager weaponManager;

    [SerializeField]
    private RectTransform healthBarFill;

    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Text grenadeText;
    [SerializeField]
    public GameObject scoreBoard;

    public void SetPlayer(Player _player)
    {
        player = _player;
        weaponManager = player.GetComponent<WeaponManager>();
    }

    void Update()
    {
        SetHealthAmount(player.GetHealthPct());
        SetAmmoAmount(weaponManager.currentMagazineSize);
        SetGrenadeAmmount(weaponManager.numGrenade);
        if (player.isDead)
        {
            scoreBoard.SetActive(true);
        }
        else
        {
            scoreBoard.SetActive(false);
        }
    }

    void SetHealthAmount(float _amount)
    {
        healthBarFill.localScale = new Vector3(1f, _amount, 1f);
    }

    void SetAmmoAmount(int _amount)
    {
        ammoText.text = _amount.ToString();
    }

    void SetGrenadeAmmount(int _amount)
    {
        grenadeText.text = _amount.ToString();
    }
}
