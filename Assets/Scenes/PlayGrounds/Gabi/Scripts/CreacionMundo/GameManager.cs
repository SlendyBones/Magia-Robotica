using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyBiome
{
    Grassland,
    Forest,
    Mountains,
    Sea,
    Corruption
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerPrefab;
    public GameObject enemy;

    public GameObject spawnedPlayer;

    Transform playerSpawnPoint;

    public GameObject inventory;
    public GameObject slotHolder;

    public GameObject[] forest;
    public GameObject[] sea;
    public GameObject[] grassland;
    public GameObject[] mountain;
    public GameObject[] corruption;

    public GameObject[] decorationsCorruptionBiome;
    public GameObject[] decorationsGraslandBiome;
    public GameObject[] decorationsMountainBiome;
    public GameObject[] decorationsForestBiome;
    public GameObject[] decorationsSeaBiome;

    public GameObject[] decorations;
    public GameObject[] ores;

    public List<MyBiome> biomesToSpawn;
    public int amountOfFirstBiomes;

    public List<Nodes> allNodes = new List<Nodes>();  //Todos los nodos
    public List<GameObject> allPastitos = new List<GameObject>();  //Todos los bloques de terreno
    public List<Nodes> principalNodes = new List<Nodes>();  //Los biomas donde aparecieron las primeras semillas
    public List<GameObject> spawnZoneNodes = new List<GameObject>();  //Los nodos que están en la zona de spawn
    public List<GameObject> createdBuildings = new List<GameObject>();  //Todas las coonstrucciones creadas

    public Dictionary<int, string> myMethod = new Dictionary<int, string>();  //Diccionario de nombres de metodos

    private void Awake()
    {
        if (instance == null) //Singleton
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        //Se añaden los nombres de los metodos de los biomas al diccionario
        myMethod.Add(((int)MyBiome.Grassland), "GrasslandSpawn");
        myMethod.Add(((int)MyBiome.Forest), "ForestSpawn");
        myMethod.Add(((int)MyBiome.Mountains), "MountainSpawn");
        myMethod.Add(((int)MyBiome.Sea), "SeaSpawn");
        myMethod.Add(((int)MyBiome.Corruption), "CorruptionSpawn");
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < amountOfFirstBiomes; j++)  //Cantidad de veces que van a aparecer los biomas
        {
            for (int i = 0; i < 5;) //i = a la cantidad de biomas
            {
                int random = Random.Range(0, allNodes.Count); //Toma un nodo random
                if (principalNodes.Contains(allNodes[random])) continue; //Si ese nodo ya se uso prueba de nuevo

                switch (i) //La creacion de los diferentes biomas
                {
                    case 0:
                        if (!biomesToSpawn.Contains(MyBiome.Grassland)) break;
                        GameObject nodeOne = Instantiate(grassland[0], allNodes[random].transform.position, Quaternion.identity);
                        allNodes[random].spawned = true;
                        nodeOne.GetComponent<BaseBiomeSpawner>().myNode = allNodes[random];
                        principalNodes.Add(allNodes[random]);
                        break;

                    case 1:
                        if (!biomesToSpawn.Contains(MyBiome.Forest)) break;
                        GameObject nodeTwo = Instantiate(forest[0], allNodes[random].transform.position, Quaternion.identity);
                        allNodes[random].spawned = true;
                        nodeTwo.GetComponent<BaseBiomeSpawner>().myNode = allNodes[random];
                        principalNodes.Add(allNodes[random]);
                        break;

                    case 2:
                        if (!biomesToSpawn.Contains(MyBiome.Mountains)) break;
                        GameObject nodeThree = Instantiate(mountain[0], allNodes[random].transform.position, Quaternion.identity);
                        allNodes[random].spawned = true;
                        nodeThree.GetComponent<BaseBiomeSpawner>().myNode = allNodes[random];
                        principalNodes.Add(allNodes[random]);
                        break;

                    case 3:
                        if (!biomesToSpawn.Contains(MyBiome.Corruption)) break;
                        GameObject nodeFour = Instantiate(corruption[0], allNodes[random].transform.position, Quaternion.identity);
                        allNodes[random].spawned = true;
                        nodeFour.GetComponent<BaseBiomeSpawner>().myNode = allNodes[random];
                        principalNodes.Add(allNodes[random]);
                        break;

                    case 4:
                        if (!biomesToSpawn.Contains(MyBiome.Sea)) break;
                        GameObject nodeFive = Instantiate(sea[0], allNodes[random].transform.position, Quaternion.identity);
                        allNodes[random].spawned = true;
                        nodeFive.GetComponent<BaseBiomeSpawner>().myNode = allNodes[random];
                        principalNodes.Add(allNodes[random]);
                        break;
                }

                i++; //Pasa al siguiente bioma
            }
        }
    }

    public void SpawnPlayer() //Hace aparecer al jugador
    {
        int random = Random.Range(0, allPastitos.Count);
        playerSpawnPoint = allPastitos[random].transform;
        Vector3 initPos = new Vector3(allPastitos[random].transform.position.x, allPastitos[random].transform.position.y + 0.5f, allPastitos[random].transform.position.z);
        spawnedPlayer = Instantiate(playerPrefab, initPos, Quaternion.identity);
        Camera.main.GetComponent<CameraFollow>().target = spawnedPlayer.transform;
        FindObjectOfType<InstantiateOnMousePos>().player = spawnedPlayer;
        playerPrefab.transform.position = initPos;
        playerPrefab.SetActive(true);
        spawnedPlayer.GetComponent<Inventory>().inventory = inventory;
        spawnedPlayer.GetComponent<Inventory>().slotHolder = slotHolder;
        spawnedPlayer.GetComponent<MiningOnClick>().playerInventory = spawnedPlayer.GetComponent<Inventory>();
        FindObjectOfType<InstantiateOnMousePos>().inventory = spawnedPlayer.GetComponent<Inventory>();


        SetingTheEndOfStart();
        //SetingSpawnZone();

        SpawnDecoration();
        //SpawnOres();
        //SpawnEnemy();
    }

    public void SetingSpawnZone()
    {
        foreach (var node in allPastitos)
        {
            if (Vector3.Distance(node.transform.position, playerSpawnPoint.position) > 5 || node.transform.position == playerSpawnPoint.position) continue;

            spawnZoneNodes.Add(node);
        }

        //SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        int enemysCount = 0;

        for (int i = 0; i < allPastitos.Count; i++)
        {
            //if (enemysCount >= 5) return;
            //if (Vector3.Distance(spawnZoneNodes[i].transform.position, playerSpawnPoint.position) < 3) continue;

            int random = Random.Range(0, 100);
            if (random == 0)
            {
                Vector3 initPos = new Vector3(allPastitos[i].transform.position.x, allPastitos[i].transform.position.y + 1, allPastitos[i].transform.position.z);
                Instantiate(enemy, initPos, Quaternion.identity);

                enemysCount++;
                allPastitos.Remove(allPastitos[i]);
            }
        }
    }


    public void SpawnOres()
    {
        int oresCount = 0;
    
        for (int i = 0; i < allPastitos.Count; i++)
        {
            if (!allPastitos[i].GetComponent<BaseBiomeSpawner>().enable) continue;

            int random = Random.Range(0, 30);
            if (random == 0)
            {
                int randomOre = Random.Range(0, ores.Length);
                Vector3 initPos = new Vector3(allPastitos[i].transform.position.x, allPastitos[i].transform.position.y + 0.5f, allPastitos[i].transform.position.z);
                Instantiate(ores[randomOre], initPos, Quaternion.identity);
    
                oresCount++;
                allPastitos.Remove(allPastitos[i]);
            }
        }
    }

    public void SpawnDecoration()
    {
        for (int i = 0; i < allPastitos.Count; i++)
        {
            var biome = allPastitos[i].GetComponent<BaseBiomeSpawner>();
            if (!biome.enable) continue;

            int random = Random.Range(0, 30);
            if (random == 0)
            {
                //int randomDecoration = Random.Range(0, decorations.Length);
                //Vector3 initPos = new Vector3(allPastitos[i].transform.position.x, allPastitos[i].transform.position.y + 0.5f, allPastitos[i].transform.position.z);
                //Instantiate(decorations[randomDecoration], initPos, Quaternion.identity);

                switch ((int)biome.myBiome)
                {
                    case ((int)MyBiome.Grassland):
                        int randomGrassland = Random.Range(0, decorationsGraslandBiome.Length);
                        Vector3 initPosGrassland = new Vector3(allPastitos[i].transform.position.x, allPastitos[i].transform.position.y + 0.5f, allPastitos[i].transform.position.z);
                        Instantiate(decorationsGraslandBiome[randomGrassland], initPosGrassland, Quaternion.identity);
                        break;

                    case ((int)MyBiome.Forest):
                        int randomForest = Random.Range(0, decorationsForestBiome.Length);
                        Vector3 initPosForest = new Vector3(allPastitos[i].transform.position.x, allPastitos[i].transform.position.y + 0.5f, allPastitos[i].transform.position.z);
                        Instantiate(decorationsForestBiome[randomForest], initPosForest, Quaternion.identity);
                        break;

                    case ((int)MyBiome.Mountains):
                        int randomMountain = Random.Range(0, decorationsMountainBiome.Length);
                        Vector3 initPosMountain = new Vector3(allPastitos[i].transform.position.x, allPastitos[i].transform.position.y + 0.5f, allPastitos[i].transform.position.z);
                        Instantiate(decorationsMountainBiome[randomMountain], initPosMountain, Quaternion.identity);
                        break;

                    case ((int)MyBiome.Corruption):
                        int randomCorruption = Random.Range(0, decorationsCorruptionBiome.Length);
                        Vector3 initPosCorruption = new Vector3(allPastitos[i].transform.position.x, allPastitos[i].transform.position.y + 0.5f, allPastitos[i].transform.position.z);
                        Instantiate(decorationsCorruptionBiome[randomCorruption], initPosCorruption, Quaternion.identity);
                        break;

                    case ((int)MyBiome.Sea):
                        int randomSea = Random.Range(0, decorationsSeaBiome.Length);
                        Vector3 initPosSea = new Vector3(allPastitos[i].transform.position.x, allPastitos[i].transform.position.y + 0.5f, allPastitos[i].transform.position.z);
                        Instantiate(decorationsSeaBiome[randomSea], initPosSea, Quaternion.identity);
                        break;
                }

            }
        }
    }

    public void SetingTheEndOfStart()
    {
        foreach (var node in allNodes)
        {
            node.endStart = true;
        }
    }
}
