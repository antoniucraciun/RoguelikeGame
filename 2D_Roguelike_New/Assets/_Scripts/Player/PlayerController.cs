using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Stats playerStats;
    public Inventory playerInventory;

    private void Start()
    {
        playerStats = GetComponent<Stats>();
        playerInventory = GetComponent<Inventory>();
    }
}
