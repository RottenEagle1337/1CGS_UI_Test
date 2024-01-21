using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyUI : MonoBehaviour
{
    [SerializeField] private GameModel.ConsumableTypes _consumableBuyType;
    [SerializeField] private TMP_Text _consumablePriceText;
    [SerializeField] private Button _buyButton;

    private void Start()
    {
        int price;

        if(GameModel.ConsumablesPrice[_consumableBuyType].CoinPrice == 0)
        {
            price = GameModel.ConsumablesPrice[_consumableBuyType].CreditPrice;
            _buyButton.onClick.AddListener(() => GameModel.BuyConsumableForSilver(_consumableBuyType));
        }
        else
        {
            price = GameModel.ConsumablesPrice[_consumableBuyType].CoinPrice;
            _buyButton.onClick.AddListener(() => GameModel.BuyConsumableForGold(_consumableBuyType));
        }

        _consumablePriceText.text = price.ToString();
    }
}
