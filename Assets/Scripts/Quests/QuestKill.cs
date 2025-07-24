using System;
using UnityEngine;

[Serializable]
public class QuestKill : QuestBase
{
    [SerializeField] private int killCount = 0;
    [SerializeField] private TypeMobs typeMobs;
    [SerializeField] private bool isQuestCompleted = false;

    public TypeMobs TypeMobs { get => typeMobs;  }
    public int KillCount => killCount;
    public bool IsQuestCompleted { get => isQuestCompleted; }


    public QuestKill(TypeMobs typeMobs, int killCount, int reward)
    {
        this.typeMobs = typeMobs;
        this.killCount = killCount;
        Reward = reward;
    }

    public void CheckCompleteQuest(int currentKillCount)
    {
        if (currentKillCount >= killCount && isQuestCompleted != true)
        {
            isQuestCompleted = true;
        }
    }


}


