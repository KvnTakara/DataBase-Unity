using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    #region Variables

    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI userName;

    PlayerData playerData;

    #endregion

    #region Initialization

    void Start()
    {
        playerData = GetComponentInParent<PlayerData>();

        UpdateScoreUI();
        UpdateNameUI();
    }

    #endregion

    #region Functions

    public void UpdateScoreUI()
    {
        score.text = $"Score: {playerData.Points.ToString()}";
    }

    public void UpdateNameUI()
    {
        userName.text = playerData.Name;
    }

    #endregion
}
