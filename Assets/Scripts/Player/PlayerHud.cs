using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    #region Variables

    [SerializeField] TextMeshProUGUI score;

    PlayerData playerData;

    #endregion

    #region Initialization

    void Start()
    {
        playerData = GetComponentInParent<PlayerData>();

        UpdateScoreUI();
    }

    #endregion

    #region Functions

    public void UpdateScoreUI()
    {
        score.text = playerData.Points.ToString();
    }

    #endregion
}
