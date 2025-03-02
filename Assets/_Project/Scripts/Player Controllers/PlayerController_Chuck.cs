using UnityEngine;

public class PlayerController_Chuck : PlayerController_Base
{
    [Header ("PlayerController_Chuck")]
    public float JumpForce = 10;
    public float Gravity = 9.81f * 2;
    public float YVelocity;
    public float VelocityThreshold = 5;
    private Vector2 LastPosition;
    // public GameObject JumpSFXPrefab;


    public override void Update()
    {
        base.Update();

        Vector2 currentPosition = ColorTracker.Instance.worldPosition;

        float currentXVelocity = (currentPosition.x - LastPosition.x) / Time.deltaTime;

        if (Mathf.Abs(currentXVelocity) > VelocityThreshold)
        {
            YVelocity = JumpForce;
            // Instantiate(JumpSFXPrefab, Vector2.zero, Quaternion.identity);
        }

        LastPosition = currentPosition;

        YVelocity -= Gravity * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y + YVelocity * Time.deltaTime, transform.position.z);
    }
}