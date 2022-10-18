using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningOnClick : MonoBehaviour
{
    int layerMask;
    public GameObject player;
    public float maxInteractionRange;
    public float maxChronometer;
    public Camera playerCamera;
    public Inventory playerInventory;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerCamera = Camera.main;
        player = this.gameObject;
        layerMask = LayerMask.GetMask("Ores");  //Toma el layer de las menas
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MouseTarget(Input.mousePosition);
        }
    }

    void MouseTarget(Vector3 mousePos)
    {
        Ray ray = playerCamera.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out RaycastHit hit, layerMask))
        {
            if(Vector3.Distance(hit.transform.position, player.transform.position) <= maxInteractionRange && hit.transform.gameObject.layer == 7)
            {
                Interacting(hit.transform.gameObject);
                anim.SetTrigger("takeitem");
            }
        }
    }

    void Interacting(GameObject interactableObject)
    {
        float chronometer = 0;
        while (chronometer <= maxChronometer)
        {
            Debug.Log("Entró en el while");
            chronometer += Time.deltaTime;
        }


        Debug.Log("Mena minada");
        anim.ResetTrigger("takeitem");
        playerInventory.InteractionObject(interactableObject);
        Destroy(interactableObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxInteractionRange);
    }
}
