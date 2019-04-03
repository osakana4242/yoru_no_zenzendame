using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace OSK42
{
    public class TextMixerBehaviour : PlayableBehaviour
    {
        public string[] textList;
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            // 全clipのalpha値をweightに応じて合計する
            int inputCount = playable.GetInputCount();
            string text = "";
            float weightMax = 0f;
            for (int i = 0; i < inputCount; ++i)
            {
                var inputWeight = playable.GetInputWeight(i);
                if (inputWeight <= weightMax) continue;
                weightMax = inputWeight;
                var inputPlayable = (ScriptPlayable<TextPlayableBehaviour>)playable.GetInput(i);
                var input = inputPlayable.GetBehaviour();
                //text = input.text;
                if (i < textList.Length) {
                    text = textList[ i ];
                }
            }

            // 反映
            var binding = playerData as GameObject;
            if (binding != null)
            {
                var textUI = binding.GetComponent<TMPro.TextMeshProUGUI>();
                if (textUI.text != text)
                {
                    textUI.text = text;
                }
            }
        }
    }
}