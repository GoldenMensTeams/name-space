using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrol : MonoBehaviour
{
    public float backgroungSize;
    public float paralacSpeed;
    public InputRaven pl1;
    public InputHedgehog pl2;
    private GameObject obj;

    public bool paralax, scrolling;

    private Transform cameraTranform;
    private Transform[] layers;
    private float viewZome = 10;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;

    private float y;
    private float z;
    private float x;

    private void Start()
    {
        if (pl1.Activ)
            obj = pl1.gameObject;
        else
            obj = pl2.gameObject;

        x = transform.position.x;
        cameraTranform = Camera.main.transform;
        lastCameraX = cameraTranform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);

        leftIndex = 0;
        rightIndex = layers.Length - 1;

    }
    private void Update()
    {
        if (pl1.Activ)
            obj = pl1.gameObject;
        else
            obj = pl2.gameObject;

        if (paralax)
        {
            //float deltax = cameraTranform.position.x - lastCameraX;
            //transform.position += Vector3.right * (deltax * paralacSpeed*0.5f);


          
                transform.position = new Vector3(obj.transform.position.x + (x - obj.transform.position.x) / paralacSpeed,
                    transform.position.y,
                    transform.position.z);
        }

        lastCameraX = cameraTranform.position.x;

        if (scrolling)
        {
            if (cameraTranform.position.x < (layers[leftIndex].transform.position.x + viewZome))
                ScrolLeft();

            if (cameraTranform.position.x > (layers[rightIndex].transform.position.x - viewZome))
                ScrolRight();
        }


    }
    private void ScrolLeft()
    {
        y = layers[rightIndex].transform.position.y;
        z = layers[rightIndex].transform.position.z;

        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroungSize);

        layers[rightIndex].transform.position = new Vector3(layers[rightIndex].transform.position.x, y,z);

        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;

    }
    private void ScrolRight()
    {
        y = layers[leftIndex].transform.position.y;
        z = layers[rightIndex].transform.position.z;

        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroungSize);


        layers[leftIndex].transform.position = new Vector3(layers[leftIndex].transform.position.x, y,z);

        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
}
