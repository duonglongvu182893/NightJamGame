using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class Level : ScriptableObject
{
    public int numberOfLevel;
    public string des;
    public Vector2 size;
    public int numberBrickCanClone;
}
