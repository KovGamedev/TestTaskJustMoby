using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OfferPanel : MonoBehaviour
{
    [SerializeField] private IconsConfig _iconsConfig;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private List<GameObject> _resourcesLines = new List<GameObject>();
    [SerializeField] private List<OfferResourceIcon> _resourcesIcons = new List<OfferResourceIcon>();
    [SerializeField] private Image _offerImage;
    [SerializeField] private TextMeshProUGUI _priceWithDiscount;
    [SerializeField] private TextMeshProUGUI _wholePrice;
    [SerializeField] private TextMeshProUGUI _discount;

    private void Start()
    {
        var mockDto = new OfferDto(
            "Ресурсы для стройки",
            "Покори небеса, построй плот своей мечты",
            "BuilderKit",
            new string[6] { "Coal", "Grass", "Log", "Metal", "Rope", "Stone" },
            new int[6] { 20, 20, 20, 20, 20, 20 },
            2.99f,
            3.33f,
            0.1f
        );
        SetData(mockDto);
    }

    private void SetData(OfferDto offerDto)
    {
        if (offerDto.ResourcesIcons.Length != offerDto.ResourcesQuantities.Length)
            throw new Exception($"Icons info length is invalid");

        _title.text = offerDto.Title;
        _description.text = offerDto.Description;
        for (var i = 0; i < _resourcesIcons.Count; i++ ) {
            if (i < offerDto.ResourcesIcons.Length) {
                _resourcesIcons[i].SetIcon(GetIconByName(offerDto.ResourcesIcons[i]));
                _resourcesIcons[i].SetQuantity(offerDto.ResourcesQuantities[i]);
            }
        }
        _offerImage.sprite = GetImageByName(offerDto.OfferImage);
        _priceWithDiscount.text = Math.Round(offerDto.PriceWithDiscount, 2).ToString();
        _wholePrice.text = Math.Round(offerDto.WholePrice, 2).ToString();
        _discount.text = FormatPercentages(offerDto.Discount);
    }

    private Sprite GetIconByName(string iconName)
    {
        return _iconsConfig.OfferIcons.Find(namedIcon => namedIcon.Name == iconName).Icon;
    }

    private Sprite GetImageByName(string iconName)
    {
        return _iconsConfig.OfferImages.Find(namedIcon => namedIcon.Name == iconName).Icon;
    }

    private string FormatPercentages(float percentage)
    {
        if (percentage < 0f || 1f < percentage)
            throw new Exception($"Percentage must be between 0 and 1, provided: {percentage}");

        return $"-{percentage * 100}%";
    }
}
