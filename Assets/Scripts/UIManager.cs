using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]  private TMP_Text healthText;
    [SerializeField]  private Image[] batteryImages;
    [SerializeField]  private Image[] fuelImages;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateHealthText(PlayerState.currentHealth, PlayerState.maxHealth);
        for(int i = 0; i < PlayerInventory.batteryCount; i++)
        {
            Debug.Log("Displaying battery " + i);
            batteryImages[i].gameObject.SetActive(true);
        }
        for(int i = 0; i < PlayerInventory.fuelCount; i++)
        {
            Debug.Log("Displaying battery " + i);
            fuelImages[i].gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthText(float currentHealth, float maxHealth)
    {
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }

    public void DisplayBattery(int batteryCount)
    {
        batteryImages[batteryCount].gameObject.SetActive(true);
    }

    public void DisplayFuel(int fuelCount)
    {
        fuelImages[fuelCount].gameObject.SetActive(true);
    }
}
