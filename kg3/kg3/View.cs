using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using System.Threading.Tasks;


class Shader
{
    private int width;
    private int height;
    private int id;
    public OpenTK.Vector3 boxSize;
    public OpenTK.Vector3 lightPostion;
    public OpenTK.Vector3 lightReflection;
    public OpenTK.Vector3 lightRefraction;
    public OpenTK.Vector3 boxPosition;
    public OpenTK.Vector3 boxColor;


    public Shader(int width, int height)
    {
        this.lightPostion    = new OpenTK.Vector3(2.0f, 4.0f, -4.0f);
        this.boxPosition     = new OpenTK.Vector3(-0.2f, -2.2f, 1.8f);
        this.lightReflection = new OpenTK.Vector3(0.5f);
        this.lightRefraction = new OpenTK.Vector3(20.0f);
        this.boxSize         = new OpenTK.Vector3(0.5f);
        this.boxColor        = new OpenTK.Vector3(4.0f);

        GL.ShadeModel(ShadingModel.Smooth);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();

        Resize(width, height);

        id = GL.CreateProgram();

        InitShader(width, height);
    }


    private void InitShader(int width, int height)
    {
        string repositoryPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"..\..\"));

        LoadShader(repositoryPath + "raytracing.vert", id, out int vertexShader);
        LoadShader(repositoryPath + "raytracing.frag", id, out int fragmentShader);

        GL.LinkProgram(id);

        GL.GetProgram(id, GetProgramParameterName.LinkStatus, out int status);
        Console.WriteLine(GL.GetProgramInfoLog(id));
    }


    public void SetBoxSize(double value)
    {
        boxSize = new OpenTK.Vector3((float)value);
    }


    public void Resize(int width, int height)
    {
        this.width  = width;
        this.height = height;

        GL.Ortho(0, width, 0, height, -1, 1);
        GL.Viewport(0, 0, width, height);
    }


    public void LoadShader(string filename, int program, out int address)
    {
        switch (Path.GetExtension(filename))
        {
            case ".vert":
                address = GL.CreateShader(ShaderType.VertexShader);
                break;

            case ".frag":
                address = GL.CreateShader(ShaderType.FragmentShader);
                break;

            default:
                address = 0;
                break;
        }

        StreamReader reader = new StreamReader(filename);

        GL.ShaderSource(address, reader.ReadToEnd());

        GL.CompileShader(address);
        GL.AttachShader(program, address);

        Console.WriteLine(GL.GetShaderInfoLog(address));

        reader.Close();
    }


    public void DrawQuads()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        GL.UseProgram(id);

        GL.Uniform3(GL.GetUniformLocation(id, "LIGHT_POSITION"),   lightPostion);
        GL.Uniform3(GL.GetUniformLocation(id, "LIGHT_REFLECTION"), lightReflection);
        GL.Uniform3(GL.GetUniformLocation(id, "LIGHT_REFRACTION"), lightRefraction);
        GL.Uniform3(GL.GetUniformLocation(id, "BOX_CENTER"),       boxPosition);
        GL.Uniform3(GL.GetUniformLocation(id, "BOX_SIZE"),         boxSize);
        GL.Uniform3(GL.GetUniformLocation(id, "BOX_COLOR"),        boxColor);

        GL.Begin(PrimitiveType.Quads);

        GL.Vertex2(-width, -height);
        GL.Vertex2(width, -height);
        GL.Vertex2(width, height);
        GL.Vertex2(-width, height);

        GL.End();
    }
}