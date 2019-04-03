
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

namespace OSK42
{

    [TrackColor(0, 0, 0)] // <- Trackの色を指定する
    [TrackClipType(typeof(AnimatorPlayableAsset))] // <- Trackに挿入するClipの型を指定する
    [TrackBindingType(typeof(Animator))] // <- Trackにバインドする型を指定する
    public class AnimatorTrack : TrackAsset
    {
        public string unko;
        // トラックに対応するMixerを作る
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<AnimatorMixerBehaviour>.Create(graph, inputCount);
        }
    }
}
