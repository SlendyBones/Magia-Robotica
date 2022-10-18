using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBiomeSpawner : MonoBehaviour
{
    public Nodes myNode;  //Nodo en el que se creo el objeto

    public MyBiome myBiome;  //El bioma al que pertenece 
    public bool enable;
    public float maxCastDist = 1;
    public float sphereRadius = 0.5f;

    [SerializeField]
    int spawnedNeighbours = 0;  //Los nodos vecinos en los que ya hay un bioma

    private float _diceOne;
    private float _diceTwo;

    public float randomTime;  //Tiempo en el que va a instanciar el proximo bloque de bioma

    // Start is called before the first frame update
    void Start()
    {
        enable = true;
        GameManager.instance.allPastitos.Add(this.gameObject);  //Se añade a si mismo a la lista de bloques de terreno

        Invoke(GameManager.instance.myMethod[((int)myBiome)], randomTime);  //Instancia otro bloque de terreno dependiendo de tipo de bloque es y el tiepo en que lo va a hacer

        if (GameManager.instance.allPastitos.Count == GameManager.instance.allNodes.Count)  //Si ya se instanciaron todos los bloques manda la señal para que aparezca el jugador
        {
            GameManager.instance.SpawnPlayer();
        }
    }

    private void Update()
    {
        //if (Physics.SphereCast(transform.position, sphereRadius, transform.up, out RaycastHit hit, maxCastDist))
        //{
        //    if (hit.transform.gameObject.CompareTag("Ores") || hit.transform.gameObject.CompareTag("Decorations"))
        //    {
        //        enable = false;
        //        return;
        //    }
        //}

        if (Physics.Raycast(transform.position, Vector3.up, out RaycastHit midleHit, maxCastDist))
        {
            if (midleHit.transform.gameObject.CompareTag("Ores") || midleHit.transform.gameObject.CompareTag("Decorations"))
            {
                enable = false;
                return;
            }
        }

        if (Physics.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Vector3.up, out RaycastHit rightHit, maxCastDist))
        {
            if (rightHit.transform.gameObject.CompareTag("Ores") || rightHit.transform.gameObject.CompareTag("Decorations"))
            {
                enable = false;
                return;
            }
        }

        if (Physics.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), Vector3.up, out RaycastHit leftHit, maxCastDist))
        {
            if (leftHit.transform.gameObject.CompareTag("Ores") || leftHit.transform.gameObject.CompareTag("Decorations"))
            {
                enable = false;
                return;
            }
        }

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Vector3.up, out RaycastHit frontHit, maxCastDist))
        {
            if (frontHit.transform.gameObject.CompareTag("Ores") || frontHit.transform.gameObject.CompareTag("Decorations"))
            {
                enable = false;
                return;
            }
        }

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), Vector3.up, out RaycastHit backHit, maxCastDist))
        {
            if (backHit.transform.gameObject.CompareTag("Ores") || backHit.transform.gameObject.CompareTag("Decorations"))
            {
                enable = false;
                return;
            }
        }

        enable = true;
    }

    void GrasslandSpawn()  //Creacion del pasto
    {
        foreach (var node in myNode.myNeighbours)
        {
            if (node.spawned == true) continue;
            int random = Random.Range(0, GameManager.instance.grassland.Length);
            GameObject terrain = Instantiate(GameManager.instance.grassland[random], node.transform.position, Quaternion.identity);
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

            int random = Random.Range(0, GameManager.instance.forest.Length);
            GameObject terrain = Instantiate(GameManager.instance.forest[random], node.transform.position, Quaternion.identity);
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

            int random = Random.Range(0, GameManager.instance.corruption.Length);
            GameObject terrain = Instantiate(GameManager.instance.corruption[random], node.transform.position, Quaternion.identity);
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

            int random = Random.Range(0, GameManager.instance.mountain.Length);
            GameObject terrain = Instantiate(GameManager.instance.mountain[random], node.transform.position, Quaternion.identity);
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

            int random = Random.Range(0, GameManager.instance.sea.Length);
            GameObject terrain = Instantiate(GameManager.instance.sea[random], node.transform.position, Quaternion.identity);
            terrain.GetComponent<BaseBiomeSpawner>().myNode = node;
            terrain.GetComponent<BaseBiomeSpawner>().randomTime = Random.Range(0.02f, 0.03f);

            node.spawned = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.up * maxCastDist);
        Gizmos.DrawRay(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), Vector3.up * maxCastDist);
        Gizmos.DrawRay(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), Vector3.up * maxCastDist);
        Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Vector3.up * maxCastDist);
        Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), Vector3.up * maxCastDist);
        //Gizmos.DrawWireSphere(transform.position + transform.up * maxCastDist, sphereRadius);
    }
}
