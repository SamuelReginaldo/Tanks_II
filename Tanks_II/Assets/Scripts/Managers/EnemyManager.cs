using System;
using UnityEngine;

[Serializable]
public class EnemyManager
{
    [HideInInspector]
    public GameObject m_Instance;
    public Transform m_positionEnemy; 

    private EnemyMovement m_E_Movement;
    private EnemyShooting m_E_Shooting;
    private GameObject m_CanvasGameObject;

    public void SetUpEnemy(){
        m_E_Movement = m_Instance.GetComponent<EnemyMovement>();
        m_E_Shooting = m_Instance.GetComponent<EnemyShooting>();
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;
    }
    
    public void DisableControl()
    {
        m_E_Movement.enabled = false;
        m_E_Shooting.enabled = false;

        m_CanvasGameObject.SetActive(false);
    }

    public void EnableControl()
    {
        m_E_Movement.enabled = true;
        m_E_Shooting.enabled = true;

        m_CanvasGameObject.SetActive(true);
    }
    
    public void Reset()
    {
        m_Instance.transform.position = m_positionEnemy.position;
        m_Instance.transform.rotation = m_positionEnemy.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
