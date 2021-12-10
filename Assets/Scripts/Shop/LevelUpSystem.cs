using UnityEngine;

public class LevelUpSystem : MonoBehaviour
{
    [SerializeField] private int maxLevel;
    [SerializeField] private int startExpThreshold;
    private int[] expThresholds;

    private void Awake()
    {
        PlayerClient.OnAnyPlayerLevelUp += LevelUpPlayer;
        expThresholds = new int[maxLevel + 1];
        expThresholds[0] = startExpThreshold;
        for (var i = 1; i < maxLevel; i++)
            expThresholds[i] += expThresholds[i - 1] + CalculateExpThreshold(expThresholds[i - 1], i);
    }

    private void LevelUpPlayer(PlayerClient player)
    {
        player.skillPoints++;
        if (player.level == maxLevel)
            return;
        player.level++;
        player.experienceThreshold = expThresholds[player.level];
    }

    private int CalculateExpThreshold(int expThreshold, int index)
    {
        return expThreshold / 2;
    }
}