using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingPopup : MonoBehaviour
{
    #region Variables

    [SerializeField] GameObject rankingPlaceholder;
    [SerializeField] Transform container;

    #endregion

    #region Initialization

    void Awake()
    {
        DataManager.RankingUsuarios();
    }

    void Start()
    {
        foreach (Usuario _usuario in LevelManager.instance.rankingList)
        {
            if (_usuario.pontos > 0)
            {
                GameObject rankingInstance = Instantiate(rankingPlaceholder, container);
            }
        }
    }

    #endregion
}
