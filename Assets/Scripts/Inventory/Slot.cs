using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image image;
    public bool IsEmpty { get; set; } = false;
    
    public void SetSlot(Sprite sprite)
    {
        image.sprite = sprite;
        IsEmpty = true;
    }

    public void RemoveSlot()
    {
        image.sprite = null;
        IsEmpty = false;
    }
}
