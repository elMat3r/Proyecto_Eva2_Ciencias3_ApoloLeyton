using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    [SerializeField] private float life;

    private void Awake()
    {
        Destroy(gameObject, life);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroide Grande"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag("Asteroide Mediano"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
