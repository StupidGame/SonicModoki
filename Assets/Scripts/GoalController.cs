using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalController : MonoBehaviour
{
    [SerializeField] private GameObject canbasText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Player = collision.gameObject;
        GameObject Camera = Player.transform.Find("Camera").gameObject;
        Camera.transform.parent = null;
        canbasText.GetComponent<TextMeshProUGUI>().text = "Game Clear!\nscore: " + Player.GetComponent<PlayerController>().score;
        canbasText.SetActive(true);
        Destroy(Player);
    }
}
