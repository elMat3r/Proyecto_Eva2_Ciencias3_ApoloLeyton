using UnityEngine;

public class Player_Health : MonoBehaviour
{
    //[Header("Life")]
    //public float health;
    //[SerializeField] private float maxHealth = 3;

    [Header("Otra Clase")]
    [SerializeField] private UI_Script uiScript;
    public SceneManager_Script sceneManager;
    //void Start()
    //{
    //    health = maxHealth;
    //}
    //public void Health()
    //{
    //    health -= 1;
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Meteorito")
        {
            uiScript.meteorCounts++;
        }
        //if(collision.collider.tag == "Asteroide Grande" ||  collision.collider.tag == "Asteroide Mediano")
        //{
        //    Health();
        //    sceneManager.Lose();
        //}
    }
}
