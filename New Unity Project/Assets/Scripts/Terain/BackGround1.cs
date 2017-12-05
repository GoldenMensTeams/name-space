using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround1 : MonoBehaviour
{

    public GameObject pl;

    private List<float> x_list_stay;
  
    private float x;
    private float y;

 
    public float ProzX;

    public float height_back_ground;
    public int count_save;


    public List<float> ProzY;
    public List<float> ProzSize;
    public List<MeshRenderer> List_Back_Ground;
    public List<float> List_Back_Ground_Speed;
    private List<Vector2> List_Back_Ground_Saved;



    void Start()
    {

        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;

        x_list_stay = new  List<float>();
       

        List_Back_Ground_Saved = new List<Vector2>();
        for (int i = 0; i < count_save; i++)
        {
            x_list_stay.Add(List_Back_Ground[i].transform.position.x);
          


            List_Back_Ground_Saved.Add(new Vector2());
        }
          
    }
    //void Move()
    //{
    //    transform.position = new Vector3(x + (x - pl.transform.position.x) / 5, y + (y - pl.transform.position.y - 20) / 5, +10f);
    //}
    // Update is called once per frame

    void MovePoz()
    {
        for (int i = 0; i < List_Back_Ground.Count; i++)
            List_Back_Ground[i].transform.position = new Vector3(pl.transform.position.x - x + x_list_stay[i], y / ProzSize[i] + (y - pl.transform.position.y) * ProzY[i], List_Back_Ground[i].transform.position.z);
        //(pl.transform.position.y - y / 2) + (y - pl.transform.position.y) * ProzY + height_back_ground
    }
    void Move(MeshRenderer mesh, Vector2 savedOffset, float speed)
    {
        Vector2 offset = Vector2.zero;
        float tmpX = Mathf.Repeat((x * speed), 1);
        //float tmpX = Mathf.Repeat(-(x + (x - pl.transform.position.x) * speed), 1);

        offset = new Vector2(tmpX, savedOffset.y);
        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
    void FixedUpdate()
    {
         MovePoz();
      
    }

    void Awake()
    {
        try
        {
            for (int i = 0; i < List_Back_Ground.Count; i++)
                if (List_Back_Ground[i])
                    List_Back_Ground_Saved[i] = List_Back_Ground[i].sharedMaterial.GetTextureOffset("_MainTex");
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    void Update()
    {
        for (int i = 0; i < List_Back_Ground.Count; i++)
            if (List_Back_Ground[i])
                Move(List_Back_Ground[i], List_Back_Ground_Saved[i], List_Back_Ground_Speed[i]);


    }

    void OnDisable()
    {
        try
        {
            for (int i = 0; i < List_Back_Ground.Count; i++)
                if (List_Back_Ground[i])
                    List_Back_Ground[i].sharedMaterial.SetTextureOffset("_MainTex", List_Back_Ground_Saved[i]);
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}
