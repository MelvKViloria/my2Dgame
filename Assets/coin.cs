using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class coin : MonoBehaviour
{
  private int gold = 0;
 
  [SerializeField] private Text goldText;
  [SerializeField] public AudioSource collect;
  private void OnTriggerEnter2D(Collider2D collision) 
  
 {
  if (collision.gameObject.CompareTag("coins"))
  {
    Destroy(collision.gameObject);
    gold++;
    goldText.text = "coins: " + gold;
  }
 }
}