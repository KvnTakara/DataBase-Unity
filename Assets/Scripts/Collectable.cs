using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    #region Variables
    #endregion

    #region Functions

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            PlayerData playerData = _collider.GetComponent<PlayerData>();
            playerData.Points++;

            _collider.GetComponentInChildren<PlayerHud>().UpdateScoreUI();

            DataManager.AlterarPontos(playerData.Id, playerData.Points);

            Destroy(gameObject);
        }
    }

    #endregion
}
