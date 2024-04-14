using UnityEngine;

public class OfferDto
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string OfferImage { get; private set; }
    public string[] ResourcesIcons { get; private set; }
    public int[] ResourcesQuantities { get; private set; }
    public float PriceWithDiscount { get; private set; }
    public float WholePrice { get; private set; }
    public float Discount { get; private set; }

    public OfferDto(
        string title,
        string description,
        string offerImage,
        string[] resourcesIcons,
        int[] resourcesQuantities,
        float priceWithDiscount,
        float wholePrice,
        float discount
    )
    {
        Title = title;
        Description = description;
        OfferImage = offerImage;
        ResourcesIcons = resourcesIcons;
        ResourcesQuantities = resourcesQuantities;
        PriceWithDiscount = priceWithDiscount;
        WholePrice = wholePrice;
        Discount = discount;
    }
}
