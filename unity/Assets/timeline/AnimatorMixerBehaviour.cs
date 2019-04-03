using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace OSK42
{
    public class AnimatorMixerBehaviour : PlayableBehaviour
    {

        int lastIndex_;

        public override void OnGraphStart(Playable playable)
        {
            lastIndex_ = -1;
        }

        public override void OnPlayableDestroy(Playable playable)
        {
        }


        static int findActiveIndex(Playable playable, int lastIndex)
        {
            int inputCount = playable.GetInputCount();
            for (var i1 = 0; i1 < inputCount; ++i1)
            {
                var i2 = (lastIndex + i1 + inputCount) % inputCount;
                var inputWeight = playable.GetInputWeight(i2);
                if (0 < inputWeight) return i2;
            }
            return -1;
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            int inputCount = playable.GetInputCount();
            string stateName = "";
            AnimatorPlayableBehaviour behaviour = null;
            int index = findActiveIndex(playable, lastIndex_);
            if (index == -1) return;
            if (lastIndex_ == index) return;
            lastIndex_ = index;
            var inputPlayable = (ScriptPlayable<AnimatorPlayableBehaviour>)playable.GetInput(index);
            var input = inputPlayable.GetBehaviour();
            stateName = input.stateName;
            behaviour = input;

            if (string.IsNullOrEmpty(stateName)) return;

            // 反映
            var binding = playerData as Animator;
            if (binding != null)
            {
                binding.Play(stateName, 0, 0f);
            }
        }
    }
}