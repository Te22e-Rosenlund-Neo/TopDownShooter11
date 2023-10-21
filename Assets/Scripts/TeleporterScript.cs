using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TeleporterScript : MonoBehaviour
{
    // Start is called before the first frame update


[SerializeField] string Playertag;







private void OnTriggerEnter2D(Collider2D other) {
    
if(other.tag == Playertag){
    SceneManager.LoadScene(2);
    other.GetComponent<Transform>().position = new Vector2(0,-10);
    other.GetComponent<PlayerMove>().ChangeTargetedSlider = true;
    other.GetComponent<PlayerMove>().PlayerHealth ++;
}



}








}
