using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine;

public class Mesh
{
    public Faces[] Faces { get; set; }

    public Mesh(IEnumerable<Faces> faces)
    {
        Faces = faces.ToArray();
    }
    public Mesh(params Faces[] faces)
    {
        Faces = faces;
    }
    public Mesh RotateX(float cos, float sin)
    {
        for (Faces i = 0; i < Faces.Count(); i++)
            Faces[i] = Faces[i].RotateX(cos, sin);
        return this;
    }

    public Mesh RotateY(float cosa, float sina)
    {
        for (Faces i = 0; i < Faces.Length; i++)
            Faces[i] = Faces[i].RotateY(cosa, sina);
        return this;
    }

    public Mesh RotateZ(float cosa, float sina)
    {
        for (Faces i = 0; i < Faces.Length; i++)
            Faces[i] = Faces[i].RotateZ(cosa, sina);
        return this;
    }

    public Mesh Scale(float x, float y, float z)
    {
        for (Faces i = 0; i < Faces.Length; i++)
            Faces[i] = Faces[i].Scale(x, y, z);
        return this;
    }

    public Mesh Translate(float x, float y, float z)
    {
        for (Faces i = 0; i < Faces.Length; i++)
            Faces[i] = Faces[i].Translate(x, y, z);
        return this;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("Mesh [");

        foreach (var face in Faces)
            sb.AppendLine(face.ToString());

        sb.Append("]");

        return sb.ToString();
    }
}