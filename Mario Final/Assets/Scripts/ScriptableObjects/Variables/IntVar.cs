using UnityEngine;

[CreateAssetMenu(fileName = "IntVar", menuName = "ScriptableObjects/IntVar", order = 2)]
public class IntVar : ScriptableObject
{
    private int _value = 0;
    public int Value {
        get {
            return _value;
        }
    }

    public void Set(int var)
    {
        _value = var;
    }

    public void Set(IntVar var)
    {
        _value = var.Value;
    }

    public void Add(int var)
    {
        _value += var;
    }

    public void Add(IntVar var)
    {
        _value += var.Value;
    }
}
