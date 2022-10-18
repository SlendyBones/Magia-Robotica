using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InstantiateOnMousePos : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject prefab;
    int layerMask;
    [SerializeField] float maxRayDist;
    [SerializeField] float maxInteractionDist;
    [SerializeField] GameObject _canvasImages;
    [SerializeField] GameObject _assemblerUpdateImages;
    [SerializeField] GameObject _assemblerPrefab;
    [SerializeField] GameObject _housePrefab;
    [SerializeField] GameObject _houseUpdateImage;
    public GameObject currentPos;
    GameObject currentPrefab;
    public bool prefabCollision;
    public Material transparentMaterial;
    public bool buildingMode;
    List<Transform> heldPositions = new List<Transform>();
    public List<GameObject> nearbyBuildings = new List<GameObject>();
    event Action checking = delegate { };
    public Inventory inventory;
    event Func<int[], int[], bool> materialsDefinition;
    int[] materialType;
    int[] materialAmount;

    // Start is called before the first frame update
    void Start()
    {
        checking = null; //Si hay algun problema con la contruccion puede ser esto
        _canvasImages.SetActive(false);
        _houseUpdateImage.SetActive(false);
        _assemblerUpdateImages.SetActive(false);
        layerMask = LayerMask.GetMask("BaseBiome");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (buildingMode)
            {
                _canvasImages.SetActive(false);
                buildingMode = false;
                currentPos = null;
                Destroy(currentPrefab);
            }
            else
            {
                checking = CheckingInteractionDistance;
                checking();
                _canvasImages.SetActive(true);

                if (nearbyBuildings.Contains(_assemblerPrefab))
                {
                    _assemblerUpdateImages.SetActive(true);
                }
                if (nearbyBuildings.Contains(_housePrefab))
                {
                    _houseUpdateImage.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _canvasImages.SetActive(false);
            buildingMode = false;
            currentPos = null;
            Destroy(currentPrefab);
        }

        if (checking != null)
        {
            bool haveAssembler = false;
            bool haveHouse = false;
            checking();
            foreach (var building in nearbyBuildings)
            {
                if (building.name == _assemblerPrefab.name + "(Clone)") haveAssembler = true;
                if (building.name == _housePrefab.name + "(Clone)") haveHouse = true;
            }

            if (haveAssembler == true)
            {
                _assemblerUpdateImages.SetActive(true);
            }
            else
            {
                _assemblerUpdateImages.SetActive(false);
            }
            
            if (haveHouse == true)
            {
                _houseUpdateImage.SetActive(true);
            }
            else
            {
                _houseUpdateImage.SetActive(false);
            }

            Debug.Log("house = " + haveHouse + "/n" + "assembler = " + haveAssembler);
        }

        if (!buildingMode) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //if(Si no alcanzan los materiales) Debug.log(no alcanzan los materiales); return;
                
            if (currentPos != null)
            {
                if (!heldPositions.Contains(currentPos.transform) && !currentPrefab.GetComponent<PreCollisionDetector>().onCollision)
                {
                    if (!CheckMaterials(materialType, materialAmount))
                    {
                        Debug.Log("No se puede construir");
                        return;
                    }
                    Vector3 pos = new Vector3(currentPos.transform.position.x, currentPos.transform.position.y + 0.5f, currentPos.transform.position.z);
                    GameManager.instance.createdBuildings.Add(Instantiate(prefab, pos, Quaternion.identity));
                    heldPositions.Add(currentPos.transform);
                    currentPos = null;
                    SoundManager.instance.PlaySound(SoundID.Construction);
                }
                else
                {
                    Debug.Log("No se puede construir ahí");
                }
            }
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit info, maxRayDist, layerMask))
        {
            if (currentPos == info.transform.gameObject) return;
            currentPos = info.transform.gameObject;
            if(currentPrefab == null)
            {
                Vector3 initPos = new Vector3(info.transform.position.x, info.transform.position.y + 0.5f, info.transform.position.z);
                currentPrefab = Instantiate(prefab, initPos, Quaternion.identity);
                Renderer[] renderers = currentPrefab.GetComponentsInChildren<Renderer>();
                for (int i = 0; i < renderers.Length; i++)
                {
                    Material[] allMaterials = renderers[i].materials;
                    for (int j = 0; j < allMaterials.Length; j++)
                    {
                        allMaterials[j] = transparentMaterial;
                    }
                }
                currentPrefab.GetComponent<Collider>().isTrigger = true;
                prefabCollision = currentPrefab.AddComponent<PreCollisionDetector>().onCollision;
                currentPrefab.AddComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                Vector3 pos = new Vector3(info.transform.position.x, info.transform.position.y + 0.5f, info.transform.position.z);
                currentPrefab.transform.position = pos;
            }
        }

        //CAMBIO DE COLORES DEL PREFAB
        if(currentPrefab.GetComponent<PreCollisionDetector>() != null)
        {
            if (currentPrefab.GetComponent<PreCollisionDetector>().onCollision)
            {
                currentPrefab.GetComponent<ShaderController>().ChangeSpawnToHologram();
                currentPrefab.GetComponent<ShaderController>().CallToRed();
            }
            else
            {
                currentPrefab.GetComponent<ShaderController>().ChangeSpawnToHologram(); //Para cambiar el material a holograma 
                currentPrefab.GetComponent<ShaderController>().CallToGreen();
                //Si no se está chocando con nada (Acá se haría verde)
            }
        }

    }

    public void BTN_SelecBiulding(BaseBuilding building)
    {
        checking = null;
        prefab = building.prefab;
        materialType = building.materialsTipe;
        materialAmount = building.materialsAmount;
        buildingMode = true;
        _canvasImages.SetActive(false);
    }

    bool CheckMaterials(int[] material, int[] amount)
    {
        int amountInInventory = 0;
        List<Slot> slotsLista = new List<Slot>();
        for (int i = 0; i < materialType.Length; i++)
        {
            for (int j = 0; j < inventory._slot.Length; j++)
            {
                var slot = inventory._slot[j].GetComponent<Slot>();
                if (slot.ID == materialType[i])
                {
                    amountInInventory++;
                    slotsLista.Add(slot);
                    if (amountInInventory >= materialAmount[i])
                    {
                        break;
                    }
                }

            }

            if (amountInInventory < materialAmount[i]) return false;

            amountInInventory = 0;
        }

        foreach (var item in slotsLista)
        {
            item.CleanSlot();
        }

        return true;
    }

    void CheckingInteractionDistance()
    {
        foreach (var building in GameManager.instance.createdBuildings)
        {
            if(Vector3.Distance(player.transform.position, building.transform.position) <= maxInteractionDist)
            {
                if (!nearbyBuildings.Contains(building))
                {
                    nearbyBuildings.Add(building);
                }
            }
            else
            {
                if (nearbyBuildings.Contains(building))
                {
                    nearbyBuildings.Remove(building);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (player == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, maxInteractionDist);
    }
}
