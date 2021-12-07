using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float size;
    public float health;
    public float damage;
    public float fireRate;
    public float defense;
    public float speed;
    public float regeneration;
    public int skillLevel = 1;
    public int maxSkillLevel;
    public TextMeshProUGUI skillLevelText;
    [SerializeField] private PlayerStats buyer; //Temp for networking
    private SkillPointShop shop;
    
    private void Awake()
    {
        shop = GetComponentInParent<SkillPointShop>();
        skillLevelText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void BuySkill()
    {
        shop.BuySkill(buyer, this);
        Debug.Log("yes");
        skillLevelText.text = $"Lv. {++skillLevel}";
    }
}
