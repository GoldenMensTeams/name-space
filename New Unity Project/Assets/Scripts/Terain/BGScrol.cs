using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrol : MonoBehaviour {
    public float backgroungSize;
    public GameObject pl;

    private Transform cameraTranform;
    private Transform[] layers;
    private float viewZome = 10;
    private int leftIndex;
    private int rightIndex;

    private void Start()
    {
        cameraTranform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);

        leftIndex = 0;
        rightIndex = layers.Length - 1;

    }
    private void Update()
    {
        if (cameraTranform.position.x < (layers[leftIndex].transform.position.x + viewZome))
            ScrolLeft();

        if (cameraTranform.position.x > (layers[rightIndex].transform.position.x - viewZome))
            ScrolRight();
    }
    private void ScrolLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroungSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }
    private void ScrolRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroungSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
         leftIndex = 0;
    }
}
