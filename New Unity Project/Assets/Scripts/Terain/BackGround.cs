using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    public GameObject pl;
    private float x;
    private float y;
    public float ProzY;
    public float ProzX;

    public MeshRenderer firstBG;
    public float firstBGSpeed = 0.01f;
    private Vector2 savedFirst;

    public MeshRenderer secondBG;
    public float secondBGSpeed = 0.05f;
    private Vector2 savedSecond;


    public MeshRenderer BG3;
    public float BGSpeed3 = 0.05f;
    private Vector2 saved3;

    public MeshRenderer BG4;
    public float BGSpeed4 = 0.05f;
    private Vector2 saved4;

    public MeshRenderer BG5;
    public float BGSpeed5 = 0.05f;
    private Vector2 saved5;

    public MeshRenderer BG6;
    public float BGSpeed6 = 0.05f;
    private Vector2 saved6;

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
        if (secondBG) savedSecond = secondBG.sharedMaterial.GetTextureOffset("_MainTex");
        if (BG3) saved3 = BG3.sharedMaterial.GetTextureOffset("_MainTex");
        if (BG4) saved4 = BG4.sharedMaterial.GetTextureOffset("_MainTex");
        if (BG5) saved5 = BG5.sharedMaterial.GetTextureOffset("_MainTex");
        if (BG6) saved6 = BG6.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        if (firstBG) Move(firstBG, savedFirst, firstBGSpeed);
        if (secondBG) Move(secondBG, savedSecond, secondBGSpeed);
        if (BG3) Move(BG3, saved3, BGSpeed3);
        if (BG4) Move(BG4, saved4, BGSpeed4);
        if (BG5) Move(BG5, saved5, BGSpeed5);
        if (BG6) Move(BG6, saved6, BGSpeed6);

    }

    void OnDisable()
    {
        if (firstBG) firstBG.sharedMaterial.SetTextureOffset("_MainTex", savedFirst);
        if (secondBG) secondBG.sharedMaterial.SetTextureOffset("_MainTex", savedSecond);
        if (BG3) BG3.sharedMaterial.SetTextureOffset("_MainTex", saved3);
        if (BG4) BG4.sharedMaterial.SetTextureOffset("_MainTex", saved4);
        if (BG5) BG5.sharedMaterial.SetTextureOffset("_MainTex", saved5);
        if (BG6) BG6.sharedMaterial.SetTextureOffset("_MainTex", saved6);
    }
}
