using UnityEngine;

public class BlackHole_Zone : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        BlackHole_Function blackHole_Function = other.GetComponent<BlackHole_Function>();
        if(blackHole_Function != null)
        {
            blackHole_Function.BlackHolePhysics();
        }
    }
}
