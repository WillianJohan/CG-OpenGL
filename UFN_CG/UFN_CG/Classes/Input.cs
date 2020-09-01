using System;

namespace UFN_CG
{
    public class Input
    {
        // Normal types
        public static int getInt()
        {
            return int.Parse(Console.ReadLine());
        }
        public static int getInt (string text)
        {
            Console.WriteLine(text);
            return int.Parse(Console.ReadLine());
        }

        public static float getFloat()
        {
            return float.Parse(Console.ReadLine());
        }
        public static float getFloat(string text)
        {
            Console.WriteLine(text);
            return float.Parse(Console.ReadLine());
        }

        // My Structs
        public static Vector2 getVector2()
        {
            Vector2 inputVector = new Vector2();

            Console.Write("x: ");
            inputVector.x = float.Parse(Console.ReadLine());

            Console.Write("y: ");
            inputVector.y = float.Parse(Console.ReadLine());

            return inputVector;
        }
        public static Vector2 getVector2(string text)
        {
            Console.WriteLine(text);

            Vector2 inputVector = new Vector2();

            Console.Write("x: ");
            inputVector.x = float.Parse(Console.ReadLine());

            Console.Write("y: ");
            inputVector.y = float.Parse(Console.ReadLine());

            return inputVector;
        }
        
        public static Vector3 getVector3()
        {
            Vector3 inputVector = new Vector3();

            Console.Write("x: ");
            inputVector.x = float.Parse(Console.ReadLine());

            Console.Write("y: ");
            inputVector.y = float.Parse(Console.ReadLine());

            Console.Write("z: ");
            inputVector.z = float.Parse(Console.ReadLine());

            return inputVector;
        }
        public static Vector3 getVector3(string text)
        {
            Console.WriteLine(text);
            Vector3 inputVector = new Vector3();

            Console.Write("x: ");
            inputVector.x = float.Parse(Console.ReadLine());

            Console.Write("y: ");
            inputVector.y = float.Parse(Console.ReadLine());

            Console.Write("z: ");
            inputVector.z = float.Parse(Console.ReadLine());

            return inputVector;
        }
        
        public static Vector4 getVector4()
        {
            Vector4 inputVector = new Vector4();

            Console.Write("x: ");
            inputVector.x = float.Parse(Console.ReadLine());

            Console.Write("y: ");
            inputVector.y = float.Parse(Console.ReadLine());

            Console.Write("z: ");
            inputVector.z = float.Parse(Console.ReadLine());

            Console.Write("w: ");
            inputVector.w = float.Parse(Console.ReadLine());

            return inputVector;
        }
        public static Vector4 getVector4(string text)
        {
            Console.WriteLine(text);
            Vector4 inputVector = new Vector4();

            Console.Write("x: ");
            inputVector.x = float.Parse(Console.ReadLine());

            Console.Write("y: ");
            inputVector.y = float.Parse(Console.ReadLine());

            Console.Write("z: ");
            inputVector.z = float.Parse(Console.ReadLine());

            Console.Write("w: ");
            inputVector.w = float.Parse(Console.ReadLine());

            return inputVector;
        }

    }
}
