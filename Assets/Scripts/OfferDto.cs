using UnityEngine;

[System.Serializable]
public class OfferDto
{
    public string Title;
    public string Description;
    public string OfferImage;
    public string[] ResourcesIcons;
    public int[] ResourcesQuantities;
    public float Price;
    public float Discount;

    public OfferDto(
        string title,
        string description,
        string offerImage,
        string[] resourcesIcons,
        int[] resourcesQuantities,
        float price,
        float discount
    )
    {
        Title = title;
        Description = description;
        OfferImage = offerImage;
        ResourcesIcons = resourcesIcons;
        ResourcesQuantities = resourcesQuantities;
        Price = price;
        Discount = discount;
    }

    public static OfferDto CreateFromJson(string json)
    {
        return JsonUtility.FromJson<OfferDto>(json);
    }
}