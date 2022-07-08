var settings = new SKSettings {
    appName = "Olympus",
    assetsFolder = "Assets",
};

if (!SK.Initialize(settings))
    Environment.Exit(1);

/// <summary>
/// Provide information about your hand position in world space and present on your finger.
/// </summary>
void HandPosition(Handed hand, FingerId finger, JointId joint) {
    var p = Input.Hand(hand)[finger, joint].Pose;
    Text.Add(p.position.ToString(), p.ToMatrix());
}

SK.Run(() => {
    // Left hand position with info provided on index finger
    HandPosition(Handed.Left, FingerId.Index, JointId.Tip);

    // Draw a cube
    Mesh.Cube.Draw(Material.Default, Matrix.S(0.1f));
});