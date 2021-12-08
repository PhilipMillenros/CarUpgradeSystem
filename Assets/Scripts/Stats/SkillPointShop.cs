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
        PlayerClient.OnAnyPlayerLevelUp = OnPlayerLevelUp;
    }

    private void OnPlayerLevelUp(PlayerClient player)
    {
        //Networking implementation
        EnableSkillPointButtons(true);
    }

    public void BuySkill(PlayerClient player, Skill skill)
    {
        player.regeneration += skill.regeneration;
        player.Armor += skill.defense;
        player.Damage += skill.damage;
        player.reloadTime -= skill.fireRate;
        player.transform.localScale += new Vector3(skill.size, skill.size, skill.size);
        player.transform.position += new Vector3(0, skill.size, 0);
        if(player.gameObject.TryGetComponent(out CarMotor motor)) 
            motor.speedMultiplier += skill.speed;
        ConsumeSkillPoint(player);
    }
    private void ConsumeSkillPoint(PlayerClient player)
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
