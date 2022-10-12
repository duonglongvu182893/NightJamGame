using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWhenStart : MonoBehaviour
{
    public static PlayerWhenStart instance;

    public int currentLevel;

    private void Awake()
    {
        instance = this;
    }

    public int numberOfClone;

    public int level;

    public Vector2 levelNumber;

    public GameObject[] levelOj;
    public Level[] levelPlayer;

    [System.Obsolete]
    private void Start()
    {
        //Level = PlayerPrefs.SetInt
        setLevel(level);
    }
    private void Update()
    {
        //currentLevel = PlayerPrefs.GetInt("Level");
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
        for(int i= 0; i < levelOj.Length; i++)
        {
            if (i == a)
            {
                levelOj[i].SetActive(true);
            }
            else
            {
                levelOj[i].SetActive(false);
            }
        }
        GenMap.instance.createList(levelPlayer[a].size, levelPlayer[a].numberOfLevel);
        numberOfClone = levelPlayer[a].numberBrickCanClone;
        
    }

    [System.Obsolete]
    public IEnumerator destroyOldPlatform(int level)
    {

        yield return new WaitForSeconds(0.5f);
        GenMap.instance.DestroyMap();
        setLevel(level);
        //UIController.instance.reload();

    }


}
