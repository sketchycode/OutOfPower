using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class FollowUV : MonoBehaviour
{
    public float paralax = 2f;

    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        var curOffset = material.mainTextureOffset;
        curOffset.x = transform.position.x / transform.localScale.x / paralax;
        curOffset.y = transform.position.y / transform.localScale.y / paralax;

        material.mainTextureOffset = curOffset;
    }
}
