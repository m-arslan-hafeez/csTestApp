using System.Runtime.InteropServices;

namespace csTestApp
{
    class DllWraper
    {
        const string dllPath = "EncDecLibrary.dll";

        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void encryptFile(string file_name, int key);

        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void decryptFile(string file_name, int key, string file_type);
    }
}
