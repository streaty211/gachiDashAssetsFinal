using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ison : MonoBehaviour
{
    public static event OnScoreChange onScoreChange;
    public delegate void OnScoreChange();

    private void OnTriggerEnter2D(Collider2D collision)
    {
            onScoreChange?.Invoke();
            Destroy(gameObject);
        //if (collision.CompareTag("Money"))
            //Destroy(collision.gameObject);
    }
}
