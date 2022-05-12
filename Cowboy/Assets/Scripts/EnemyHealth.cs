using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Text hpText;
    [SerializeField] private int _health = 200;
    
    private int _damage=50;
    private void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            _health = _health - _damage;
        }
    }
    private void FixedUpdate()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
        hpText.text = _health.ToString();
    } 
}
