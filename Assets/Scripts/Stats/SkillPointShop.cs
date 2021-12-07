using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointShop : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject tutorial;
    private void Awake()
    {
        PlayerStats.OnAnyPlayerLevelUp = OnPlayerLevelUp;
    }

    private void OnPlayerLevelUp(PlayerStats player)
    {
        //Networking implementation
        EnableSkillPointButtons(true);
    }

    public void BuySkill(PlayerStats player, Skill skill)
    {
        player.regeneration += skill.regeneration;
        player.Armor += skill.defense;
        player.Damage += skill.damage;
        player.speed += skill.speed;
        player.reloadTime -= skill.fireRate;
        player.transform.localScale += new Vector3(skill.size, skill.size, skill.size);
        player.transform.position += new Vector3(0, skill.size, 0);
        ConsumeSkillPoint(player);
    }
    private void ConsumeSkillPoint(PlayerStats player)
    {
        player.skillPoints--;
        if (player.skillPoints <= 0)
        {
            EnableSkillPointButtons(false);
        }
        if(tutorial != null)
            tutorial.SetActive(false);
    }
    public void EnableSkillPointButtons(bool enable)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(enable);
        }
    }
}
