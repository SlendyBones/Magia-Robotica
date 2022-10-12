using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMultiAttacks : MonoBehaviour
{
    public Animator animator;
    public int numOfAttack = 1;  //Numero del ataque a realizar 
    public int totalAttacks;  //Cantidad total de ataques que se pueden realizar consecutivamente
    bool canAttack = true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))  //Al apretar el boton del mouse
        {
            animator.SetBool("Attack" + numOfAttack, true);  //Hace que el bool del ataque en curso se vualva true
            if (!canAttack) return;
            if (numOfAttack >= totalAttacks) //Si se pasa del maximo vuelve a empezar
            {
                numOfAttack = 1;
            }
            else
            {
                numOfAttack++;
            }

            canAttack = false;
        }
    }

    public void OnFinishAnimation(int currentAnimation)
    {
        canAttack = true;
        Debug.Log("hola");

        animator.SetBool("Attack" + currentAnimation, false);
    }

    public void OnBackToIdle()
    {
        numOfAttack = 1;
    }
}
