using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    [SerializeField] float lifetime = 5f;
    

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    
    void Update()
    {
        
    }
}
