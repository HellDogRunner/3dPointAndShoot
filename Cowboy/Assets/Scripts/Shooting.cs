using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shooting : MonoBehaviour
{

    private Pool _pool;
    private GameObject _startPos;
    private void Start()
    {
        _startPos = GameObject.FindGameObjectWithTag("Gun");
        _pool = GetComponent<Pool>();
    }
    private void Update()
    {     
        if (Input.GetMouseButtonDown(0))
        {
            _pool.GetFreeElement(_startPos.transform.position, transform.rotation);
        }
        
    }

}
