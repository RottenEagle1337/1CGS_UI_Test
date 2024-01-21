using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _coinsCountUI;
    [SerializeField] private TMP_Text[] _creditsCountUI;
    

    private void Start()
    {
        GameModel.OperationComplete += OperationComplete;
        UpdateUI();
    }

    private void OperationComplete(GameModel.OperationResult obj)
    {
        if(obj.IsSuccess)
            UpdateUI();
    }

    private void UpdateUI()
    {
        foreach (var e in _coinsCountUI)
            e.text = GameModel.CoinCount.ToString();
        foreach (var e in _creditsCountUI)
            e.text = GameModel.CreditCount.ToString();
        Debug.Log($"[{this.GetType()}] UI Updated");
    }
}
