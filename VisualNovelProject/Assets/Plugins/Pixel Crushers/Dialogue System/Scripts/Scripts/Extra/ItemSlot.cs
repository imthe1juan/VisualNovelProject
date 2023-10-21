using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Sprite nullSprite;
    Image slotImage;
    void Awake()
    {
        slotImage = GetComponent<Image>();
    }
    public void NullSlot()
    {
        slotImage.sprite = nullSprite;
    }
    public void UpdateSlot(Sprite sprite)
    {
        slotImage.sprite = sprite;
    }
}
