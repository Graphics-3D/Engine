using Engine;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var GameScreen = new Form();

GameScreen.FormBorderStyle = FormBorderStyle.None;
GameScreen.WindowState = FormWindowState.Maximized;

GameScreen.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

Camera cameraPlayer = null!;
Graphics g = null!;

PictureBox pb = new PictureBox();
pb.Dock = DockStyle.Fill;
GameScreen.Controls.Add(pb);

GameScreen.Load += (s, e) =>
{
    var size = 50;

    var cameraPoint = new Point3D(GameScreen.Width / 2, GameScreen.Height / 2, 1);
    var normal = new Vector3(0, 1, 0);
    cameraPlayer = new Camera(cameraPoint, 10, normal, 200, 200);
    var cameraBlock = new Panel()
    {
        Width = size,
        Height = size,
        BackColor = Color.Purple,
        Location = new Point(GameScreen.Width / 2 - size / 2, GameScreen.Height / 2 - size / 2)
    };
    GameScreen.Controls.Add(cameraBlock);

    var squareX = GameScreen.Width / 2;
    var squareY = GameScreen.Height / 2 - 200;
    var squarePoint = new Point3D(squareX, squareY, 0);


    var squerePanel = new Panel()
    {
        Width = size,
        Height = size,
        BackColor = Color.Green,
        Location = new Point(squareX - size / 2, squareY - size / 2)
    };
    GameScreen.Controls.Add(squerePanel);

    var bmp = new Bitmap(pb.Width, pb.Height);
    g = Graphics.FromImage(bmp);
    pb.Image = bmp;
    GameScreen.Controls.Add(pb);
    g.DrawLine(Pens.Black, cameraPoint.X, cameraPoint.Y, normal.X, normal.Y);

    var flag = cameraPlayer.ShouldRender(squarePoint, 1000);
};

Application.Run(GameScreen);