using UnityEngine;

public class PlayerController_TrackY : PlayerController_Base
{
    public override void Update()
    {
        base.Update();
        transform.position = new Vector3(transform.position.x, ColorTracker.Instance.worldPosition.y, transform.position.z);
    }
}
