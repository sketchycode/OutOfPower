using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class FollowShip : MonoBehaviour
{
    public Transform followTarget;

    public float uiSliceLeftBorder = 259f;
    public float uiSliceRightBorder = 39;

    private Camera cam;

    private void Start()
    {
        if(followTarget == null) { Debug.LogError("followTarget property must be set"); }
        cam = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        float sizeUnitsPerPixel = (cam.orthographicSize * 2) / Screen.height;
        float xOffset = ((uiSliceLeftBorder - uiSliceRightBorder) / 2f) * sizeUnitsPerPixel;
        float curZ = transform.position.z;
        var targetPos = followTarget.position;
        transform.position = new Vector3(targetPos.x - xOffset, targetPos.y, curZ);
    }
}
