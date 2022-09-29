using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWhenStart : MonoBehaviour
{
    public static PlayerWhenStart instance;

    private void Awake()
    {
        instance = this;
    }

    public int numberOfClone;

    public int level;

    public Vector2 levelNumber;

    public Level[] levelPlayer;

    [System.Obsolete]
    private void Start()
    {
        setLevel(level);
    }

    public void setNumber(int levelA, Vector2 numberLevel, int numberOfcloneBrick)
    {
        level = levelA;
        levelNumber = numberLevel;
        numberOfClone = numberOfcloneBrick;
    }

    [System.Obsolete]
    public void setLevel(int level)
    {
        int a = level - 1;
        GenMap.instance.createList(levelPlayer[a].size, levelPlayer[a].numberOfLevel);
        numberOfClone = levelPlayer[a].numberBrickCanClone;
    }
}
