using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExchangeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _currencyExchangeRate;
    [SerializeField] private TMP_Text _calculatedExchangeRate;
    [SerializeField] private TMP_InputField _exchangeInputField;
    [SerializeField] private Button _exchangeButton;
    private int _coinToConvert = 0;

    private void Start()
    {
        _currencyExchangeRate.text = GameModel.CoinToCreditRate.ToString();

        _exchangeButton.onClick.AddListener(() => GameModel.ConvertCoinToCredit(_coinToConvert));
        _exchangeInputField.onValueChanged.AddListener(delegate { CalculateCredits(); });

        CalculateCredits();
        
    }

    private void CalculateCredits()
    {
        Debug.Log($"[{this.GetType()}] Calculating credits value");
        if(int.TryParse(_exchangeInputField.text, out int value))
        {
            _coinToConvert = value;
            _calculatedExchangeRate.text = (_coinToConvert * GameModel.CoinToCreditRate).ToString();
        }
        else
        {
            _calculatedExchangeRate.text = "0";
        }
    }
}
