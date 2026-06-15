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
    struct MonsterData
    {
        public string monsterName;
        public int attackStats;
        public int healthStats;
        public int speedStats; // Speed means each time it attacks each round. EX. A monster with speed 2 attacks on turns 2, 4, 6

    }
    void Start()
    {
        MonsterData Goblin = new MonsterData();
        Goblin.monsterName = "Goblin";
        Goblin.attackStats = 8;
        Goblin.healthStats = 30;
        Goblin.speedStats = 1;

        MonsterData Orc = new MonsterData();
        Orc.monsterName = "Orc";
        Orc.attackStats = 20;
        Orc.healthStats = 80;
        Orc.speedStats = 2;

        MonsterData Troll = new MonsterData();
        Troll.monsterName = "Troll";
        Troll.attackStats = 35;
        Troll.healthStats = 200;
        Troll.speedStats = 3;

        MonsterData Skeleton = new MonsterData();
        Skeleton.monsterName = "Skeleton";
        Skeleton.attackStats = 12;
        Skeleton.healthStats = 50;
        Skeleton.speedStats = 1;

        MonsterData Ogre = new MonsterData();
        Ogre.monsterName = "Ogre";
        Ogre.attackStats = 50;
        Ogre.healthStats = 250;
        Ogre.speedStats = 4;
    }
}

