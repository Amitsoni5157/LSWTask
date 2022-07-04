using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] BodyAprt;
    private GameObject m_selectedObject;

    public Transform leftPoint;
    private Vector3 panelPos;

    [Header("Panels")]
    [SerializeField] private GameObject BlurPanel;

    [SerializeField]
    private GameObject ItemPanel;


    private void Start()
    {
        ItemPanel.gameObject.SetActive(true);
        panelPos = ItemPanel.transform.position;
        ItemPanel.transform.DOMove(leftPoint.position, 0.25f);
        HouseItem.Click += ItemSelect;
        Vendor.collide += OnCollisdion;
        DialogManager.Instance.OnCloseDialog += dialogEnd;
    }
    /// <summary>
    /// Delegate Call back When Player Reaches near to shop
    /// </summary>
    private void OnCollisdion()
    {
        StartCoroutine(DialogManager.Instance.ShowDialog(NPCController.Instance.dialog));
    }

    /// <summary>
    /// Delegate callback when you complete your shopping
    /// </summary>
    private void dialogEnd()
    {
        StartCoroutine(ShopOpen());
    }   

    /// <summary>
    /// Method for Item click just need to click on Item this method will be call
    /// </summary>
    /// <param name="item"></param>
    private void ItemSelect(GameObject item)
    {
        Debug.Log(item + "  :::Object");
        m_selectedObject = item;
        GenrateObjectinGame();
    }

    /// <summary>
    /// for instatiate object when you click on Panel Object
    /// </summary>
    private void GenrateObjectinGame()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        if (m_selectedObject != null)
        {
            GameObject objectInstance = Instantiate(m_selectedObject, (Vector2)mouseWorldPosition, Quaternion.Euler(new Vector3(0, 0, 0))/*, parentOfItem*/);
        }
    }

    /// <summary>
    /// Panel Goes left side or out side from the screen
    /// </summary>
    public void LeftButton()
    {
        ItemPanel.transform.DOMove(leftPoint.position, 0.25f);
    }

    /// <summary>
    /// Panel enters in game mode from left
    /// </summary>
    public void RightButton()
    {
        ItemPanel.transform.DOMove(panelPos, 0.25f);
    }


    private void OnDisable()
    {
        HouseItem.Click -= ItemSelect;
        Vendor.collide -= OnCollisdion;
        DialogManager.Instance.OnCloseDialog -= dialogEnd;
    }

    /// <summary>
    /// Method for open shop when reached to shop
    /// </summary>
    /// <returns></returns>
    IEnumerator ShopOpen()
    {
        BlurPanel.SetActive(true);
        BlurPanel.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.65f);
        BlurPanel.SetActive(false);
    }

}
