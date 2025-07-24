using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    //public List<QuestKill> questKills = new List<QuestKill>();

    private List<QuestKill> killList = new List<QuestKill>();
    
    public IReadOnlyList<QuestKill> KillList => killList.AsReadOnly(); // ii


    public void AddQuestKill(QuestKill questKill)
    {
        killList.Add(questKill);
    }

    public void RemoveQuestKill(QuestKill questKill)
    {
        killList.Remove(questKill);

    }

}
