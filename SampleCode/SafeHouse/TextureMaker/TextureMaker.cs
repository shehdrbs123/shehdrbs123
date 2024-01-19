using System.Collections;
using System.IO;
using UnityEngine;

[ExecuteInEditMode]
public class TextureMaker : MonoBehaviour
{
    [SerializeField]private Camera Cam;
    [SerializeField]private string TargetPrefabsPath;
    private string path;

    private RenderTexture rTex;

    private void SetttingDefault()
    {
        string directory = Directory.GetCurrentDirectory();
        path = Path.Combine(directory, "Assets", "Artwork", "Textures");
        rTex = Cam.targetTexture;
    }
    public void MakeTexture()
    {
        SetttingDefault();
        StartCoroutine(Making());
    }

    private IEnumerator Making()
    {
        GameObject[] obj = Resources.LoadAll<GameObject>(Path.Combine("", TargetPrefabsPath));

        foreach (var ob in obj)
        {
            GameObject copyedObj = Instantiate(ob);
            ob.transform.position = Vector3.zero;

            yield return new WaitForSeconds(0.5f);
            
            string imagePath = Path.Combine(path, $"Texture{Directory.GetFiles(path).Length}.png");
            SaveTexture(imagePath);
            DestroyImmediate(copyedObj);
        }
    }

    public void SaveTexture()
    {
        SetttingDefault();
        string imagePath = Path.Combine(path, $"Texture{Directory.GetFiles(path).Length}.png");
        SaveTexture(imagePath);
    }

    public void SaveTexture(string filePath)
    {
        Texture2D texture = new Texture2D(rTex.width, rTex.height);
        RenderTexture.active = rTex;
        texture.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        texture.Apply();

        // Texture2D를 바이트 배열로 변환
        byte[] bytes = texture.EncodeToPNG();

        // 파일로 저장
        File.WriteAllBytes(filePath, bytes);

        // 메모리에서 해제
        RenderTexture.active = null;
        DestroyImmediate(texture);

        Debug.Log("Render Texture saved to: " + filePath);
    }
    
}
