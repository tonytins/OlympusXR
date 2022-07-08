SK.Initialize(new SKSettings {
    appName = "Olympus",
});

SK.Run(() =>
{
    Mesh.Cube.Draw(Material.Default, Matrix.S(0.1f));
});