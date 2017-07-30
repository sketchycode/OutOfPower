using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    public Image[] barBulbs;
    [Range(0, 1f)]
    public float value = 0f;
    public Color fullColor;
    public Color midColor;
    public Color lowColor;
    public Color unlitBulbColor;

    void Update()
    {
        var bulbColor = fullColor;
        if(value >= 0.5f)
        {
            bulbColor = Color.Lerp(midColor, fullColor, (value - 0.5f) * 2f);
        }
        else
        {
            bulbColor = Color.Lerp(lowColor, midColor, value * 2f);
        }

        int litBulbs = NumberOfLitBulbsForValue(value, barBulbs.Length);
        for(int i=0; i<barBulbs.Length; i++)
        {
            barBulbs[i].color = (i < litBulbs) ? bulbColor : unlitBulbColor;
        }
    }

    private int NumberOfLitBulbsForValue(float value, int totalBulbs)
    {
        value = Mathf.Lerp((1f / totalBulbs) * 0.99f, 1f + ((1f / totalBulbs) * 0.2f), value);
        return Mathf.FloorToInt(value * totalBulbs);
    }
}
