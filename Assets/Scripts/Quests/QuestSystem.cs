using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestSystem : MonoBehaviour
{
    [SerializeField] private int myMoney;
    [SerializeField] private Text textMoney;

    [Header("Set kill quest")]
    [SerializeField] private TypeMobs typeMobs;
    [SerializeField] private int countToKill;
    [SerializeField] private int reward;


    private QuestList questList;

    [Header("Show Counts")]
    [SerializeField] private int countZombie = 0;
    [SerializeField] private int countGoblins = 0;
    [SerializeField] private int countSkeletons = 0;

    private Dictionary<TypeMobs, int> killCounters = new Dictionary<TypeMobs, int>();

    private List<QuestKill> completeQuest = new List<QuestKill>();   
    


    private void Start()
    {
        questList = GetComponent<QuestList>();
        textMoney.text = myMoney.ToString();

        killCounters[TypeMobs.Goblins] = 0;
        killCounters[TypeMobs.Skeletons] = 0;
        killCounters[TypeMobs.Zombies] = 0;
    }

    private void Update()
    {
        // Проверка на выполнение квеста
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    for (int i = 0; i < questList.KillList.Count; i++)
        //    {
        //        switch (questList.KillList[i].TypeMobs)
        //        {
        //            case TypeMobs.Zombies:
        //                questList.KillList[i].CheckCompleteQuest(countZombie);
        //                if (questList.KillList[i].IsQuestCompleted == true)
        //                {

        //                    myMoney += questList.KillList[i].Reward;
        //                    textMoney.text = myMoney.ToString();
        //                    countZombie -= questList.KillList[i].KillCount;
        //                    //questList.RemoveQuestKill(questKill[]);
        //                    questList.RemoveQuestKill(questList.KillList[i]);

        //                }
        //                break;
        //            case TypeMobs.Goblins:
        //                questList.KillList[i].CheckCompleteQuest(countGoblins);
        //                if (questList.KillList[i].IsQuestCompleted == true)
        //                {
        //                    myMoney += questList.KillList[i].Reward;
        //                    textMoney.text = myMoney.ToString();
        //                    countGoblins -= questList.KillList[i].KillCount;
        //                    //questList.RemoveQuestKill(i);
        //                    questList.RemoveQuestKill(questList.KillList[i]);
        //                }
        //                break;
        //            case TypeMobs.Skeletons:
        //                questList.KillList[i].CheckCompleteQuest(countSkeletons);
        //                if (questList.KillList[i].IsQuestCompleted == true)
        //                {
        //                    myMoney += questList.KillList[i].Reward;
        //                    textMoney.text = myMoney.ToString();
        //                    countSkeletons -= questList.KillList[i].KillCount;
        //                    //questList.RemoveQuestKill(i);
        //                    questList.RemoveQuestKill(questList.KillList[i]);

        //                }
        //                break;
        //            default:
        //                print("Моб не найден");
        //                break;
        //        }
        //        break;
        //    }
        //}

        // II Version
        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (var quest in questList.KillList)
            {
                if (killCounters[quest.TypeMobs] >= quest.KillCount && !quest.IsQuestCompleted)
                {
                    quest.CheckCompleteQuest(killCounters[quest.TypeMobs]);

                    if (quest.IsQuestCompleted)
                    {
                        myMoney += quest.Reward;
                        textMoney.text = myMoney.ToString();
                        killCounters[quest.TypeMobs] -= quest.KillCount;
                        //test
                        if (quest.TypeMobs == TypeMobs.Goblins) countGoblins = killCounters[quest.TypeMobs];
                        if (quest.TypeMobs == TypeMobs.Zombies) countZombie = killCounters[quest.TypeMobs];
                        if (quest.TypeMobs == TypeMobs.Skeletons) countSkeletons = killCounters[quest.TypeMobs];

                        //questList.RemoveQuestKill(quest);
                        completeQuest.Add(quest);
                    }
                }
            }

            foreach (var quest in completeQuest)
            {
                questList.RemoveQuestKill(quest);
            }
        }



        // Добавляем квесты
        if (Input.GetKeyDown(KeyCode.G))
        {
            QuestKill questKill = new QuestKill(typeMobs, countToKill, reward);
            questList.AddQuestKill(questKill);
            questKill = null;
            print(questList.KillList.Count);
        }
    }


    // Buttons
    public void AddCountZombie()
    {
        AddKill(TypeMobs.Zombies);
        countZombie++;
    }
    public void AddCountGoblins()
    {
        AddKill(TypeMobs.Goblins);
        countGoblins++;
    }
    public void AddCountSkeletons()
    {
        AddKill(TypeMobs.Skeletons);
        countSkeletons++;
    }

    private void AddKill(TypeMobs type)
    {
        if (killCounters.ContainsKey(type))
        {
            killCounters[type]++;
        }
        else
        {
            print("Mob not found");

        }
    }
}
