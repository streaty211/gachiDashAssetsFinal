using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProggres : MonoBehaviour
{
    [Header("UI ref")]
    [SerializeField] private Image fillImage;

    [Header("player & endline ref")]
    [SerializeField] private GameObject playerTransform;
    [SerializeField] private GameObject endLineTransform;

    //private Vector2 endLinePosition;
    private float fullDistance;

    private float GetDistance()
    {
        return Vector2.Distance(playerTransform.transform.position, endLineTransform.transform.position);
    }

    private void UpdateProgressFill(float value)
    {
        fillImage.fillAmount = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        //endLinePosition = endLineTransform.transform.position;
        fullDistance = GetDistance();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endLineTransform.transform.position.x >= playerTransform.transform.position.x)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, -0.3f, newDistance);
            UpdateProgressFill(progressValue);
        }
    }
}
