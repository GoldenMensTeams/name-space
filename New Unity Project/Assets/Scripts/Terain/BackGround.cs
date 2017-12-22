using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    public InputRaven  pl1;
    public InputHedgehog pl2;
    private GameObject obj;
    private float x;
    private float y;
    public float ProzY;
    public float ProzX;
    public float height_back_ground;
    public int count_save;

    public List<MeshRenderer> List_Back_Ground;
    public List<float> List_Back_Ground_Speed;
    private List<Vector2> List_Back_Ground_Saved;

 

    void Start()
    {
        if (pl1.Activ)
            obj = pl1.gameObject;
        else
            obj = pl2.gameObject;

        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        List_Back_Ground_Saved = new List<Vector2>();
     
        for (int i = 0; i < count_save; i++)
        {
          
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
        //pl.transform.position.x - x + x_list[i]

        for (int i = 0; i < List_Back_Ground.Count; i++)
            List_Back_Ground[i].transform.position = new Vector3(obj.transform.position.x,
               (obj.transform.position.y -y/2)+ (y - obj.transform.position.y)*ProzY + height_back_ground,
                List_Back_Ground[i].transform.position.z);
      //  y + (y - pl.transform.position.y) + height_back_ground,
    }
    void Move(MeshRenderer mesh, Vector2 savedOffset, float speed)
    {
        Vector2 offset = Vector2.zero;
        float tmpX = Mathf.Repeat(-(x + (x - obj.transform.position.x) / ProzX * speed), 1);

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
                if (List_Back_Ground[i]) List_Back_Ground_Saved[i] = List_Back_Ground[i].sharedMaterial.GetTextureOffset("_MainTex");
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    void Update()
    {
        if (pl1.Activ)
            obj = pl1.gameObject;
        else
            obj = pl2.gameObject;

      

        for (int i = 0; i < List_Back_Ground.Count; i++)
            if (List_Back_Ground[i]) Move(List_Back_Ground[i], List_Back_Ground_Saved[i], List_Back_Ground_Speed[i]);

      
    }

    void OnDisable()
    {
        try
        {
            for (int i = 0; i < List_Back_Ground.Count; i++)
                if (List_Back_Ground[i]) List_Back_Ground[i].sharedMaterial.SetTextureOffset("_MainTex", List_Back_Ground_Saved[i]);
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}
