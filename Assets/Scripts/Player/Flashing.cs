using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    [SerializeField] float quantityFlashRatePerSecond = 2f;
    [SerializeField] float timeInvulnerability = 3;
    [SerializeField] float timeInIviseble;

    float timerForInvulnerability;
    float timeBetweenFlashing;
    float time;
    float timerForInviseble;


    MeshRenderer meshRenderer;

    [SerializeField] List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
    void Start()
    {
        timeBetweenFlashing = 1f / quantityFlashRatePerSecond;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderers.Add(meshRenderer);
    }

    public void ToBlink(float deltaTime)
    {
        timerForInvulnerability += deltaTime;
        if (timerForInvulnerability >= timeInvulnerability)
        {
            return;
        }

        time += deltaTime;
        if (timeBetweenFlashing <= time)
        {
            meshRenderers.ForEach(mr=>mr.enabled = false);
            timerForInviseble += deltaTime;
            if (timerForInviseble >= timeInIviseble)
            {
                meshRenderers.ForEach(mr => mr.enabled = true);
                timerForInviseble = 0;
                time = 0;
            }
        }
    }

    public void ResetTimers()
    {
        timerForInvulnerability = 0;
        timeBetweenFlashing = 0;
        time = 0;
        timerForInviseble = 0;
    }   
}        
