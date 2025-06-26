using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    [Header("Life")]
    public Image barLife;
    private int maxLives = 3;
    private int currentLife;

    [Header("Otra Clase")]
    [SerializeField] private UI_Script uiScript;
    public SceneManager_Script sceneManager;
    public int CurrentLife
    {
        get { return currentLife; }
        set { currentLife = Mathf.Clamp(value, 0, maxLives);
            HealthUpdated();
            if(currentLife <= 0)
            {
                sceneManager.Lose();
            }
        }
    }
    private void Start()
    {
        currentLife = maxLives;
        HealthUpdated();
    }
    void HealthUpdated()
    {
        if(barLife != null)
        {
            barLife.fillAmount = (float)currentLife/maxLives;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Meteorito"))
        {
            uiScript.meteorCounts++;
        }
        else if(collision.collider.CompareTag("Asteroide Grande")|| collision.collider.CompareTag("Asteroide Mediano"))
        {
            CurrentLife--;
        }
    }
}
