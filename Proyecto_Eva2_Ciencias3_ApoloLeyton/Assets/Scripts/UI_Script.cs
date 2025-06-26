using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    [Header("Elementos de UI")]
    [SerializeField] private TextMeshProUGUI textPoints;
    public float meteorCounts;
    public Image healthBar;

    [Header("Otras Clases")]
    public SceneManager_Script sceneManager;
    public Player_Health playerHealth;
    void Update()
    {
        textPoints.text = "Recolected Meteors: " + meteorCounts;
        healthBar.fillAmount = playerHealth.health;
        if(meteorCounts >= 50)
        {
            sceneManager.Victory();
        }
        if(healthBar.fillAmount <= 0)
        {
            sceneManager.Lose();
        }
    }
}
