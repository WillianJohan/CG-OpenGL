using System.Numerics;
using System.IO;
using static RendererEngine.OpenGL.GL;

namespace RendererEngine
{
    public class Shader : System.IDisposable
    {
        ShaderProgramSource source;

        public uint VertexShaderID      { get; private set; }
        public uint FragmentShaderID    { get; private set; }
        public uint ProgramID           { get; private set; }

        public Shader()
        {
            source = new ShaderProgramSource(ShaderProgramSource.DEFAULT_SHADER_PATH);
        }

        public Shader(string vertexCode, string fragmentCode)
        {
            source = new ShaderProgramSource(vertexCode, fragmentCode);
        }

        public Shader(string filepath)
        {
            if (File.Exists(filepath))
                source = new ShaderProgramSource(filepath);
            else
                source = new ShaderProgramSource(ShaderProgramSource.DEFAULT_SHADER_PATH);
        }

        public void Load()
        {
            int[] status; // Status of shader compilation


            // Vertex Shader ==============================================
            VertexShaderID = glCreateShader(GL_VERTEX_SHADER);
            glShaderSource(VertexShaderID, source.VertexShaderCode);
            glCompileShader(VertexShaderID);

            status = glGetShaderiv(VertexShaderID, GL_COMPILE_STATUS, 1);
            if (status[0] == 0)
            {
                string error = glGetShaderInfoLog(VertexShaderID);
                Debug.ErrorLog("To compile VERTEX SHADER: " + error);
            }


            // Fragment Shader =============================================
            FragmentShaderID = glCreateShader(GL_FRAGMENT_SHADER);
            glShaderSource(FragmentShaderID, source.FragmentShaderCode);
            glCompileShader(FragmentShaderID);
            
            status = glGetShaderiv(FragmentShaderID, GL_COMPILE_STATUS, 1);
            if (status[0] == 0)
            {
                string error = glGetShaderInfoLog(FragmentShaderID);
                Debug.ErrorLog("To compile FRAGMENT SHADER: " + error);
            }


            // Linking the shader to program ===============================
            ProgramID = glCreateProgram();
            glAttachShader(ProgramID, VertexShaderID);
            glAttachShader(ProgramID, FragmentShaderID);

            glLinkProgram(ProgramID);


            // Delete and Detach Shader because we don't need anymore ======
            glDetachShader(ProgramID, VertexShaderID);
            glDetachShader(ProgramID, FragmentShaderID);
            glDeleteShader(VertexShaderID);
            glDeleteShader(FragmentShaderID);

        }

        public void Use() => glUseProgram(ProgramID);

        public void SetMatrix4x4(string uniformName, Matrix4x4 mat)
        {
            int location = glGetUniformLocation(ProgramID, uniformName);
            glUniformMatrix4fv(location, 1, false, GetMatrix4x4Values(mat));
            //glUniformMatrix4fv(location, 1, true, GetMatrix4x4Values(mat));
        }
        
        public void setVector3(string uniformName, Vector3 vec3)
        {
            int location = glGetUniformLocation(ProgramID, uniformName);
            glUniform3fv(location, 1, GetVector3Values(vec3));
        }
        
        public void setFloat(string uniformName, float value)
        {
            int location = glGetUniformLocation(ProgramID, uniformName);
            glUniform1f(location, value);
        }

        private float[] GetVector3Values(Vector3 vec3)
        {
            return new float[]
            {
                vec3.X, vec3.Y, vec3.Z
            };
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

        public void Dispose()
        {
            glDeleteProgram(ProgramID);
        }

        public struct ShaderProgramSource
        {
            public static readonly string DEFAULT_SHADER_PATH = "..\\..\\..\\Engine\\Renderer\\GraphicElements\\Basic.shader";
            private enum ShaderType { NONE = -1, VERTEX = 0, FRAGMENT = 1 }


            public string VertexShaderCode      { get; private set; }
            public string FragmentShaderCode    { get; private set; }


            public ShaderProgramSource(string vertexCode, string fragmentCode)
            {
                this.VertexShaderCode = vertexCode;
                this.FragmentShaderCode = fragmentCode;
            }

            public ShaderProgramSource(string fiepath)
            {
                VertexShaderCode = "";
                FragmentShaderCode = "";
                ParseShader(fiepath);
            }

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
                    else if(type != ShaderType.NONE)
                        shaderCode[(int)type] += Line + "\n";
                }

                VertexShaderCode    = shaderCode[(int)ShaderType.VERTEX];
                FragmentShaderCode  = shaderCode[(int)ShaderType.FRAGMENT];
            }
        }
    }
}
