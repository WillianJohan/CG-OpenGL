using System.Diagnostics;
using System.Numerics;
using System.IO;
using static Renderer3D.OpenGL.GL;

namespace Renderer3D.Renderer
{
    public class Shader
    {
        ShaderProgramSource source;
        public uint ProgramID { get; set; }

        public Shader(string vertexCode, string fragmentCode)
        {
            source = new ShaderProgramSource(vertexCode, fragmentCode);
        }

        public Shader(string filepath)
        {
            if (File.Exists(filepath))
                source = new ShaderProgramSource(filepath);
            else
                source = new ShaderProgramSource(@"E:\6 - GitHub\UFN_ComputacaoGrafica\TrabalhoFinal\Utilizando CSharp (Testando Implementacao)\Renderer3D\Renderer3D\Renderer\Shader\Basic.shader");
        }

        public void Load()
        {
            //Criando as variáveis
            uint vs; //VertexShader
            uint fs; //FragmentShader
            int[] status; //Serve para verificar o status da compilação dos Shaders


            //Vertex Shader
            vs = glCreateShader(GL_VERTEX_SHADER);
            glShaderSource(vs, source.VertexShaderCode);
            glCompileShader(vs);

            status = glGetShaderiv(vs, GL_COMPILE_STATUS, 1);
            if (status[0] == 0)
            {
                string error = glGetShaderInfoLog(vs);
                Debug.ErrorLog("COMPILAR VERTEX SHADER: " + error);
            }


            //Fragment Shader
            fs = glCreateShader(GL_FRAGMENT_SHADER);
            glShaderSource(fs, source.FragmentShaderCode);
            glCompileShader(fs);

            status = glGetShaderiv(fs, GL_COMPILE_STATUS, 1);
            if (status[0] == 0)
            {
                string error = glGetShaderInfoLog(fs);
                Debug.ErrorLog("COMPILAR FRAGMENT SHADER: " + error);
            }


            //Linkando os shaders ao Program
            ProgramID = glCreateProgram();
            glAttachShader(ProgramID, vs);
            glAttachShader(ProgramID, fs);

            glLinkProgram(ProgramID);


            //Delete Shader pq não precisa mais depois que carrega
            glDetachShader(ProgramID, vs);
            glDetachShader(ProgramID, fs);
            glDeleteShader(vs);
            glDeleteShader(fs);

        }

        public void Use() => glUseProgram(ProgramID);


        public void SetMatrix4x4(string uniformName, Matrix4x4 mat)
        {
            int location = glGetUniformLocation(ProgramID, uniformName);
            glUniformMatrix4fv(location, 1, false, GetMatrix4x4Values(mat));
        }

        private float[] GetMatrix4x4Values(Matrix4x4 m)
        {
            return new float[]
            {
                m.M11, m.M12, m.M13, m.M14,
                m.M21, m.M22, m.M23, m.M24,
                m.M31, m.M32, m.M33, m.M34,
                m.M41, m.M42, m.M43, m.M44
            };
        }
        
        
        private struct ShaderProgramSource
        {
            private enum ShaderType
            {
                NONE = -1,
                VERTEX = 0,
                FRAGMENT = 1
            }

            string vertexCode;
            string fragmentCode;

            public ShaderProgramSource(string vertexCode, string fragmentCode)
            {
                this.vertexCode = vertexCode;
                this.fragmentCode = fragmentCode;
            }

            public ShaderProgramSource(string fiepath)
            {
                vertexCode = "";
                fragmentCode = "";
                ParseShader(fiepath);
            }


            public string VertexShaderCode { get => vertexCode; }
            public string FragmentShaderCode { get => fragmentCode; }


            public void ParseShader(string filepath)
            {
                string[] FileString = File.ReadAllLines(filepath);
                string[] shaderCode = new string[] { "", "" };
                ShaderType type = ShaderType.NONE;

                foreach (string Line in FileString)
                {
                    if (Line.Equals("#shader vertex"))
                        type = ShaderType.VERTEX;
                    else if (Line.Equals("#shader fragment"))
                        type = ShaderType.FRAGMENT;
                    else
                        shaderCode[(int)type] += Line + "\n";
                }

                vertexCode = shaderCode[(int)ShaderType.VERTEX];
                fragmentCode = shaderCode[(int)ShaderType.FRAGMENT];
            }
        }
    }
}
