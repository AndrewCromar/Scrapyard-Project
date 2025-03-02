using UnityEngine;
using UnityEngine.UI;

public class ColorTracker : MonoBehaviour
{
    [HideInInspector] public static ColorTracker Instance;  // Fix the typo from "Intance" to "Instance"

    public RawImage display;
    public GameObject trackedObject;
    public Color targetColor = Color.red;
    public float threshold = 50f;

    public Vector2 position; // Store the position of the tracked color (screen space)
    public Vector2 worldPosition; // Store the world position of the tracked color

    private WebCamTexture webcamTexture;

    void Awake() => Instance = this;

    void Start()
    {
        webcamTexture = new WebCamTexture();
        display.texture = webcamTexture;
        webcamTexture.Play();

        // Mirror the webcam image visually
        MirrorWebCamImage();
    }

    void Update()
    {
        // Check if the webcam is playing before processing
        if (webcamTexture == null || !webcamTexture.isPlaying || webcamTexture.width < 100) return;

        Color32[] pixels = webcamTexture.GetPixels32();
        int width = webcamTexture.width;
        int height = webcamTexture.height;

        int count = 0;
        float sumX = 0;
        float sumY = 0;

        // Loop through all the pixels to find the matching color
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Adjust x to account for the mirrored feed
                int mirroredX = width - x - 1;

                Color32 pixel = pixels[y * width + mirroredX]; // Get the pixel from the mirrored position
                if (IsColorMatch(pixel, targetColor, threshold))
                {
                    sumX += x;
                    sumY += y;
                    count++;
                }
            }
        }

        // If we found matching colors, calculate the average position
        if (count > 0)
        {
            float avgX = sumX / count;
            float avgY = sumY / count;

            position = new Vector2(avgX, avgY);  // Store the position of the tracked color

            // Convert to world position and store it
            UpdateWorldPosition(avgX, avgY, width, height);

            // Move the object based on the average position
            MoveObject(avgX, avgY, width, height);
        }
    }

    // Check if the color of the pixel matches the target color within a threshold
    bool IsColorMatch(Color32 pixel, Color target, float threshold)
    {
        float diff = Mathf.Abs(pixel.r - target.r * 255) + Mathf.Abs(pixel.g - target.g * 255) + Mathf.Abs(pixel.b - target.b * 255);
        return diff < threshold;
    }

    // Update the world position of the tracked color
    void UpdateWorldPosition(float x, float y, int imgWidth, int imgHeight)
    {
        Vector3 screenPos = new Vector3(x / imgWidth * Screen.width, y / imgHeight * Screen.height, 10);
        worldPosition = Camera.main.ScreenToWorldPoint(screenPos);  // Update world position
    }

    // Move the tracked object based on the screen position
    void MoveObject(float x, float y, int imgWidth, int imgHeight)
    {
        Vector3 screenPos = new Vector3(x / imgWidth * Screen.width, y / imgHeight * Screen.height, 10);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        trackedObject.transform.position = new Vector3(worldPos.x, worldPos.y, trackedObject.transform.position.z);
    }

    // Mirror the webcam image horizontally
    void MirrorWebCamImage()
    {
        // Flip the RawImage horizontally
        if (display != null)
        {
            RectTransform rt = display.GetComponent<RectTransform>();
            if (rt != null)
            {
                rt.localScale = new Vector3(-1, 1, 1);  // Flip horizontally (mirror effect)
            }
        }
    }

    // Terminate the webcam
    public void TerminateWebcam()
    {
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
            webcamTexture = null;
        }
    }
}
