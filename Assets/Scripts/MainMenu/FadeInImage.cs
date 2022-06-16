using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{
    private Image TargetImage;
    public float FadeSpeed = 1;
    public float Delay = 3;
    private bool StartFadeOut = false;

    private void Awake()
    {
        //Mendapatkan komponen Image secara otomatis. Catatan: Script ini harus dipasang di komponen Image
        TargetImage = GetComponent<Image>();

        TargetImage.enabled = false;
        TargetImage.color = Color.clear;
    }

    private void Fade()
    {
        //Membuat warna TargetImage pakai transisi Lerp dari transparan ke warna dasar gambar
        TargetImage.color = Color.Lerp(TargetImage.color, Color.white, FadeSpeed * Time.deltaTime);
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
        TargetImage.enabled = true;
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