using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OfferResourceIcon : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _quantity;

    public void SetIcon(Sprite icon)
    {
        _icon.sprite = icon;
    }

    public void SetQuantity(int quantity)
    {
        if(quantity <= 0)
            throw new Exception($"Resource quantity must be positive, provided: {quantity}");

        _quantity.text = quantity.ToString();
    }
}
