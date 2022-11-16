using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Flamethrower : MonoBehaviour
{

    /*
     * 1.particleSystem en loop, controlar activacion con script
     * 2.particleSystem sin lopp, ajustar duracion por codigo
     * 3. crear eventos serializados, hacerlo todo desde editor
     
         
     */


    enum State
    {
        Stopped,
        Attacking
    }

    [SerializeField] private float attackDuration = 2; //duracion del ataque
    [SerializeField] private float tickDelay = 0.5f; //cada cuando hace el dmg
    [SerializeField] private float damage = 1; //cada cuando hace el dmg

    [SerializeField] private Vector3 queryPosition; //posicion de spawn
    [SerializeField] private Vector3 queryScale;    //tamaño del cubo  
    [SerializeField] private ParticleSystem ps;

    [SerializeField] private ParticleSystem ps2;

    [SerializeField] private ParticleSystem ps3;
    [SerializeField] private UnityEvent onStart, onStop;

    private State state;
    private float attackTimer;
    private float tickTimer;

    #region Cada frame
    private void Update()
    {

        #region estado 1
        if (state == State.Stopped)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                state = State.Attacking;
                //ps.Play();

                ParticleSystem.MainModule main = ps2.main;

                main.duration = attackDuration;

                //ps2.Play();

                onStart.Invoke();
            }
            
        }

        #endregion

        #region estado2
        if (state == State.Attacking)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer > attackDuration)
            {
                state = State.Stopped;
                // ps.Stop();

                //ps2.Stop();

                onStop.Invoke();
                attackTimer = 0;

            }

            tickTimer += Time.deltaTime;

            if (tickTimer > tickDelay)
            {
                //ApplyDamage
                Collider[] overllaped = Physics.OverlapBox(transform.position + queryPosition, queryScale / 2.0f, Quaternion.identity);
                for (int i = 0; i < overllaped.Length; i++)
                {
                    Debug.Log(damage);
                }
                tickTimer = 0;
            }
        }
        #endregion
    }

    #endregion

    //condicional en tiempo de compilacion

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color( 1f, 0f, 1f,0.5f);
        Gizmos.DrawCube(transform.position+queryPosition, queryScale);
    }
#endif


}
