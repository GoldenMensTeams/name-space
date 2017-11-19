using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround1 : MonoBehaviour {

    public GameObject pl;
    private float x;
    private float y;
    public float ProzY;
    public float ProzX;
   
    public MeshRenderer firstBG;
    public float firstBGSpeed = 0.01f;
    private Vector2 savedFirst;

   

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
        
        transform.position = new Vector3(pl.transform.position.x, y + (y - pl.transform.position.y) / ProzY, transform.position.z);
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
        if (firstBG) savedFirst = firstBG.sharedMaterial.GetTextureOffset("_MainTex");
        
    }

    void Update()
    {
        if (firstBG) Move(firstBG, savedFirst, firstBGSpeed);
      

    }

    void OnDisable()
    {
        if (firstBG) firstBG.sharedMaterial.SetTextureOffset("_MainTex", savedFirst);
      
    }
}
