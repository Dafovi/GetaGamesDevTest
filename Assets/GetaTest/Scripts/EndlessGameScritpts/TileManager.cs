using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [Header("Tiles")]
    [SerializeField] private GameObject[] tilePrefabs;
    [SerializeField] private List<GameObject> activeTiles = new List<GameObject>();

    
    [Header("Tiles positioningt"),Space(10)]
    [SerializeField] private float zSpawn = 0;
    [SerializeField] private float tileLength = 40;
    [SerializeField] private int numberOfTiles;
    
    [Header("Player"),Space(10)]
    [SerializeField] private Transform playerTransform;
    void Start()
    {
        //Al iniciar crea un camino aleatorio dejando la primera parte de la pista limpia
        numberOfTiles=tilePrefabs.Length;
        SpawnTile (0);
        for(int i = 0; i < numberOfTiles; i++)
        SpawnTile(Random.Range(02,numberOfTiles));

    }

    void Update()
    {
        //A medida que el jugador avanza va creando y borrando el camino
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
