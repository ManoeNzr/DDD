using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;
    public Transform player;
    public List<RoomData> allRooms;
    public GameObject currentRoom;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public List<RoomData> GetRandomRooms(int count)
    {
        List<RoomData> selected = new List<RoomData>();
        List<RoomData> copy = new List<RoomData>(allRooms);

        while (selected.Count < count && copy.Count > 0)
        {
            float totalWeight = copy.Sum(r => r.spawnProbability);
            float rand = Random.Range(0f, totalWeight);
            float cumulative = 0f;

            foreach (RoomData room in copy)
            {
                cumulative += room.spawnProbability;
                if (rand <= cumulative)
                {
                    selected.Add(room);
                    copy.Remove(room);
                    break;
                }
            }
        }

        return selected;
    }

    public void SpawnRoom(GameObject roomPrefab)
    {
        if (currentRoom != null)
            Destroy(currentRoom);

        currentRoom = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity);
        currentRoom.SetActive(true);

        Transform entry = currentRoom.transform.Find("EntryPoint");
  
        var controller = player.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
            player.position = entry.position;
            controller.enabled = true;
        }
        else
        {
            player.position = entry.position;
        }
    }

}
