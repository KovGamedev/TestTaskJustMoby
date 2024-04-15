using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OfferPanel : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TextMeshProUGUI _info;
    [SerializeField] private IconsConfig _iconsConfig;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private List<GameObject> _resourcesLines = new List<GameObject>();
    [SerializeField] private List<OfferResourceIcon> _resourcesIcons = new List<OfferResourceIcon>();
    [SerializeField] private Image _offerImage;
    [SerializeField] private TextMeshProUGUI _priceWithDiscount;
    [SerializeField] private TextMeshProUGUI _wholePrice;
    [SerializeField] private GameObject _discountPanel;
    [SerializeField] private TextMeshProUGUI _discount;

    public void ChangeResourcesQuantity(int quantity)
    {
        if (quantity < Mathf.RoundToInt(0.5f * _resourcesIcons.Count) || _resourcesIcons.Count < quantity)
            throw new Exception($"Incorrect resources quantity: {quantity}");

        _resourcesLines[1].SetActive(_resourcesLines[1].transform.childCount < quantity);
        for (var i = Mathf.FloorToInt(0.5f * _resourcesIcons.Count); i < _resourcesIcons.Count; i++)
        {
            if (i < quantity)
                _resourcesIcons[i].gameObject.SetActive(true);
            else
                _resourcesIcons[i].gameObject.SetActive(false);
        }
    }

    public void SetData(OfferDto offerDto)
    {
        if (!gameObject.activeSelf)
            return;
        if (offerDto.ResourcesIcons.Length != offerDto.ResourcesQuantities.Length)
        {
            _info.text = "Что-то пошло не так :(";
            throw new Exception("Icons info length is invalid");
        }

        if (_infoPanel != null)
            _infoPanel?.SetActive(false);

        _title.text = offerDto.Title;
        _description.text = offerDto.Description;
        _resourcesLines[1].SetActive(_resourcesLines[1].transform.childCount < offerDto.ResourcesIcons.Length);
        for (var i = 0; i < _resourcesIcons.Count; i++)
        {
            if (i < offerDto.ResourcesIcons.Length)
            {
                _resourcesIcons[i].gameObject.SetActive(true);
                _resourcesIcons[i].SetIcon(GetIconByName(offerDto.ResourcesIcons[i]));
                _resourcesIcons[i].SetQuantity(offerDto.ResourcesQuantities[i]);
            }
            else
            {
                _resourcesIcons[i].gameObject.SetActive(false);
            }
        }
        _offerImage.sprite = GetImageByName(offerDto.OfferImage);
        if (offerDto.Discount == 0)
        {
            _discountPanel.SetActive(false);
            _wholePrice.gameObject.SetActive(false);
        }
        else
        {
            _discountPanel.SetActive(true);
            _discount.text = FormatPercentages(offerDto.Discount);
            _wholePrice.gameObject.SetActive(true);
            _wholePrice.text = offerDto.Price.ToString("F2");
        }
        _priceWithDiscount.text = FormatCurrency(offerDto.Price * (1f - offerDto.Discount));
    }

    private Sprite GetIconByName(string iconName)
    {
        return _iconsConfig.OfferIcons.Find(namedIcon => namedIcon.Name == iconName).Icon;
    }

    private Sprite GetImageByName(string iconName)
    {
        return _iconsConfig.OfferImages.Find(namedIcon => namedIcon.Name == iconName).Icon;
    }

    private string FormatCurrency(float sum)
    {
        var currentCurrencyObtainedFromSomeConfigsOrFromTheServer = "$";
        return $"{currentCurrencyObtainedFromSomeConfigsOrFromTheServer}{sum.ToString("F2")}";
    }

    private string FormatPercentages(float percentage)
    {
        if (percentage < 0f || 1f < percentage)
            throw new Exception($"Percentage must be between 0 and 1, provided: {percentage}");

        return $"-{percentage * 100}%";
    }

    private void OnDisable()
    {
        if (_infoPanel != null)
            _infoPanel.SetActive(true);
    }
}
