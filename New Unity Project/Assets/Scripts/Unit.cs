using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour {

    public float maxHELS = 1f;
    public float HELS = 1f;
    public float speed = 5f;
    protected bool freez = true;

    public virtual void ReciveDamage(float _damag) { }

       
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void FreezModOn()
    {
        freez = false;
        gameObject.SetActive(freez);
    }

    public virtual void FreezModOff()
    {
        freez = true;
        gameObject.SetActive(freez);
    }
}
