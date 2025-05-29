using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    [SerializeField] private float life;

    private void Awake()
    {
        Destroy(gameObject, life);
    }
}
