/*
 * Assignment: Monster Brawl
 * 
 * Objective:
 * Implement a battle simulation in the Start method. You are given five monsters, each with a name, attack stat, health stat and speed stat. 
 *      Attack determines how much damage it does when it attacks. Health determines how much damage it can take before dying.
 *      Speed determines how often a monster attacks (1 means it attacks every turn, 2 means every 2 turns, 3 means every 3 turns, and so on)
 *  
 *  Print the roster
 *      1. Loop through the monsters and print each one in this exact format:
 *      Goblin | ATK: 8 | HP: 30 | SPD: 1
 *  
 *  Simulate every unique 1v1 fight
 *      1. Every monster should fight every other monster exactly once.
 *          Goblin vs Orc and Orc vs Goblin are the same fight — only one should occur.
 *      2. A monster should never fight itself.
 *      3. In each fight, both monsters attack simultaneously each turn.
 *      4. A monster only attacks on turns that are a multiple of its speed.
 *          E.g. a monster with speed 2 attacks on turns 2, 4, 6, etc. A monster with speed 3 attacks on turns 3, 6, 9, etc.
 *      5. The fight ends when one or both monsters reach 0 HP or below.
 *      6. Print each fight result in this exact format:
 *          Goblin vs Orc | Winner: Orc | Turns: 12 | Remaining HP: 24
 *      7. If both monsters die on the same turn, print:
 *          Goblin vs Orc | Draw | Turns: 8
 *  Instructions:
 *      Attach the script to any active GameObject in your Unity scene.
 *      Observe the results in the Console after hitting the Play button.
 */

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
           new MonsterData { monsterName = "Goblin", attackStats = 8, healthStats = 30, speedStats = 1, isDead = false, isWinner = false},
           new MonsterData { monsterName = "Orc", attackStats = 20, healthStats = 80, speedStats = 2, isDead = false, isWinner = false},
           new MonsterData { monsterName = "Troll", attackStats = 35, healthStats = 200, speedStats = 3, isDead = false, isWinner = false},
           new MonsterData { monsterName = "Skeleton", attackStats = 12, healthStats = 50, speedStats = 1, isDead = false, isWinner = false},
           new MonsterData { monsterName = "Ogre", attackStats = 50, healthStats = 250, speedStats = 4, isDead = false, isWinner = false}

        };

    void Start()
    {
        PrintingMonsterNames();
        FightingSim();
        Debug.Log("All monsters have fought.");
       

        
        //Debug.Log(monsters[randomNumber].monsterName);
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
        int firstMonster = Random.Range(0, monsters.Length);
        int secondMonster = Random.Range(0, monsters.Length);

        
        while (firstMonster == secondMonster) //This cycles the second monster to make sure it isnt the same as the first monster
        {
            secondMonster = Random.Range(0, monsters.Length);
        }

        

        while (monsters[firstMonster].isDead == false && monsters[secondMonster].isDead == false) //This loop will go until one monster dies
        {
            turnCount += 1;
            Debug.Log(turnCount);

            if (turnCount % monsters[firstMonster].speedStats == 0) //This modulo checks if the monsters speed is multiple of the turn so it can attack
            {
                Debug.Log(monsters[firstMonster].monsterName + " attacks for " + monsters[firstMonster].attackStats);
                
                monsters[secondMonster].healthStats -= monsters[firstMonster].attackStats;

                Debug.Log(monsters[secondMonster].monsterName + " has " + monsters[secondMonster].healthStats + " HP remaining");
            }

            if (turnCount % monsters[secondMonster].speedStats == 0) //Checks for the second monster as well
            {

                Debug.Log(monsters[secondMonster].monsterName + " attacks for " + monsters[secondMonster].attackStats);

                monsters[firstMonster].healthStats -= monsters[secondMonster].attackStats;

                Debug.Log(monsters[firstMonster].monsterName + " has " + monsters[firstMonster].healthStats + " HP remaining");
            }

            if (monsters[firstMonster].healthStats <= 0 && monsters[secondMonster].healthStats <= 0) //Checks if both died
            {
                monsters[firstMonster].isDead = true;
                monsters[secondMonster].isDead = true;
                DisplayDrawResults(monsters[firstMonster].monsterName, monsters[secondMonster].monsterName, turnCount);
            }
            else if (monsters[firstMonster].healthStats <= 0) 
            {
                monsters[firstMonster].isDead = true;
                monsters[secondMonster].isWinner = true;
                DisplayResults(monsters[firstMonster].monsterName, monsters[secondMonster].monsterName, turnCount, monsters[secondMonster].healthStats);
            }
            else if (monsters[secondMonster].healthStats <= 0)
            {
                monsters[secondMonster].isDead = true;
                monsters[firstMonster].isWinner = true;
                DisplayResults(monsters[secondMonster].monsterName, monsters[firstMonster].monsterName, turnCount, monsters[firstMonster].healthStats);
            }


        }

    }
    void DisplayDrawResults(string firstName, string secondName, int turns)
    {
        Debug.Log(firstName + " vs " + secondName + " | Draw | Turns: " + turns);
    }
    void DisplayResults(string loser, string winner, int turns, int HP)
    {
        Debug.Log(loser + " vs " + winner + " | Winner: " + winner + " | Turns: " + turns + " | Remaining HP: " + HP);
    }

}

