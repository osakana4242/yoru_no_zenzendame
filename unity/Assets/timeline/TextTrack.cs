
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

namespace OSK42
{

    [TrackColor(0, 0, 0)] // <- Trackの色を指定する
    [TrackClipType(typeof(TextPlayableAsset))] // <- Trackに挿入するClipの型を指定する
    [TrackBindingType(typeof(GameObject))] // <- Trackにバインドする型を指定する
    public class TextTrack : TrackAsset
    {
        [TextArea]
        public string text;

        // トラックに対応するMixerを作る
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var mixer = ScriptPlayable<TextMixerBehaviour>.Create(graph, inputCount);
            mixer.GetBehaviour().textList = text.Split('\n');
            return mixer;
        }
    }
}
