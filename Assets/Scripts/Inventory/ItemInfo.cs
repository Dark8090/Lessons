using UnityEngine;

[CreateAssetMenu(fileName = "Item_",menuName = "Create Item",order = 51)]
public class ItemInfo : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;

    public string Name => _name;
    public Sprite Sprite => _sprite;

    public ItemInfo(string name, Sprite sprite)
    {
        _name = name;
        _sprite = sprite;
    }
}
