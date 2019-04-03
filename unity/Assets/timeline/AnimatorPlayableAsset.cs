using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace OSK42
{

    [System.Serializable]
    public class AnimatorPlayableAsset : PlayableAsset
    {
        public string stateName;

        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            var bh = new AnimatorPlayableBehaviour();
            bh.stateName = stateName;
            var playable = ScriptPlayable<AnimatorPlayableBehaviour>.Create(graph, bh);
            return playable;
        }
    }
}
