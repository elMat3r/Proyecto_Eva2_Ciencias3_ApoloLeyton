using UnityEngine;
public class Player_Health : MonoBehaviour
{
    [Header("Life")]
    public float health;
    public float maxHealth = 1;
    private void Start()
    {
        health = maxHealth;
    }
    public void HealthFunction()
    {
        health -= 0.35f;
    }
    [Header("Otra Clase")]
    [SerializeField] private UI_Script uiScript;
    public SceneManager_Script sceneManager;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Meteorito"))
        {
            uiScript.meteorCounts++;
        }
        if(collision.collider.CompareTag("Asteroide Grande") || collision.collider.CompareTag("Asteroide Mediano"))
        {
            HealthFunction();
        }
    }
}
