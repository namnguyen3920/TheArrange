using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObjectsVisual : MonoBehaviour
{

    [SerializeField] private BaseConveyor clearConveyor;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        PlayerCtrl.Instance.OnSelectedChanged += Player_OnSelectedChanged;
    }

    private void Player_OnSelectedChanged(object sender, PlayerCtrl.OnSelectedChangedArgs e)
    {
        if(e.selectedConveyor == clearConveyor)
        {
            Show();
        }else 
        {
            Hide();
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
