using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public void ReturnToPool() 
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
    
    }
}
