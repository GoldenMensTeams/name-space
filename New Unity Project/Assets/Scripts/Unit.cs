using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour {

    public float maxHELS = 1f;
    public float HELS = 1f;
    public float speed = 5f;
  

    public virtual void ReciveDamage(float _damag) { }
    private void Start()
    {
        
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

  
}
