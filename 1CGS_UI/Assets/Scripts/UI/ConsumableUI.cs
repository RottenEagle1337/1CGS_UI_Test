using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsumableUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _medpackCountUI;
    [SerializeField] private TMP_Text[] _armorPlateCountUI;

    private void Start()
    {
        GameModel.OperationComplete += OperationComplete;
        UpdateUI();
    }

    private void OperationComplete(GameModel.OperationResult obj)
    {
        if (obj.IsSuccess)
            UpdateUI();
    }

    private void UpdateUI()
    {
        foreach(var e in _medpackCountUI)
            e.text = GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack).ToString();
        foreach (var e in _armorPlateCountUI)
            e.text = GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate).ToString();
        Debug.Log($"[{this.GetType()}] UI Updated");
    }
}
