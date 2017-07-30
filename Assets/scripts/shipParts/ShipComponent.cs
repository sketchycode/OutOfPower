using UnityEngine;

public abstract class ShipComponent : MonoBehaviour
{
    public KeyCode controlKey = KeyCode.Space;

    public abstract float ProcessForFrame(ShipController ship, float elapsedTime);

    private bool isActivated = false;

    public bool IsActivated
    {
        get
        {
            return isActivated;
        }
        protected set
        {
            bool oldValue = value;
            if (value != isActivated)
            {
                isActivated = value;
                OnIsActivatedChanged(value);
            }
        }
    }

    public virtual void Reset()
    {
        IsActivated = false;
    }

    protected virtual void OnIsActivatedChanged(bool newValue)
    {

    }
}