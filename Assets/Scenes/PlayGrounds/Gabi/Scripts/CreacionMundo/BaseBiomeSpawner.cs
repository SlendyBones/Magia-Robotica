using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBiomeSpawner : MonoBehaviour
{
    public Nodes myNode;  //Nodo en el que se creo el objeto

    public MyBiome myBiome;  //El bioma al que pertenece 

    [SerializeField]
    int spawnedNeighbours = 0;  //Los nodos vecinos en los que ya hay un bioma

    private float _diceOne;
    private float _diceTwo;

    public float randomTime;  //Tiempo en el que va a instanciar el proximo bloque de bioma

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.allPastitos.Add(this.gameObject);  //Se añade a si mismo a la lista de bloques de terreno

        Invoke(GameManager.instance.myMethod[((int)myBiome)], randomTime);  //Instancia otro bloque de terreno dependiendo de tipo de bloque es y el tiepo en que lo va a hacer

        if (GameManager.instance.allPastitos.Count == GameManager.instance.allNodes.Count)  //Si ya se instanciaron todos los bloques manda la señal para que aparezca el jugador
        {
            GameManager.instance.SpawnPlayer();
        }
    }

    void GrasslandSpawn()  //Creacion del pasto
    {
        foreach (var node in myNode.myNeighbours)
        {
            if (node.spawned == true) continue;

            GameObject terrain = Instantiate(GameManager.instance.grassland[0], node.transform.position, Quaternion.identity);
            terrain.GetComponent<BaseBiomeSpawner>().myNode = node;
            terrain.GetComponent<BaseBiomeSpawner>().randomTime = Random.Range(0.01f, 0.03f);

            node.spawned = true;
        }
    }

    void ForestSpawn()  //Creacion del bosque
    {
        foreach (var node in myNode.myNeighbours)
        {
            if (node.spawned == true) continue;

            GameObject terrain = Instantiate(GameManager.instance.forest[0], node.transform.position, Quaternion.identity);
            terrain.GetComponent<BaseBiomeSpawner>().myNode = node;
            terrain.GetComponent<BaseBiomeSpawner>().randomTime = Random.Range(0.01f, 0.03f);

            node.spawned = true;
        }
    }

    void CorruptionSpawn()  //Creacion de la corrupcion
    {
        foreach (var node in myNode.myNeighbours)
        {
            if (node.spawned == true) continue;

            GameObject terrain = Instantiate(GameManager.instance.corruption[0], node.transform.position, Quaternion.identity);
            terrain.GetComponent<BaseBiomeSpawner>().myNode = node;
            terrain.GetComponent<BaseBiomeSpawner>().randomTime = Random.Range(0.025f, 0.04f);

            node.spawned = true;
        }
    }

    void MountainSpawn()  //Creacion de la montaña
    {
        foreach (var node in myNode.myNeighbours)
        {
            if (node.spawned == true) continue;

            GameObject terrain = Instantiate(GameManager.instance.mountain[0], node.transform.position, Quaternion.identity);
            terrain.GetComponent<BaseBiomeSpawner>().myNode = node;
            terrain.GetComponent<BaseBiomeSpawner>().randomTime = Random.Range(0.025f, 0.03f);

            node.spawned = true;
        }
    }

    void SeaSpawn()  //Creacion del mar
    {
        foreach (var node in myNode.myNeighbours)
        {
            if (node.spawned == true) continue;

            GameObject terrain = Instantiate(GameManager.instance.sea[0], node.transform.position, Quaternion.identity);
            terrain.GetComponent<BaseBiomeSpawner>().myNode = node;
            terrain.GetComponent<BaseBiomeSpawner>().randomTime = Random.Range(0.02f, 0.03f);

            node.spawned = true;
        }
    }
}
