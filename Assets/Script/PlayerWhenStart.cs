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

    [System.Obsolete]
    private void Start()
    {
        GenMap.instance.createList(levelNumber, level);
    }

    public void setNumber(int levelA, Vector2 numberLevel, int numberOfcloneBrick)
    {
        level = levelA;
        levelNumber = numberLevel;
        numberOfClone = numberOfcloneBrick;
    }
}
