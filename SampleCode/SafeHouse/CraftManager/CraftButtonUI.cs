using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CraftButtonUI : GridButtonUI
{
    [SerializeField] private AudioClip uiSound;
    public CraftDataSO DataSo
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
            UpdateData();
        }
    }

    private CraftDataSO _data;
    
    private void MakeItem()
    {
        GameManager gameManager = GameManager.Instance;
        
#if UNITY_EDITOR
        Debug.Assert(gameManager,"gameManager : NullPointer Exception");
#endif
        GameObject player = GameManager.Instance.GetPlayer();
#if UNITY_EDITOR
        Debug.Assert(player,"player : NullPointer Exception");
#endif
        
        if (TryGetComponent(out Inventory inven))
        {
            for (int i = 0; i < DataSo.resoureces.Length; ++i)
            {
                inven.ComsumeItem(DataSo.resoureces[i],DataSo.resourecsCount[i]);
            }
            inven.AddItem(DataSo.ResultItem);
            _updateAllButtons?.Invoke();
        }
        else
        {
            Debug.LogError("inventory : component null");
        }
        
    }
    private void UpdateData()
    {
        _buildTargetImage.sprite = DataSo.Image;
    }

    public override void Init(ScriptableObject data, Transform parentContent, UnityAction PanelOff, UnityAction UpdateButtons)
    {
        base.Init(data,parentContent, PanelOff, UpdateButtons);
        DataSo= data as CraftDataSO;
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(PlaySound);
        _button.onClick.AddListener(MakeItem);
        transform.SetParent(parentContent,false);
        transform.localScale = Vector3.one;

        _updateAllButtons = UpdateButtons;
        UpdateButton();
    }

    public override GridScriptableObject GetResourceData()
    {
        return _data;
    }

    private void PlaySound()
    {
        SoundManager.PlayClip(uiSound,GameManager.Instance.GetPlayer().transform.position);
    }
    
}
