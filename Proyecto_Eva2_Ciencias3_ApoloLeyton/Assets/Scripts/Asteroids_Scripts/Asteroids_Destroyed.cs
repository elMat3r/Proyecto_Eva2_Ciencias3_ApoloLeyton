using Unity.VisualScripting;
using UnityEngine;

public class Asteroids_Destroyed : MonoBehaviour
{
    public GameObject[] subAsteroids;
    public int asteroidsNumbers;

    private bool isDestroy = false;
    private void OnTriggerEnter(Collider other)
    {
        if (isDestroy) return;
        if (other.CompareTag("Bullet"))
        {
            isDestroy = true;
            Destroy(gameObject);
            Destroy(other.gameObject);
            for (var i = 0; i < asteroidsNumbers; i++)
            {
                Instantiate(subAsteroids[Random.Range(0, subAsteroids.Length)], transform.position, Quaternion.identity);
            }
        }
    }
}
