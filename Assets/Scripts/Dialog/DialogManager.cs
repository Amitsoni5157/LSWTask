using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }

    [SerializeField] GameObject dialogBox;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] int letterPerSecond;

    public event Action OnShowDialog;
    public event Action OnCloseDialog;

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        Vendor.PlayerNotCollide += PlayerFarFromShop; 
    }

    /// <summary>
    /// Call back of player movers faar from shop
    /// </summary>
    private void PlayerFarFromShop()
    {
        dialogBox.SetActive(false);
    }

    private void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            handleUpdate();
        }
    }

    /// <summary>
    /// For dialog show
    /// </summary>
    /// <param name="dialog"></param>
    /// <returns></returns>
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        currentLine = 0;
        OnShowDialog?.Invoke();
        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    /// <summary>
    /// Run time update on dialog text
    /// </summary>
    public void handleUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            if(currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                currentLine = 0;
                dialogBox.SetActive(false);
                OnCloseDialog?.Invoke();
            }
        }
    }

    /// <summary>
    /// Dialog typing functinality
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var latter in line.ToCharArray())
        {
            dialogText.text += latter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }
        isTyping = false;
    }

    private void OnDisable()
    {
        Vendor.PlayerNotCollide -= PlayerFarFromShop;
    }

}
