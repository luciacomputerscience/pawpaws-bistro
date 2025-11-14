using System.Collections.Generic;
using UnityEngine;

public class CookStationControl : MonoBehaviour
{
    [SerializeField] private int numCookSlots = 3; // number of slots per station
    private List<Slot> cookSlots = new List<Slot>();
    private Renderer stationRenderer;

    [System.Serializable]
    public class Slot
    {
        public int slotNum;
        public bool full;
        public Vector3 position;
        public GameObject currentItem;
    }

    void Awake()
    {
        stationRenderer = GetComponent<Renderer>();
    }

    void Start()
    {
        CreateSlots();
    }

    private void CreateSlots()
    {
        cookSlots.Clear();

        if (stationRenderer == null)
        {
            Debug.LogWarning($"{name} has no Renderer to calculate bounds!");
            return;
        }

        Bounds bounds = stationRenderer.bounds;

        int cols = Mathf.CeilToInt(Mathf.Sqrt(numCookSlots));
        int rows = Mathf.CeilToInt((float)numCookSlots / cols);

        Vector3 min = bounds.min;
        Vector3 max = bounds.max;

        float xSpacing = (max.x - min.x) / Mathf.Max(1, cols - 1);
        float zSpacing = (max.z - min.z) / Mathf.Max(1, rows - 1);

        int index = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (index >= numCookSlots)
                    break;

                Vector3 slotPos = new Vector3(
                    min.x + c * xSpacing,
                    bounds.center.y + 0.05f, // slightly above surface
                    min.z + r * zSpacing
                );

                cookSlots.Add(new Slot
                {
                    slotNum = index + 1,
                    full = false,
                    position = slotPos
                });

                index++;
            }
        }

        Debug.Log($"{name} initialized with {cookSlots.Count} dynamic slots.");
    }

    public Slot GetEmptySlot()
    {
        foreach (var slot in cookSlots)
        {
            if (!slot.full)
                return slot;
        }
        return null;
    }

    public void PlaceItem(GameObject item)
    {
        Slot emptySlot = GetEmptySlot();
        if (emptySlot == null)
        {
            Debug.Log($"{name} has no empty slots!");
            return;
        }
        else
        {
            item.transform.position = emptySlot.position;
            item.transform.SetParent(transform);
            emptySlot.full = true;
            emptySlot.currentItem = item;
        }        
    }

    void OnDrawGizmosSelected()
    {
        if (cookSlots == null) return;
        Gizmos.color = Color.yellow;
        foreach (var slot in cookSlots)
        {
            Gizmos.DrawSphere(slot.position, 0.05f);
        }
    }
}
