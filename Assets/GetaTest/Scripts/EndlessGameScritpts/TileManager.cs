using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 40;
    public int numberOfTiles;

    public List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;
    void Start()
    {
        numberOfTiles=tilePrefabs.Length;
        SpawnTile (0);
        for(int i = 0; i < numberOfTiles; i++)
        SpawnTile(Random.Range(02,numberOfTiles));

    }

    void Update()
    {
        if(playerTransform.position.z - 45 >zSpawn - (numberOfTiles*tileLength)){
            SpawnTile(Random.Range(02,numberOfTiles));
            DeleteTile();
        }

    }
    public void SpawnTile (int tileIndex){
        GameObject go = Instantiate(tilePrefabs[tileIndex],transform.forward *zSpawn,transform.rotation);
        activeTiles.Add(go);
        zSpawn+=tileLength;
    }
    private void DeleteTile(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
