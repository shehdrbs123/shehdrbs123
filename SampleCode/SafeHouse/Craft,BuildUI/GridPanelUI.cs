using UnityEngine;
using System.Collections.Generic;

public enum GridPanelType
{
    BuildCraft=0, WaterCraft, FoodCraft
}

public class GridPanelUI : BaseUI
{
    public GridPanelType PanelType;
    
    [SerializeField] private Transform _contentPanel;
    [SerializeField] private RectTransform _backPanel;

    [SerializeField] private float EaseInTime;
    
    private string buttonUIName;
    private GridPanelManager gridPanelManager;
    private List<GridButtonUI> buttons;
    private Vector3 defaultPosition;
    private Coroutine EaseInOutCoroutine;
    protected void Awake()
    {
        defaultPosition = _backPanel.anchoredPosition;
    }

    public void Init()
    {
        if (gridPanelManager == null)
        {
            InitValues();
            int count = gridPanelManager.GetElementsCount(PanelType);
            buttons = new List<GridButtonUI>(20);
            for (int i = 0; i < count; ++i)
            {
                if (_uiManager == null)
                    _uiManager = GameManager.Instance._uiManager;
                GameObject obj = _uiManager.GetUIClone(buttonUIName);
                GridButtonUI gridButtonUI = obj.GetComponent<GridButtonUI>();
                gridButtonUI.Init(gridPanelManager.GetData(PanelType,i),_contentPanel,EaseOutPanel,UpdateButtons);
                buttons.Add(gridButtonUI);
            }
        }
        else
        {
            UpdateButtons();    
        }
    }

    private void UpdateButtons()
    {
        foreach (GridButtonUI button in buttons)
        {
            button.UpdateButton();
        }
    }

    private void InitValues()
    {
        switch (PanelType)
        {
            case GridPanelType.BuildCraft:
                gridPanelManager = GameManager.Instance._buildManager;
                buttonUIName = "BuildSttButtonUI";
                gridPanelManager.OnOperated += UpdateButtons;
                break;
            case GridPanelType.WaterCraft:
                gridPanelManager = GameManager.Instance._craftManager;
                buttonUIName = "CraftButtonUI";
                gridPanelManager.OnOperated += UpdateButtons;
                break;
            case GridPanelType.FoodCraft :
                gridPanelManager = GameManager.Instance._craftManager;
                buttonUIName = "CraftButtonUI";
                gridPanelManager.OnOperated += UpdateButtons;
                break;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        if(EaseInOutCoroutine!= null)
            StopCoroutine(EaseInOutCoroutine);
        EaseInOutCoroutine = StartCoroutine(_uiManager.LerpAdjustRect(_backPanel, 1, 1, EaseInTime));
    }

    public void EaseOutPanel()
    {
        if(EaseInOutCoroutine!= null)
            StopCoroutine(EaseInOutCoroutine);
        EaseInOutCoroutine = StartCoroutine(_uiManager.LerpAdjustRect(_backPanel, 0, 0, EaseInTime,()=> gameObject.SetActive(false)));
    }
}
