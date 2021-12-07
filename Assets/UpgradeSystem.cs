using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    private int[] expThresholds;
    [SerializeField] private int maxLevel;
    [SerializeField] private int startExpThreshold;
    private void Awake()
    {
        PlayerStats.OnAnyPlayerLevelUp += LevelUpPlayer;
        expThresholds = new int[maxLevel + 1];
        expThresholds[0] = startExpThreshold;
        for (int i = 1; i < maxLevel; i++)
        {
            expThresholds[i] += expThresholds[i - 1] + CalculateExpThreshold(expThresholds[i - 1], i);
        }
    }
    private void LevelUpPlayer(PlayerStats player)
    {
        player.skillPoints++;
        if (player.level == maxLevel)
            return;
        player.level++;
        player.experienceThreshold = expThresholds[player.level];
        Debug.Log("Level up to: " + player.level);
    }
    private int CalculateExpThreshold(int expThreshold, int index)
    {
        return (expThreshold / 2);
    }
}
