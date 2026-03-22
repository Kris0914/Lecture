using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PartType
{
    FORCEDIR,
    TIMESTOP,
    REFLECT,
    BLACKHOLE,
    SLOWFIELD
}

public enum ItemType
{
    HP,
    FORCE,
    SHIELD
}

public enum BulletStatus
{
    NONE,
    FORCE,
    REFLECT,
    NONEFORCE
}

public enum EnemyType
{
    SCOUT,
    FIGHTER,
    HEAVY,
    INTERCPTOR,
    BOMBER,
    ASTEROID,
    BOSS1,
    BOSS2,
    BOSS3
}

public class DataController : MonoBehaviour
{
    public static DataController instance;

    void Awake()
    {
        instance = this;
        //Load();
    }

    public int[] StageEnemyNum = new int[] { 20, 30, 40 };
    public int[] StageEnemy = new int[] { 3, 5, 6 };
    public int[] EnemyHp = new int[] { 20, 40, 80, 15, 60, 100, 100, 100, 100 };
    public int[] EnemyScore = new int[] { 20, 40, 80, 15, 60, 100, 100, 200, 300 };
    public int[] EnemyDamage = new int[] { 10, 20, 30, 40, 50, 60, 50, 50, 50 };
    public int[] EnemyCoin = new int[] { 10, 20, 30, 40, 50, 60, 100, 500, 1000 };
    public int[] partsCost = new int[] { 200, 400, 600, 800, 1000 };
    public string[] partName = new string[] { "강제유도", "시간정지", "공격반사", "블랙홀", "감속장" };
    public float[] partSlotCoolDown = new float[] { 5.0f, 5.0f, 30.0f };

    public int coin;
    public int stage;
    public int score;
    public int part1;
    public int part2;
    public int part3;
    public int part4;
    public int part5;
    public int partSlot1;
    public int partSlot2;

    List<Rank> scores = new List<Rank>();
    public class Rank
    {
        public string id;
        public int score;

        public string getRank()
        {
            return id + " : " + score;
        }
    }

    public void Save(int _coin, int _stage, int _part1, int _part2, int _part3, int _part4, int _part5, int _partSlot1, int _partSlot2, int _score)
    {
        PlayerPrefs.SetInt("Coin", _coin);
        PlayerPrefs.SetInt("Stage", _stage);
        PlayerPrefs.SetInt("part1", _part1);
        PlayerPrefs.SetInt("part2", _part2);
        PlayerPrefs.SetInt("part3", _part3);
        PlayerPrefs.SetInt("part4", _part4);
        PlayerPrefs.SetInt("part5", _part5);
        PlayerPrefs.SetInt("partSlot1", _partSlot1);
        PlayerPrefs.SetInt("partSlot2", _partSlot2);
        PlayerPrefs.SetInt("score", _score);
    }

    public void Save(int _coin, int _score, int _stage)
    {
        PlayerPrefs.SetInt("Coin", _coin);
        PlayerPrefs.SetInt("Stage", _stage);
        PlayerPrefs.SetInt("score", _score);
    }

    public void Load()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        stage = PlayerPrefs.GetInt("Stage", 0);
        part1 = PlayerPrefs.GetInt("part1", 0);
        part2 = PlayerPrefs.GetInt("part2", 0);
        part3 = PlayerPrefs.GetInt("part3", 0);
        part4 = PlayerPrefs.GetInt("part4", 0);
        part5 = PlayerPrefs.GetInt("part5", 0);
        partSlot1 = PlayerPrefs.GetInt("partSlot1", -1);
        partSlot2 = PlayerPrefs.GetInt("partSlot2", -1);
        score = PlayerPrefs.GetInt("score", 0);
    }

    public void SaveInit()
    {
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("Stage", 0);
        PlayerPrefs.SetInt("part1", 0);
        PlayerPrefs.SetInt("part2", 0);
        PlayerPrefs.SetInt("part3", 0);
        PlayerPrefs.SetInt("part4", 0);
        PlayerPrefs.SetInt("part5", 0);
        PlayerPrefs.SetInt("partSlot1", -1);
        PlayerPrefs.SetInt("partSlot2", -1);
        PlayerPrefs.SetInt("score", 0);
    }

    public void AddScore(Rank score)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
