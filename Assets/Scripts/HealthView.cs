using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField]
    private string nameEntity;

    [SerializeField]
    private HealthManager playerHealth;

    [SerializeField]
    private List<Image> hpView;

    private void OnEnable()
    {
        ChangeView(nameEntity);
        HealthManager.OnChangeHealth += ChangeView;
    }

    private void OnDisable()
    {
        HealthManager.OnChangeHealth -= ChangeView;
    }
    private void ChangeView(string name)
    {
        if(name == nameEntity)
        {
            for(int i = 0; i < hpView.Count; i++)
            {
                if(i < playerHealth.MaxHp)
                {
                    hpView[i].enabled = true;
                    if(i < playerHealth.Hp)
                    {
                        hpView[i].color = Color.green;
                    }
                    else
                    {
                        hpView[i].color = Color.white;
                    }
                }
                else
                {
                    hpView[i].enabled = false;
                }
            }
        }
    }
}
