using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetScript : MonoBehaviour
{

    private Vector3 originalScale;

    public bool hitable;

    public TennisGameManager gm;

    public float timeToReappear;
    private float countingTime;
    private bool hit;//if the target has been hit by a ball

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) {
            countingTime += Time.deltaTime;
            if (countingTime >= timeToReappear) {
                countingTime = 0;
                hit = false;
                Reappear();
            }
        }
    }

    void Collapse() {
        hitable = false;
        transform.DOScale(new Vector3(0, 0, 0), .3f).SetEase(Ease.InOutBack);
    }

    void Reappear() {
        transform.DOScale(originalScale, .3f).SetEase(Ease.OutBack).OnComplete(()=> {
            hitable = true;
        });
    }

    private void OnTriggerEnter(Collider collider) {
        if (hitable) {
            hit = true;
            Collapse();
            gm.AddScore(10);
        }
    }
}
