using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomSelectionUI : MonoBehaviour
{
    public Button[] roomButtons;
    public RoomManager roomManager;

    void OnEnable()
    {
        List<RoomData> options = roomManager.GetRandomRooms(3);

        for (int i = 0; i < roomButtons.Length; i++)
        {
            int index = i;
            roomButtons[i].GetComponentInChildren<TMP_Text>().text = options[i].roomPrefab.name;
            roomButtons[i].onClick.RemoveAllListeners();
            roomButtons[i].onClick.AddListener(() => {
                roomManager.SpawnRoom(options[index].roomPrefab);
                gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                // Time.timeScale = 1;
            });
        }
    }
}
