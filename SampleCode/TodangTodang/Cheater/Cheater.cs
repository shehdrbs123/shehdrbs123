#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cheater : MonoBehaviour
{

    private bool isFold = false;
    private bool InventoryFold;
    private List<List<bool>> InventoryInnerFold;
    private bool addIngredient;
    private bool dayChange;
    private bool bEndingState;

    public Rect boxSize;
    
    private GameManager _gameManager;
    private PlayerData _playerData;
    private PlayerData _clonePlayerData;
    private Inventory _Cloneinventory;
    private DecoStoreData _decoStoreData;
    private GameOperator _gameOperator;
    
    private string[] _labels = new string[] { "star", "money", "date" };
    private string[] _inventoryString = new string[] { "Ingredient", "Recipe","Kitchen","StoreDeco"};
    private string[] _texts;
    private bool isFirstStart;
    private Enums.PlayerDayCycleState currentDayCycle;
    private Enums.PlayerEndingState currentEndingState;
    private GUIStyle innerMargin;
    private Vector2 scrollPosition = Vector2.zero;
    private Enums.PlayerDayCycleState day;
    private IngredientInfoSO[] defaultIngredient;
    
    private string currentTime;
    public void Start()
    {
        _gameOperator = FindObjectOfType<GameOperator>();
        _gameManager = GameManager.Instance;
        _playerData = _gameManager.GetPlayerData();
        _decoStoreData = _gameManager.GetDecoStore();
        _texts = new string[3];

        _texts[0] = _playerData.Star.ToString();
        _texts[1] = _playerData.Money.ToString();
        _texts[2] = _playerData.Date.ToString();
        defaultIngredient = DataManager.Instance.GetDefaultDataArray<IngredientInfoSO>();
        
        innerMargin = new GUIStyle();
        innerMargin.margin.left = 10;
    }

    public void Init()
    {
        isFirstStart = _playerData.IsNotFirstPlay;
        currentDayCycle = _playerData.DayCycleState;
        currentEndingState = _playerData.EndingState;
        
        _clonePlayerData = new PlayerData(_playerData);
        _Cloneinventory = _clonePlayerData.GetInventory();
        InventoryInnerFold = new List<List<bool>>();
        
        InventoryInnerFold.Add(new List<bool>(_Cloneinventory.IngredientDatas.Count*2));
        MakeBoolList(InventoryInnerFold[0],_Cloneinventory.IngredientDatas.Count);
        InventoryInnerFold.Add(new List<bool>(_Cloneinventory.RecipeInfoDatas.Count * 2));
        MakeBoolList(InventoryInnerFold[1],_Cloneinventory.RecipeInfoDatas.Count);
        InventoryInnerFold.Add(new List<bool>(_Cloneinventory.KitchenUtensilInfoDatas.Count * 2));
        MakeBoolList(InventoryInnerFold[2],_Cloneinventory.KitchenUtensilInfoDatas.Count);
        InventoryInnerFold.Add(new List<bool>(_decoStoreData.GetAllStoreDecoData().Count*2));
        MakeBoolList(InventoryInnerFold[3],_decoStoreData.GetAllStoreDecoData().Count);
    }

    private void MakeBoolList(List<bool> boolList, int size)
    {
        for (int i = 0; i < size+1; ++i)
        {
            boolList.Add(false);
        }
    }
    public void OnGUI()
    {
        if (GUILayout.Button("OpenCheat",GUILayout.Width(150),GUILayout.Height(50)))
        {
            Init();
            isFold = !isFold;
        }
    
        if (isFold)
        {
            GUI.Window(0, boxSize, window, "MyWindow");
        }
        
    }
    
    private void window(int id)
    {
        int i = 0;
        scrollPosition = GUILayout.BeginScrollView(scrollPosition,innerMargin);
        
        // GameScene에서의 시간변경 적용UI 체크 과정
        if (!ReferenceEquals(_gameOperator,null))
        {
            HorizontalTextFieldWithName("게임씬 시간 변경",ref currentTime);
            Button("시간 변경 적용", () =>
            {
                Debug.Log(currentTime);
                _gameOperator.ChangeCurrentTime(float.Parse(currentTime));
            });
        }
        
        // 
        for (; i < _texts.Length; ++i)
        {
            HorizontalTextFieldWithName(_labels[i],ref _texts[i]);
        }
        HorizontalToggleWithName("프롤로그시청", ref isFirstStart);


        dayChange = EditorGUILayout.Foldout(dayChange, "홈씬 상황변경");
        if(dayChange)
        {
            Button("아침",() => _gameManager.ChangeState(Enums.PlayerDayCycleState.StartStore));
            Button("매입전",() =>  _gameManager.ChangeState(Enums.PlayerDayCycleState.OpenMarket));
            Button("하루끝",() => _gameManager.ChangeState(Enums.PlayerDayCycleState.DayEnd));
        }

        bEndingState = EditorGUILayout.Foldout(bEndingState, "EndingState 변경");
        if(bEndingState)
        {
            Button("게임진행",() =>  _playerData.UpdateEndingState(Enums.PlayerEndingState.ContinuePlaying));
            Button("게임오버",() =>  _playerData.UpdateEndingState(Enums.PlayerEndingState.GameOverEnding));
            Button("게임클리어",() =>  _playerData.UpdateEndingState(Enums.PlayerEndingState.GameClearEnding));
            Button("게임파산",() =>  _playerData.UpdateEndingState(Enums.PlayerEndingState.BankruptcyEnding));
        }



        List<IngredientInfoData> ingredientInfoDatas = _Cloneinventory.IngredientDatas;
        addIngredient = EditorGUILayout.Foldout(addIngredient, "재료 추가");
        if (addIngredient)
        {
            for (int defaultIngredientIdx = 0; defaultIngredientIdx < defaultIngredient.Length; ++defaultIngredientIdx)
            {
                Button($"{defaultIngredient[defaultIngredientIdx].Name} 추가", () =>
                {
                    int findIdx = ingredientInfoDatas.FindIndex(x => x.DefaultData == defaultIngredient[defaultIngredientIdx]);
                    if(findIdx == -1)
                    {
                        IngredientInfoData ingredient = new IngredientInfoData(defaultIngredient[defaultIngredientIdx], 1);
                        ingredientInfoDatas.Add(ingredient);
                        InventoryInnerFold[0].Add(false);
                    }
                    else
                    {
                        ingredientInfoDatas[findIdx].Quantity += 1;
                    }
                });
            }
        }
        

        InventoryFold = EditorGUILayout.Foldout(InventoryFold, "Inventory");
        Inventory cloneInventory = _clonePlayerData.GetInventory();
        GUILayout.BeginVertical(innerMargin);
        if (InventoryFold)
        {
            for (int inventoryElement = 0; inventoryElement < InventoryInnerFold.Count; ++inventoryElement)
            {
                InventoryInnerFold[inventoryElement][0] = EditorGUILayout.Foldout(InventoryInnerFold[inventoryElement][0], _inventoryString[inventoryElement]);
                
                if (InventoryInnerFold[inventoryElement][0])
                {
                    GUILayout.BeginVertical(innerMargin);
                    switch (inventoryElement)
                    {
                        case 0:
                            {
                                InventoryInnerList(ingredientInfoDatas, inventoryElement, (idx) =>
                                {
                                    if (InventoryInnerFold[inventoryElement][idx + 1])
                                    {
                                        TextLineDraw("수량", ref ingredientInfoDatas[idx].Quantity);
                                        TextLineDraw("유통기한", ref ingredientInfoDatas[idx].ExpirationDate);
                                    }
                                });
                            }
                            break;
                        case 1:
                        {
                            List<RecipeInfoData> recipeInfoDatas = cloneInventory.RecipeInfoDatas;
                            InventoryInnerList(recipeInfoDatas, inventoryElement, (idx) =>
                            {
                                if (InventoryInnerFold[inventoryElement][idx + 1])
                                {
                                    TextLineDraw("레벨",ref recipeInfoDatas[idx].Level);
                                }
                            });
                        }
                            break;
                        case 2 :
                        {
                            List<KitchenUtensilInfoData> kitchenUtensilInfoDatas= cloneInventory.KitchenUtensilInfoDatas;
                            InventoryInnerList(kitchenUtensilInfoDatas, inventoryElement, (idx) =>
                            {
                                if (InventoryInnerFold[inventoryElement][idx + 1])
                                {
                                    TextLineDraw("레벨",ref kitchenUtensilInfoDatas[idx].Level);
                                }
                            });
                        }
                            break;
                        case 3 :
                        {
                            List<StoreDecorationInfoData> StoreDecorationInfoDatas = _decoStoreData.GetAllStoreDecoData();
                            InventoryInnerList(StoreDecorationInfoDatas, inventoryElement, (idx) =>
                            {
                                if (InventoryInnerFold[inventoryElement][idx + 1])
                                {
                                    HorizontalToggleWithName("IsSold",ref StoreDecorationInfoDatas[idx].IsSoldOut );
                                }
                            });
                        }
                            break;                            
                    }
                    GUILayout.EndVertical();
                }
            }
           
        }
        GUILayout.EndVertical();        
        
        if (GUILayout.Button("적용"))
        {
            _playerData.SetStar(int.Parse(_texts[0]));
            _playerData.SetMoney(int.Parse(_texts[1]));
            _playerData.SetDay(int.Parse(_texts[2]));
            _playerData.IsNotFirstPlay = isFirstStart;

            _texts[0] = _playerData.Star.ToString();
            _texts[1] = _playerData.Money.ToString();
            _texts[2] = _playerData.Date.ToString();


            ListCopy<IngredientInfoData>(cloneInventory.IngredientDatas, _playerData.GetInventory().IngredientDatas);
            ListCopy<RecipeInfoData>(cloneInventory.RecipeInfoDatas, _playerData.GetInventory().RecipeInfoDatas);
            ListCopy<KitchenUtensilInfoData>(cloneInventory.KitchenUtensilInfoDatas, _playerData.GetInventory().KitchenUtensilInfoDatas);
        
            _playerData.UpdatePlayerData();
            
            GameManager.Instance.ChangeState(day);
        }

        if (GUILayout.Button("데이터 삭제"))
        {
            DataManager.Instance.DeletePlaySaveDataAll();
        }
        
        GUILayout.EndScrollView();
    }

    private void Button(string label, Action callback)
    {
        if (GUILayout.Button(label))
        {
            callback?.Invoke();
        }
    }

    private void HorizontalTextFieldWithName(string title,ref string changeText)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(title,GUILayout.Width(boxSize.width*0.3f),GUILayout.MaxWidth(boxSize.width*0.3f));
        changeText=GUILayout.TextField(changeText,GUILayout.Width(boxSize.width*0.6f),GUILayout.MaxWidth(boxSize.width*0.6f));
        GUILayout.EndHorizontal();
    }

    private void HorizontalToggleWithName(string title, ref bool value)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(title,GUILayout.Width(boxSize.width*0.3f),GUILayout.MaxWidth(boxSize.width*0.3f));
        value=GUILayout.Toggle(value,title);
        GUILayout.EndHorizontal();
    }
    
    private void TextLineDraw(string label, ref int value)
    {
        string text = string.Empty;
        int tmp = 0;
        GUILayout.BeginHorizontal();
        GUILayout.Label(label);
        text =GUILayout.TextField(value.ToString());
        if (int.TryParse(text, out tmp))
            value = tmp;
        GUILayout.EndHorizontal();
    }

    private void InventoryInnerList<T>( List<T> list,int inventoryIdx ,Action<int> contentCallback) where T : BaseData
    {
        for (int detailInventoryIdx = 0; detailInventoryIdx < list.Count; ++detailInventoryIdx)
        {
            InventoryInnerFold[inventoryIdx][detailInventoryIdx + 1] = EditorGUILayout.Foldout(InventoryInnerFold[inventoryIdx][detailInventoryIdx + 1],
                list[detailInventoryIdx].name);
            GUILayout.BeginVertical(innerMargin);
            if (InventoryInnerFold[inventoryIdx][detailInventoryIdx + 1])
            {
                contentCallback?.Invoke(detailInventoryIdx);
            }
            GUILayout.EndVertical();
        }
    }



    private void ListCopy<T>(List<T> src, List<T> dest)
    {
        if (dest.Count < src.Count)
        {
            for (int i = dest.Count; i < src.Count; ++i)
            {
                dest.Add(src[i]);
            }    
        }

        Debug.Log(dest.Count);
        Debug.Log(src.Count);

        for (int i = 0; i < dest.Count; ++i)
        {
            dest[i] = src[i];
        }
        
    }


}
#endif
