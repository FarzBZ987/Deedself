using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutText : MonoBehaviour
{
    private Text TargetText;
    public float FadeSpeed = 1;
    public float Delay = 3;
    private bool StartFadeOut = false;
    public bool black = true;
    private Color color;

    private void Awake()
    {
        if (black)
        {
            color = Color.black;
        }
        else
        {
            color = Color.white;
        }
        //Mendapatkan komponen Image secara otomatis. Catatan: Script ini harus dipasang di komponen Image
        TargetText = GetComponent<Text>();

        TargetText.enabled = false;
        TargetText.color = Color.clear;
    }

    private void Fade()
    {
        //Membuat warna TargetImage pakai transisi Lerp dari transparan ke warna dasar gambar
        TargetText.color = Color.Lerp(TargetText.color, color, FadeSpeed * Time.deltaTime);
    }

    // Start is called before the first frame update
    private void Start()
    {
        //Memanggil fungsi SetTrue_StartFadeOut berdasarkan delay
        Invoke("SetTrue_StartFadeOut", Delay);
    }

    private void SetTrue_StartFadeOut()
    {
        //Mengubah nilai StartFadeOut menjadi true
        StartFadeOut = true;
        //Membuat TargetImage 'muncul' dari canvas
        TargetText.enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //Eksekusi fungsi FadeOut jika nilai StartFadeOut = true
        if (StartFadeOut)
        {
            Fade();
        }
    }
}