using TMPro;
using UnityEngine;
using Zenject;

public class InputValidator : MonoBehaviour
{
    [SerializeField] private int _resourcesQuantityMin;
    [SerializeField] private int _resourcesQuantityMax;
    [SerializeField] private TextMeshProUGUI _placeholder;

    private OfferPanel _offerPanel;

    private TMP_InputField _inputField;

    [Inject]
    public void Construct(OfferPanel offerPanel)
    {
        _offerPanel = offerPanel;
    }

    public void Validate()
    {
        int.TryParse(_inputField.text, out var quantity);
        if (quantity < _resourcesQuantityMin || _resourcesQuantityMax < quantity)
        {
            _inputField.text = "";
            _placeholder.text = $"ќшибка! ¬ведите число от {_resourcesQuantityMin} до {_resourcesQuantityMax}!";
            return;
        }

        _offerPanel.ChangeResourcesQuantity(quantity);
    }

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
    }
}
