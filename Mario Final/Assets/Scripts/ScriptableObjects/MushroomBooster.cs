using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MushroomBooster", menuName = "ScriptableObjects/MushroomBooster", order = 5)]
public class MushroomBooster : ScriptableObject
{
    public string _name;
    public GameEvent boosterEvent;

    public Sprite boosterImage;
}
