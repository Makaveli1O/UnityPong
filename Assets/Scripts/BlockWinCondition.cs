using UnityEngine;

public class BlockWinCondition : IGameWinCondition
{
    public bool IsWinConditionMet()
    {
        return GameObject.FindGameObjectsWithTag("Block").Length == 0;
    }
}