﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public GameObject ControlScheme;
    public Sprite Coin;
    public Sprite Jonesy;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Main Scene");
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Movement()
    {
        animator.enabled = true;
        animator.SetBool("Move", true);
        animator.SetBool("Crouch", false);
        animator.SetBool("Run", false);
        animator.SetBool("Fight", false);
        animator.SetBool("Shoot", false);
        animator.SetBool("Block", false);
    }

    public void Crouch()
    {
        animator.enabled = true;
        animator.SetBool("Crouch", true);
        animator.SetBool("Move", false);
        animator.SetBool("Run", false);
        animator.SetBool("Fight", false);
        animator.SetBool("Shoot", false);
        animator.SetBool("Block", false);
    }

    public void Run()
    {
        animator.enabled = true;
        animator.SetBool("Run", true);
        animator.SetBool("Move", false);
        animator.SetBool("Crouch", false);
        animator.SetBool("Fight", false);
        animator.SetBool("Shoot", false);
        animator.SetBool("Block", false);
    }

    public void Fight()
    {
        animator.enabled = true;
        animator.SetBool("Fight", true);
        animator.SetBool("Move", false);
        animator.SetBool("Crouch", false);
        animator.SetBool("Run", false);
        animator.SetBool("Shoot", false);
        animator.SetBool("Block", false);
    }

    public void Shoot()
    {
        animator.enabled = true;
        animator.SetBool("Shoot", true);
        animator.SetBool("Move", false);
        animator.SetBool("Crouch", false);
        animator.SetBool("Run", false);
        animator.SetBool("Fight", false);
        animator.SetBool("Block", false);
    }

    public void Reset()
    {
        animator.enabled = true;
        animator.SetBool("Shoot", false);
        animator.SetBool("Move", false);
        animator.SetBool("Crouch", false);
        animator.SetBool("Run", false);
        animator.SetBool("Fight", false);
        animator.SetBool("Block", false);
    }

    public void Block()
    {
        animator.enabled = true;
        animator.SetBool("Block", true);
        animator.SetBool("Shoot", false);
        animator.SetBool("Move", false);
        animator.SetBool("Crouch", false);
        animator.SetBool("Run", false);
        animator.SetBool("Fight", false);
    }

    public void PowerUp()
    {
        animator.enabled = false;
        spriteRenderer.sprite = Coin;
        animator.SetBool("Shoot", false);
        animator.SetBool("Move", false);
        animator.SetBool("Crouch", false);
        animator.SetBool("Run", false);
        animator.SetBool("Fight", false);
        animator.SetBool("Block", false);
    }

    public void Checkpoint()
    {
        animator.enabled = false;
        spriteRenderer.sprite = Jonesy;
        animator.SetBool("Shoot", false);
        animator.SetBool("Move", false);
        animator.SetBool("Crouch", false);
        animator.SetBool("Run", false);
        animator.SetBool("Fight", false);
        animator.SetBool("Block", false);
    }
}
