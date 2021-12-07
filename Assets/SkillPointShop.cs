using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointShop : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    public void BuySkill(PlayerStats player, Skill skill)
    {
        player.regeneration += skill.regeneration;
        player.Armor += skill.defense;
        player.Damage += skill.damage;
        player.speed += skill.speed;
        player.reloadTime -= skill.fireRate;
        player.transform.localScale += new Vector3(skill.size, skill.size, skill.size);
        ConsumeSkillPoint(player);
    }
    
    private void ConsumeSkillPoint(PlayerStats player)
    {
        player.skillPoints--;
        if (player.skillPoints <= 0)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }

    public void EnableSkillPointButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
    }
}
