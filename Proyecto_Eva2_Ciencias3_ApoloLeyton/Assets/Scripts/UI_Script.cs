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

    [Header("Otras Clases")]
    public SceneManager_Script sceneManager;
    void Update()
    {
        textPoints.text = "Recolected Meteors: " + meteorCounts;
        if(meteorCounts >= 50)
        {
            sceneManager.Victory();
        }
    }
}
