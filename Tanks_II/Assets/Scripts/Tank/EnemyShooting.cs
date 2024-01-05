using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
    /*public GameObject m_Shell;
    public Transform m_FireTransform;
    private float m_ChargeSpeed;*/
    public int m_PlayerNumber = 1;              // Used to identify the different players.
    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
    public Slider m_AimSlider;                  // A child of the tank that displays the current launch force.
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
    public AudioClip m_ChargingClip;            // Audio that plays when each shot is charging up.
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.
    public float m_ChargeSpeed; 
    public float timeAttack = 2f;
    float timer;


    private string m_FireButton;                // The input axis that is used for launching shells.
    private float m_CurrentLaunchForce;         // The force that will be given to the shell when the fire button is released.
                   // How fast the launch force increases, based on the max charge time.
    private bool m_Fired;                       // Whether or not the shell has been launched with this button press.


    private void OnEnable()
    {
        // When the tank is turned on, reset the launch force and the UI
        m_CurrentLaunchForce = m_ChargeSpeed;
        m_AimSlider.value = m_ChargeSpeed;
    }


    private void Start()
    {
        
    }


    private void Update()
    {
        timer += Time.deltaTime;
        // The slider should have a default value of the minimum launch force.
        m_AimSlider.value = m_ChargeSpeed;

        // If the max force has been exceeded and the shell hasn't yet been launched...
        if(m_CurrentLaunchForce >= m_ChargeSpeed && !m_Fired && timer >= timeAttack)
        {
            // ... use the max force and launch the shell.
            m_CurrentLaunchForce = m_ChargeSpeed;
            timer = 0;
            Fire();
        }
        // Otherwise, if the fire button has just started being pressed...
        // Otherwise, if the fire button is being held and the shell hasn't been launched yet...
        else if(!m_Fired)
        {
            // Increment the launch force and update the slider.
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

            m_AimSlider.value = m_CurrentLaunchForce;
        }
        // Otherwise, if the fire button is released and the shell hasn't been launched yet...
        else if(!m_Fired && timer >= timeAttack)
        {
            timer = 0;
            // ... launch the shell.
            Fire();
        }else{
            m_Fired = false;
            m_CurrentLaunchForce = m_ChargeSpeed;

            // Change the clip to the charging clip and start it playing.
            m_ShootingAudio.clip = m_ChargingClip;
            m_ShootingAudio.Play();
        }
    }


    private void Fire()
    {
        // Set the fired flag so only Fire is only called once.
        m_Fired = true;

        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; ;

        // Change the clip to the firing clip and play it.
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        // Reset the launch force.  This is a precaution in case of missing button events.
        m_CurrentLaunchForce = m_ChargeSpeed;
    }
}