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


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        for (int i = 0; i < batteryImages.Length; i++)
        {
            batteryImages[i].enabled = false;
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
        batteryImages[batteryCount].enabled = true;
    }
}
