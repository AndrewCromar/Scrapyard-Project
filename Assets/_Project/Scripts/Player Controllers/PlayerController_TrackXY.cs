using UnityEngine;

public class PlayerController_TrackXY : PlayerController_Base
{
    public override void Update()
    {
        base.Update();
        transform.position = new Vector3(ColorTracker.Instance.worldPosition.x, ColorTracker.Instance.worldPosition.y, transform.position.z);
    }
}
