using UnityEngine;

public abstract class ShipComponent : MonoBehaviour
{
    public KeyCode controlKey = KeyCode.Space;

    public abstract float ProcessForFrame(ShipController ship, float elapsedTime);

    public bool IsActivated { get; protected set; }
}