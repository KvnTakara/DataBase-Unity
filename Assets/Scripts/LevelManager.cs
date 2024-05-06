using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables

    public static LevelManager instance;

    [SerializeField] GameObject PlayerPrefabs;

    [SerializeField] GameObject collectablePrefab;

    [SerializeField] Vector3 spawnArea;
    [SerializeField] Vector3 spawnCenter;

    public List<Usuario> rankingList = new List<Usuario>();

    Vector3 spawnedPosition;

    #endregion

    #region Initialization

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    #endregion

    #region Functions

    public void CreatePlayer(int _id, int _pontos)
    {
        GameObject newPlayer = Instantiate(PlayerPrefabs);
        newPlayer.transform.position = Vector3.zero;

        newPlayer.GetComponent<PlayerData>().Id = _id;
        newPlayer.GetComponent<PlayerData>().Points = _pontos;
    }

    public void InstantiateCollectables(int _collectableAmount)
    {
        for (int i = 0; i < _collectableAmount; i++)
        {
            float spawnPositionX = spawnArea.x * 0.5f + spawnCenter.x;
            float spawnPositionY = spawnArea.y;
            float spawnPositionZ = spawnArea.z * 0.5f + spawnCenter.z;

            spawnedPosition = new Vector3(Random.Range(-spawnPositionX, spawnPositionX), spawnPositionY, Random.Range(-spawnPositionZ, spawnPositionZ));

            GameObject collectableInstance = Instantiate(collectablePrefab, spawnedPosition, Quaternion.identity);
        }
    }

    #endregion
}
