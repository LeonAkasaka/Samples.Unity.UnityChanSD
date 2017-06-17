using UnityEngine;
using System.Collections;

public class DeformedUnityChanController : MonoBehaviour
{
    #region Layers

    private const string BaseLayer = "Base Layer";
    private const string FaceLayer = "Face";

    private static readonly int BaseLayerHash = Animator.StringToHash(BaseLayer);
    private static readonly int FaceLayerHash = Animator.StringToHash(FaceLayer);

    #endregion

    #region Status

    private const string StandingState = "Standing@loop";
    private const string WalkingState = "Walking@loop";
    private const string RunningState = "Running@loop";
    private const string JumpingState = "Jumping@loop";

    private static readonly int StandingStateHash = Animator.StringToHash(StandingState);
    private static readonly int WalkingStateHash = Animator.StringToHash(WalkingState);
    private static readonly int RunningStateHash = Animator.StringToHash(RunningState);
    private static readonly int JumpingStateHash = Animator.StringToHash(JumpingState);

    #endregion

    #region Parameters

    private const string NextParameter = "Next";
    private const string BackParameter = "Back";

    private static readonly int NextParameterHash = Animator.StringToHash(NextParameter);
    private static readonly int BackParameterHash = Animator.StringToHash(BackParameter);

    #endregion

    #region Axis

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    #endregion

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        var h = Input.GetAxis(HorizontalAxis);
        var v = Input.GetAxis(VerticalAxis);

        var index = _animator.GetLayerIndex(BaseLayer);
        var state = _animator.GetCurrentAnimatorStateInfo(index);

        _animator.SetBool(NextParameterHash, false);
        _animator.SetBool(BackParameterHash, false);

        if (state.shortNameHash != StandingStateHash && v == 0)
        {
            _animator.Play(StandingStateHash, index);
        }
        if (state.shortNameHash == StandingStateHash && v != 0)
        {
            _animator.Play(WalkingStateHash, index);
        }

        if (v > 0) { transform.Translate(0, 0, v * 0.03F); }
        if (v < 0) { transform.Translate(0, 0, v * 0.01F); }
        transform.Rotate(0, h * 2, 0);
    }


    private void OnCallChangeFace(string str)
    {
        var index = _animator.GetLayerIndex(FaceLayer);
        _animator.Play(str, index);
    }
}
