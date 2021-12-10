using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vehicle;

public class SkillPointShop : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI skillPointsText;

    private void Start()
    {
        PlayerClient.OnAnyPlayerLevelUp += OnPlayerLevelUp;
    }

    private void OnPlayerLevelUp(PlayerClient player)
    {
        //Networking implementation
        EnableSkillPointButtons(true);
        UpdateLevelText(player);
    }

    private void ConsumeSkillPoint(PlayerClient player)
    {
        player.skillPoints--;
        if (player.skillPoints <= 0) EnableSkillPointButtons(false);
        if (tutorial != null)
            tutorial.SetActive(false);
        UpdateLevelText(player);
    }

    public void EnableSkillPointButtons(bool enable)
    {
        for (var i = 0; i < buttons.Length; i++) buttons[i].gameObject.SetActive(enable);
    }

    private void UpdateLevelText(PlayerClient player)
    {
        //Networking
        levelText.SetText($"Level: {player.level + 1}");
        skillPointsText.SetText($"Skill Points: {player.skillPoints}");
    }

    public void BuySkill(PlayerClient player, Skill skill)
    {
        player.regeneration += skill.regeneration;
        player.Armor += skill.defense;
        player.Damage += skill.damage;
        player.reloadTime -= skill.fireRate;
        player.transform.localScale += new Vector3(skill.size, skill.size, skill.size);
        player.transform.position += new Vector3(0, skill.size, 0);
        if (player.gameObject.TryGetComponent(out CarMotor motor))
            motor.speedMultiplier += skill.speed;
        ConsumeSkillPoint(player);
    }
}