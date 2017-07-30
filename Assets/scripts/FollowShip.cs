using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    public Transform followTarget;
    public float followXOffset = 0f;
    public float followYOffset = 0f;

    private void Start()
    {
        if(followTarget == null) { Debug.LogError("followTarget property must be set"); }
    }
    // Update is called once per frame
    void Update()
    {
        float curZ = transform.position.z;
        var targetPos = followTarget.position;
        transform.position = new Vector3(targetPos.x + followXOffset, targetPos.y + followYOffset, curZ);
    }
}
