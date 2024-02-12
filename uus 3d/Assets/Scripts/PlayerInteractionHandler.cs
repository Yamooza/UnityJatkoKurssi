using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    [Header("Interactions")]
    public float interactionLength = 1.0f;
    public LayerMask interactionLayers;
    public TextMeshProUGUI interactiomText;

    [Header("Grenade")]
    public GameObject grenadePrefab;
    public Transform firePoint;
    public float throwForce;
    public float upModifier;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInteraction();

        if (Input.GetKeyDown(KeyCode.G))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, firePoint);
        grenade.transform.parent = null;
        grenade.GetComponent<Rigidbody>().AddForce(grenade.transform.forward * throwForce);
    }
    void HandleInteraction()
    {
        //ampuu säteen keskelle näyttöä
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionLength, interactionLayers))
        {
            if (hit.transform.GetComponent<Interactable>())
            {
                interactiomText.text = "[E] to interact with " + hit.transform.name;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<Interactable>().OnInteract();
                }
            }
            else
            {
                interactiomText.text = "";
            }
        }
        else
        {
            interactiomText.text = "";
        }
    }
}
