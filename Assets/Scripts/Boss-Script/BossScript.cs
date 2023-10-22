using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class BossScript : MonoBehaviour
{

  public int Health = 100;

  [SerializeField] Slider healthbar;
  [SerializeField] GameObject projectile1;
  [SerializeField] GameObject projectile2;
  [SerializeField] GameObject projectile3;
  [SerializeField] Sprite Phase2;
  [SerializeField] Sprite Dead;
  public  AudioClip Death;
  public  AudioClip Start;

  public int Attack1ProjSpeed = 6;

//boss attacks once every second = delay. 
  private float Delay = 1f;
  private bool attack2Once = false;
  void Awake()
  {
    GameObject Player = GameObject.FindWithTag("Player");
      AudioSource.PlayClipAtPoint(Start, new Vector2(0, 0));


  }

  void Update()
  {

    healthbar.value = Health;

//Proceeds the game into the gameover screen


    //If the boss's health is below 50, it evolves into phase 2, (faster attack speed, introduce special attack, more attacks)
    if (Health > 50)
    {
      Phase1Method();
    }
    else if (Health == 50 && attack2Once == false)
    {
      Attack2();
      attack2Once = true;
    }
    else if (Health < 50)
    {
      GetComponent<SpriteRenderer>().sprite = Phase2;
      Phase2Method();
    }

    if (Health <= 0)
    {
      GetComponent<SpriteRenderer>().sprite = Dead;
        AudioSource.PlayClipAtPoint(Death, new Vector2(0, 0));
      SceneManager.LoadScene(3);
    }


  }




//bosses phase 1 method, 95% chance of normal attack, 5% to produce homing missile
  void Phase1Method()
  {
    Attack1ProjSpeed = 6;
    if (Delay > 0)
    {
      Delay -= Time.deltaTime;
    }
    else if (Delay < 0)
    {
      if (UnityEngine.Random.Range(1, 20) >= 2)
      {
        Attack1(UnityEngine.Random.Range(1, 360));
      }
      else
      {
        Attack3(UnityEngine.Random.Range(1, 360));
      }
      Delay = 1f;
    }
  }



//phase 2 method, 73% for normal attack, 13% for bombs, 6% for homing. 
  void Phase2Method()
  {
    Attack1ProjSpeed = 8;
    if (Delay > 0)
    {
      Delay -= Time.deltaTime;
    }
    else if (Delay < 0)
    {
      if (UnityEngine.Random.Range(1, 15) > 3)
      {
        Attack1(UnityEngine.Random.Range(1, 360));

      }
      else if (UnityEngine.Random.Range(1, 12) < 4 && UnityEngine.Random.Range(1, 12) > 2)
      {
        Attack2();
      }
      else
      {
        Attack3(UnityEngine.Random.Range(1, 360));
      }

      Delay = 0.6f;
    }

  }

  void Attack1(int Offset)
  {


    for (int i = 0; i < 20; i++)
    {
      Instantiate(projectile1, transform.position, Quaternion.Euler(0, 0, i * 45 + Offset));
    }

  }
  void Attack2()
  {
    for (int i = 0; i < UnityEngine.Random.Range(8, 18); i++)
    {
      Vector2 spawn = new Vector2(transform.position.x - UnityEngine.Random.Range(-12, 12), transform.position.y - UnityEngine.Random.Range(-12, 12));
      Instantiate(projectile2, spawn, Quaternion.identity);
    }
  }
  void Attack3(int Offset)
  {


    for (int i = 0; i < 8; i++)
    {
      Instantiate(projectile3, transform.position, Quaternion.Euler(0, 0, i * 45 + Offset));
    }

  }
}
