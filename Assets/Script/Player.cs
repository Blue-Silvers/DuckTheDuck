using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class Player : MonoBehaviour
{
    [Header("PLAYER & CAMERA")]
    public float speed;
    public Camera cam;
    public Animator anim;
    public float xSensitivity = 1f;
    public float ySensitivity = 1f;
    public bool sameSensitivity = true;

    [Header("INVENTORY (No Touch)")]
    public GameObject inventory;
    public Interactions inventoryInteractions;
    public GameObject inventoryParent;

    private PlayerInput input;
    private InputAction move;
    private InputAction moveCamera;
    private InputAction interaction;
    private InputAction dropObject;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
        move = input.actions.FindAction("Movement");
        interaction = input.actions.FindAction("Interaction");
        moveCamera = input.actions.FindAction("Camera");
        dropObject = input.actions.FindAction("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        Vector2 movement = move.ReadValue<Vector2>();

        Vector3 direction = (cam.transform.forward * movement.y) + (cam.transform.right * movement.x);
        rb.velocity = direction * speed;

        //Camera
        if (sameSensitivity) { ySensitivity = xSensitivity; }
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(rotateVertical * xSensitivity, -rotateHorizontal * ySensitivity, 0);
        cam.transform.eulerAngles -= rotation;

        if (rb.velocity != Vector3.zero) { anim.SetBool("walking", true); }
        else { anim.SetBool("walking", false); }

        // interaction
        if (interaction.WasPressedThisFrame())
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance < 2)
                {
                    Debug.Log("Hit: " + hit.collider.name);
                    Debug.Log("Distance: " + hit.distance);
                    Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow, 5f);

                    if (hit.collider.gameObject.GetComponent<Interactions>().canBeTaken == 1&& inventory == null)
                    {
                        inventory = hit.collider.gameObject;
                        inventory.GetComponent<Collider>().enabled = false;
                        inventoryInteractions = hit.collider.gameObject.GetComponent<Interactions>();
                        inventory.transform.localScale = Vector3.one * 0.5f;
                    }
                    else if (inventory != null)
                    {
                        inventoryInteractions.Interact(hit.collider.gameObject);
                    }
                }
            }
        }

        if (dropObject.WasPressedThisFrame())
        {
            inventory.GetComponent<Collider>().enabled = true;
            inventory.transform.localScale = Vector3.one;
            inventory = null;
        }

        if (inventory != null)
        {
            inventoryInteractions.InInventory(inventoryParent.transform.position, cam.transform.rotation);
        }
    }
}
