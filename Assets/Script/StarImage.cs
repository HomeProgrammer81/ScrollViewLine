using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    /// <summary>
    /// ScrollView -> Viewport -> Content
    /// </summary>
    class StarImage : MonoBehaviour
    {
        private LineCords StarLineCords = new LineCords(
            new List<LineCord>()
            {
                new LineCord(200,143),
                new LineCord(288,79),
                new LineCord(254,183),
                new LineCord(342,246),
                new LineCord(233,246),
                new LineCord(200,350),
                new LineCord(167,246),
                new LineCord(58,246),
                new LineCord(146,183),
                new LineCord(112,79),
                new LineCord(200,143)
            });

        private int StarLineWidth = 5;

        private int ImageWidth = 400;

        private int ImageHeight = 400;

        private void Start()
        {
            GameObject viewport = transform.Find("Viewport").gameObject;

            GameObject content = viewport.transform.Find("Content").gameObject;
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(ImageWidth, ImageHeight);

            GameObject backGameObject = Instantiate(new GameObject());
            backGameObject.AddComponent<Image>();
            backGameObject.transform.parent = content.transform;
            backGameObject.name = "BackImage";
            backGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(ImageWidth, ImageHeight);
            backGameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
            backGameObject.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
            backGameObject.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
            backGameObject.transform.localPosition = new Vector3(0, 0, 0);

            // 背景を白にする
            Color backColor = new Color(255, 255, 255, 255);
            Texture2D backTexture = new Texture2D(ImageWidth, ImageHeight, TextureFormat.ARGB32, false);
            for (int x = 0; x < ImageWidth; x++)
            {
                for (int y = 0; y < ImageHeight; y++)
                {
                    backTexture.SetPixel(x, y, backColor);
                }
            }

            Image backImage = backGameObject.GetComponent<Image>();
            backImage.sprite = Sprite.Create(backTexture, new Rect(0, 0, backTexture.width, backTexture.height), new Vector2(0.5F, 0.5F));

            backTexture.Apply();
            
            // ライン
            GameObject lineGameObject = Instantiate(new GameObject());
            lineGameObject.AddComponent<Image>();
            lineGameObject.transform.parent = content.transform;
            lineGameObject.name = "LineImage";
            lineGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(ImageWidth, ImageHeight);
            lineGameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
            lineGameObject.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
            lineGameObject.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
            lineGameObject.transform.localPosition = new Vector3(0, 0, 0);

            Texture2D lineTexture = new Texture2D(ImageWidth, ImageHeight, TextureFormat.ARGB32, false);

            // 背景を白にする
            Color lineBackColor = new Color(255, 255, 255, 0);
            for (int x = 0; x < ImageWidth; x++)
            {
                for (int y = 0; y < ImageHeight; y++)
                {
                    lineTexture.SetPixel(x, y, lineBackColor);
                }
            }
            // ラインを黒にする
            Color lineColor = new Color(0, 0, 0, 100);

            // ラインのドットに黒を設定する
            List<Tuple<int, int>> list = StarLineCords.CreateLineDotList(StarLineWidth);
            foreach (Tuple<int, int> dot in list)
            {
                lineTexture.SetPixel(dot.Item1, dot.Item2, lineColor);
            }

            Image lineImage = lineGameObject.GetComponent<Image>();
            lineImage.sprite = Sprite.Create(lineTexture, new Rect(0, 0, lineTexture.width, lineTexture.height), new Vector2(0.5F, 0.5F));

            lineTexture.Apply();
            
        }
    }
}
