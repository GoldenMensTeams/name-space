using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_element_paralax_3 : MonoBehaviour
{

  
    private float x;
    private float y;
    public float ProzY;
    public float ProzX;

    public List<GameObject> Object;
   
    public GameObject dot;


    private List<float> y_list_stay;

    void Start()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
      
        y_list_stay=  new List<float>();
        for (int i = 0; i < Object.Count; i++)
        {
            y_list_stay.Add(Object[i].transform.position.y);           
        }

    }
   
    
    void MovePoz()
    {
        //pl.transform.position.x - x + x_list[i]  y_list_stay[i] + (y - pl.transform.position.y) / ProzY

        for (int i = 0; i < Object.Count; i++)
            Object[i].transform.position = new Vector3(Object[i].transform.position.x,
               y_list_stay[i] - (y - dot.transform.position.y)+ProzY,
                Object[i].transform.position.z);
    }       

   

    void FixedUpdate()
    {
        MovePoz();
    }

   
}
