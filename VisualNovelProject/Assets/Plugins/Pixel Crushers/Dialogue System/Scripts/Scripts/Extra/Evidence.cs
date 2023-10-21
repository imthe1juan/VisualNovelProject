using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] Sprite sprite;
    ItemSlot itemSot;
    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        itemSot = FindObjectOfType<ItemSlot>();
        sr.sprite = sprite;
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(sr.enabled)
            {

                sr.enabled = false;
                itemSot.UpdateSlot(sprite);
            }
            else
            {
                Debug.Log("Evidence Refactor");
                sr.enabled = true;
                itemSot.NullSlot();
            }
        }
    }
}
