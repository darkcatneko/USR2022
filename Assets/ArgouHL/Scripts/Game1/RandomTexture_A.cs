using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTexture_A : MonoBehaviour
{
    [SerializeField] List<Texture> TextureList = new List<Texture>();
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;

    void Start()
    {
        skinnedMeshRenderer.material.mainTexture = TextureList[Random.Range(0, TextureList.Count)];
    }
}
