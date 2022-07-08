var settings = new SKSettings {
    appName = "Olympus",
    assetsFolder = "Assets",
};

if (!SK.Initialize(settings))
    Environment.Exit(1);

/// <summary>
/// Hand position in world space with information located on the left index finger.
/// </summary>
void HandPosition(Handed hand, FingerId finger, JointId joint) {
    var p = Input.Hand(hand)[finger, joint].Pose;
    Text.Add(p.position.ToString(), p.ToMatrix());
}

SK.Run(() => {

    HandPosition(Handed.Left, FingerId.Index, JointId.Tip);

    // Draw a cube
    Mesh.Cube.Draw(Material.Default, Matrix.S(0.1f));
});