using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ww_Occlusion : MonoBehaviour
{
    public GameObject Audiolistener;
    public bool UseOcclusion = false;
    public string RTPC_LoPass = "RTPC_Occlusion_LoPass";
    public string RTPC_Volume = "RTPC_Occlusion_Volume";
    public float LoPass_Max = 1;
    public float Volume_Max = 1;
    public bool UseDebug = false;
    public LayerMask OccludeLayer;

    public float checkInterval = 0.2f; // Occlusion check interval in seconds, the higher the value the lower the CPU cost. 
    private float timer = 0f;

    private Vector3 lastHitPoint;
    private bool isOccluded;

    [Tooltip("Set the starting occlusion volume. Use this to pre-occlude sounds at level start.")]
    public float startingOcclusionVolume = 0f;

    void Start()
    {
        OccludeLayer = LayerMask.GetMask("Occlude Sound");
        
        // Apply the starting occlusion volume
        AkSoundEngine.SetRTPCValue(RTPC_Volume, startingOcclusionVolume, gameObject);
        
        // Optionally, you might want to set the LoPass filter as well
        AkSoundEngine.SetRTPCValue(RTPC_LoPass, startingOcclusionVolume > 0 ? LoPass_Max : 0, gameObject);

        // Perform an immediate occlusion check
        PerformOcclusionCheck();
    }

    void Update()
    {
        if (!UseOcclusion || Audiolistener == null) { return; }

        timer += Time.deltaTime;

        if (timer >= checkInterval)
        {
            timer = 0f;
            PerformOcclusionCheck();
        }

        // Draw debug line every frame when UseDebug is enabled
        if (UseDebug)
        {
            DrawDebugLines();
        }
    }

    void PerformOcclusionCheck()
    {
        Vector3 listenerPosition = Audiolistener.transform.position;
        Vector3 emitterPosition = this.transform.position;

        RaycastHit hit;
        isOccluded = Physics.Linecast(listenerPosition, emitterPosition, out hit, OccludeLayer);

        if (isOccluded && hit.collider.gameObject != this.gameObject)
        {
            lastHitPoint = hit.point;
            AkSoundEngine.SetRTPCValue(RTPC_LoPass, LoPass_Max, gameObject);
            AkSoundEngine.SetRTPCValue(RTPC_Volume, Volume_Max, gameObject);
        }
        else
        {
            AkSoundEngine.SetRTPCValue(RTPC_LoPass, 0, gameObject);
            AkSoundEngine.SetRTPCValue(RTPC_Volume, 0, gameObject);
        }
    }

    void DrawDebugLines()
    {
        Vector3 listenerPosition = Audiolistener.transform.position;
        Vector3 emitterPosition = this.transform.position;
        
        if (isOccluded)
        {
            Debug.DrawLine(listenerPosition, lastHitPoint, Color.red);
            Debug.DrawLine(lastHitPoint, emitterPosition, Color.yellow);
        }
        else
        {
            Debug.DrawLine(listenerPosition, emitterPosition, Color.green);
        }
    }
}
