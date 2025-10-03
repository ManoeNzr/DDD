using UnityEngine;
using UnityEngine.InputSystem;

public class RoomDoor : MonoBehaviour
{
    public GameObject uiCanvas;
    public GameObject uiCanvasE;
    private bool playerInRange;

    void Update()
    {
        if (playerInRange)
        {
            uiCanvasE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) { uiCanvas.SetActive(!uiCanvas.activeSelf); }
            
           // Time.timeScale = 0;
        }
        else { uiCanvas.SetActive(false); uiCanvasE.SetActive(false); }


        if (uiCanvas.activeSelf)
        { Cursor.lockState = CursorLockMode.None; uiCanvasE.SetActive(false); }
        else { Cursor.lockState = CursorLockMode.Locked; }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
