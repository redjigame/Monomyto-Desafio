
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreBoardItem : MonoBehaviour
{
    [SerializeField]
    Text usernameText;

    [SerializeField]
    Text killsText;

    [SerializeField]
    Text deathsText;

    public void Setup(Player player)
    {
        usernameText.text = player.username;
        killsText.text = "Kills : " + Player.kills;
        deathsText.text = "Score : " + Player.score;
    }
}
