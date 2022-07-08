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

// Floor
var floorTransform = Matrix.TS(0, 1.5f, 0, new Vec3(30, 0.1f, 30));
var floorMaterial = new Material(Shader.FromFile("floor.hlsl"));

// Helmet
var helmet = Model.FromFile("DamagedHelmet.gltf");

SK.Run(() => {
    // Left hand position with info provided on index finger
    HandPosition(Handed.Left, FingerId.Index, JointId.Tip);

    if (SK.System.displayType == Display.Opaque)
        Default.MeshCube.Draw(floorMaterial, floorTransform);

    // Draw helmet
    helmet.Draw(Matrix.TS(Vec3.Zero, 0.1f));

    // Draw cube
    Mesh.Cube.Draw(Material.Default, Matrix.S(0.1f));
});