class StringHelper {
    public static string PadCenter(string texto, char separador, int longitud){
        int espacios = longitud - texto.Length;
        int mitadIzq = espacios/2 + texto.Length;
        return texto.PadLeft(mitadIzq, separador).PadRight(longitud, separador);
    }
}