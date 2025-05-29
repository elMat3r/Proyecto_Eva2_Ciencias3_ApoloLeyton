using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    [Header("Elementos de UI")]
    [SerializeField] private TextMeshProUGUI textPoints;
    [SerializeField] private Image playerHealthImage;
    public float meteorCounts;

    [Header("Otras Clases")]
    public Player_Health playerHealthScript;
    public SceneManager_Script sceneManager;
    void Update()
    {
        textPoints.text = "Recolected Meteors: " + meteorCounts;
        playerHealthImage.fillAmount = playerHealthScript.health;
        if(meteorCounts >= 12)
        {
            sceneManager.Victory();
        }
        if(playerHealthImage.fillAmount <= 0)
        {
            sceneManager.Lose();
        }
    }
}
