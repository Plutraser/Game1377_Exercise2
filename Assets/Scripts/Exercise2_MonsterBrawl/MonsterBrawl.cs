using UnityEngine;

public class MonsterBrawl : MonoBehaviour
{
    public int turnCount = 0;

    struct MonsterData
    {
        public string monsterName;
        public int attackStats;
        public int healthStats;
        public int speedStats; // Speed means each time it attacks each round. EX. A monster with speed 2 attacks on turns 2, 4, 6
        public bool isDead;
        public bool isWinner;

    }

    MonsterData[] monsters =
        {
           new MonsterData { monsterName = "Goblin", attackStats = 8, healthStats = 30, speedStats = 1},
           new MonsterData { monsterName = "Orc", attackStats = 20, healthStats = 80, speedStats = 2},
           new MonsterData { monsterName = "Troll", attackStats = 35, healthStats = 200, speedStats = 3},
           new MonsterData { monsterName = "Skeleton", attackStats = 12, healthStats = 50, speedStats = 1},
           new MonsterData { monsterName = "Ogre", attackStats = 50, healthStats = 250, speedStats = 4}

        };

    void Start()
    {
        PrintingMonsterNames();
        FightingSim();
        Debug.Log("All monsters have fought.");
       

    }

    void PrintingMonsterNames()
    {
        foreach (MonsterData m in monsters)
        {
            Debug.Log(m.monsterName + " | HP:" + m.healthStats + " | ATK:" + m.attackStats + " | SPD:" + m.speedStats);
        }
    }

    void FightingSim()
    {
        for (int firstMonster = 0; firstMonster < monsters.Length; firstMonster++)
        {
            for (int secondMonster = firstMonster + 1; secondMonster < monsters.Length; secondMonster++)
            {
                //Making a temp variable for the monsters health stats so they arent permnantly decreased
                int firstMonsterHP = monsters[firstMonster].healthStats;
                int secondMonsterHP = monsters[secondMonster].healthStats;

                //Summary: Fight starts below, each monster attacks each other until someones hp reaches 0. Then the results are displayed
                while (firstMonsterHP > 0 && secondMonsterHP > 0) //This loop will go until one monster dies
                {
                    turnCount += 1;

                    if (turnCount % monsters[firstMonster].speedStats == 0) //This modulo checks if the monsters speed is multiple of the turn so it can attack
                    {
                        secondMonsterHP -= monsters[firstMonster].attackStats;
                    }

                    if (turnCount % monsters[secondMonster].speedStats == 0) //Checks for the second monster as well
                    {
                        firstMonsterHP -= monsters[secondMonster].attackStats;
                    }

                    if (firstMonsterHP <= 0 && secondMonsterHP <= 0) //Checks if both died
                    {
                        DisplayDrawResults(monsters[firstMonster].monsterName, monsters[secondMonster].monsterName, turnCount);
                        //break;
                    }
                    else if (firstMonsterHP <= 0) //First monster died
                    {
                        DisplayResults(monsters[firstMonster].monsterName, monsters[secondMonster].monsterName, turnCount, secondMonsterHP);
                    }
                    else if (secondMonsterHP <= 0) //Second Monster died
                    {
                        DisplayResults(monsters[secondMonster].monsterName, monsters[firstMonster].monsterName, turnCount, firstMonsterHP);
                    }
                }
            }
        }
    }
    void DisplayDrawResults(string firstName, string secondName, int turns)
    {
        Debug.Log(firstName + " vs " + secondName + " | Draw | Turns: " + turns);
        turnCount = 0; //Resets turn count after a battle is done
    }
    void DisplayResults(string loser, string winner, int turns, int HP)
    {
        Debug.Log(loser + " vs " + winner + " | Winner: " + winner + " | Turns: " + turns + " | Remaining HP: " + HP);
        turnCount = 0; //Resets turn count after a battle is done

    }

}

