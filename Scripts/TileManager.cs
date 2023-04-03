using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<GameObject> activeTiles;
    public GameObject[] tilePrefabs;

    public float tileLength = 30;
    public int numberOfTiles = 3;
    public int totalNumOfTiles = 8;

    public float zSpawn = 0;

    [SerializeField] Transform playerTransform;

    private int previousIndex;

    private void Start()
    {
        activeTiles = new List<GameObject>();
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, totalNumOfTiles));
        }
    }
    private void Update()
    {
        if (playerTransform.position.z - 13 >= zSpawn - (numberOfTiles * tileLength))
        {

            SpawnTile(Random.Range(1, tilePrefabs.Length));
            DeleteTile();
            
        }
    }

    private void SpawnTile(int v)
    {
        GameObject tile = Instantiate(tilePrefabs[v], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(tile);
        zSpawn += tileLength;
    }    
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        PlayerManager.score += 3;
    }
}