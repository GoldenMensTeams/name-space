﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    public GameObject pl;
    private float x;
    private float y;
    public float ProzY;
    public float ProzX;
   
    public List<MeshRenderer> List_Back_Ground;
    public List<float> List_Back_Ground_Speed;
    private List<Vector2> List_Back_Ground_Saved;

   

    void Start () {
		x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
    }
    //void Move()
    //{
    //    transform.position = new Vector3(x + (x - pl.transform.position.x) / 5, y + (y - pl.transform.position.y - 20) / 5, +10f);
    //}
    // Update is called once per frame
    void MovePoz()
    {
        for (int i = 0; i <= List_Back_Ground.Count - 1; i++)
            List_Back_Ground[i].transform.position = new Vector3(pl.transform.position.x, y + (y - pl.transform.position.y) / ProzY, List_Back_Ground[i].transform.position.z);
    }
    void Move(MeshRenderer mesh, Vector2 savedOffset, float speed)
    {
        Vector2 offset = Vector2.zero;
        float tmpX = Mathf.Repeat(-(x + (x - pl.transform.position.x) / ProzX * speed), 1);

        offset = new Vector2(tmpX, savedOffset.y);
        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
    void FixedUpdate()
    {
        MovePoz();
    }

    void Awake()
    {
      for(int i=0;i <= List_Back_Ground.Count-1;i++)
        if (List_Back_Ground[i]) List_Back_Ground_Saved[i] = List_Back_Ground[i].sharedMaterial.GetTextureOffset("_MainTex");
      
    }

    void Update()
    {
        for (int i = 0; i <= List_Back_Ground.Count - 1; i++)
            if (List_Back_Ground[i]) Move(List_Back_Ground[i], List_Back_Ground_Saved[i], List_Back_Ground_Speed[i]);
   

    }

    void OnDisable()
    {
        for (int i = 0; i <= List_Back_Ground.Count - 1; i++)
            if (List_Back_Ground[i]) List_Back_Ground[i].sharedMaterial.SetTextureOffset("_MainTex", List_Back_Ground_Saved[i]);
        
    }
}
