using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletSpeed;

    private PoolObject _poolObject;
    private GameObject _startPos;
    private Vector3 _direction;
    
    private void Start()
    {
        _poolObject = GetComponent<PoolObject>();
        _startPos = GameObject.FindGameObjectWithTag("Gun");


    }
    private void OnEnable()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            _direction = hit.point;
        }
        StartCoroutine(Destroy());
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce((_direction - _startPos.transform.position).normalized * bulletSpeed);
        StartCoroutine(Destroy());
    }
    private void OnCollisionEnter(Collision collision)
    {
            _poolObject.ReturnToPool();
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(4);
        _poolObject.ReturnToPool();
    }
}
