using UnityEngine;
/// <summary>
/// Simple example of Grabbing system.
/// </summary>
public class PickUpScriptV2 : MonoBehaviour
{
    // Reference to the character camera.

    public Camera characterCamera;
    // Reference to the slot for holding picked item.

    public Transform slot;
    // Reference to the currently held item.
    private PickableItem pickedItem;
    /// <summary>
    /// Method called very frame.
    /// </summary>
    private void Update()
    {
        // Execute logic only on button pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if player picked some item already
            if (pickedItem)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // If yes, drop picked item
                    DropItem(pickedItem);
                }   
            }
            else
            {
                // If no, try to pick item in front of the player
                // Create ray from center of the screen
                var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
                RaycastHit hit;
                // Shot ray to find object to pick
                if (Physics.Raycast(ray, out hit, 1.5f))
                {
                    // Check if object is pickable
                    var pickable = hit.transform.GetComponent<PickableItem>();
                    // If object has PickableItem class
                    if (pickable)
                    {
                        // Pick it
                        PickItem(pickable);
                    }
                }
            }
        }
    }
    // <summary>
    // Method for picking up item.
    // </summary>
    // <param name="item">Item.</param>
    private void PickItem(PickableItem item)
    {
        // Assign reference
        pickedItem = item;
        // Disable rigidbody and reset velocities
        pickedItem.Rb.isKinematic = true;
        pickedItem.Rb.velocity = Vector3.zero;
        pickedItem.Rb.angularVelocity = Vector3.zero;
        // Set Slot as a parent
        //item.transform.SetParent(slot); 
        pickedItem.transform.position = slot.transform.position;
        // Reset position and rotation
        //pickedItem.transform.localPosition = Vector3.zero;
        //pickedItem.transform.localEulerAngles = Vector3.zero;
    }
    // <summary>
    // Method for dropping item.
    // </summary>
    // <param name="item">Item.</param>
    private void DropItem(PickableItem item)
    {
        // Remove reference
        pickedItem = null;
        // Remove parent
        item.transform.SetParent(null);
        // Enable rigidbody
        item.Rb.isKinematic = false;
        // Add force to throw item a little bit
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }
}
