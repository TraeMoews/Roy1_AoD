using UnityEngine;

public class Bottom : MonoBehaviour
{
    //Do I really need to say
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
