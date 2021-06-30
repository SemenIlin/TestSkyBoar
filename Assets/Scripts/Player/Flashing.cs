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

    bool isEndFlashing;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;

    [SerializeField] List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;

        timeBetweenFlashing = 1f / quantityFlashRatePerSecond;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderers.Add(meshRenderer);
    }

    public void ToBlink(float deltaTime)
    {
        timerForInvulnerability += deltaTime;
        if (timerForInvulnerability >= timeInvulnerability)
        {
            if (!isEndFlashing)
            {
                isEndFlashing = true;
                boxCollider.enabled = true;
                meshRenderers.ForEach(mr => mr.enabled = true);
            }
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

    public void DisableCollider()
    {
        boxCollider.enabled = false;
    }

    public void ResetTimers()
    {
        timerForInvulnerability = 0;
        time = 0;
        timerForInviseble = 0;
        isEndFlashing = false;
    }   
}        
